using MediatR;
using SportsManagement.Application.Common.Base;
using SportsManagement.Application.Common.Interface;
using SportsManagement.Application.Teams.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SportsManagement.Application.Teams.Queries.GetFixtures
{
    public class GetFixturesQuery : IRequest<List<Fixture>>
    {
        public string Status { get; set; }
    }

    public class GetFixturesQueryHandler : BaseHandler, IRequestHandler<GetFixturesQuery, List<Fixture>>
    {
        private readonly ISportsManagementDbContext _context;

        public GetFixturesQueryHandler(IUserContext userContext, ISportsManagementDbContext context) : base(userContext)
        {
            _context = context;
        }

        public Task<List<Fixture>> Handle(GetFixturesQuery request, CancellationToken cancellationToken)
        {
            var teamId = GetTeamId();
            var fixtures = _context.Fixtures.Where(a => (a.HomeTeamId == teamId || a.AwayTeamId == teamId) 
                                                        && a.FixtureStatus.ToString() == request.Status)
                                            .ToList();

            var dtoFixtures = CustomMapper(fixtures);
            return Task.FromResult(dtoFixtures);
        }

        private List<Fixture> CustomMapper(List<Domain.Entities.Fixture> fixtures)
        {
            List<Fixture> dtoFixtures = new List<Fixture>();

            foreach (var fixture in fixtures)
            {
                dtoFixtures.Add(new Fixture
                {
                    Id = fixture.Id,
                    HomeTeam = _context.Teams.First(a => a.Id == fixture.HomeTeamId).Name,
                    AwayTeam = _context.Teams.First(a => a.Id == fixture.AwayTeamId).Name,
                    FixtureDate = fixture.FixtureDate,
                    Score = fixture.Score ?? "NA"
                });
            }

            return dtoFixtures;
        }
    }
}
