using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsManagement.Domain.Entities;
using SportsManagement.Domain.Enumerations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SportsManagement.Infrastructure.Persistence
{
    public class SportsManagementDataGenerator
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SportsManagementDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<SportsManagementDbContext>>()))
            {
                #region Generate Teams Mock Data

                if (!context.Teams.Any())
                {
                    context.Teams.AddRange(
                        new Team
                        {
                            Id = new Guid(),
                            Name = "Manchester United",
                            Code = TeamCode.MUN.ToString()
                        },
                        new Team
                        {
                            Id = new Guid(),
                            Name = "Manchester City",
                            Code = TeamCode.MCI.ToString()
                        },
                        new Team
                        {
                            Id = new Guid(),
                            Name = "Arsenal",
                            Code = TeamCode.ARS.ToString()
                        },
                        new Team
                        {
                            Id = new Guid(),
                            Name = "Chelsea",
                            Code = TeamCode.CHE.ToString()
                        },
                        new Team
                        {
                            Id = new Guid(),
                            Name = "Liverpool",
                            Code = TeamCode.LIV.ToString()
                        }
                    );

                    await context.SaveChangesAsync();
                }

                #endregion

                #region Generate Players Mock Data

                if (!context.Players.Any())
                {
                    context.Players.AddRange(
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "David",
                            LastName = "de Gea",
                            JerseyNumber = 1,
                            Position = Position.GoalKeeper.ToString(),
                            Nationality = Nationality.Spain.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Harry",
                            LastName = "Maguire",
                            JerseyNumber = 5,
                            Position = Position.Defender.ToString(),
                            Nationality = Nationality.England.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Victor",
                            LastName = "Lindelöf",
                            JerseyNumber = 2,
                            Position = Position.Defender.ToString(),
                            Nationality = Nationality.Sweden.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Aaron",
                            LastName = "Wan-Bissaka",
                            JerseyNumber = 29,
                            Position = Position.Defender.ToString(),
                            Nationality = Nationality.England.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Luke",
                            LastName = "Shaw",
                            JerseyNumber = 23,
                            Position = Position.Defender.ToString(),
                            Nationality = Nationality.England.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Scott",
                            LastName = "McTominay",
                            JerseyNumber = 39,
                            Position = Position.Midfielder.ToString(),
                            Nationality = Nationality.Scotland.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Fred",
                            LastName = string.Empty,
                            JerseyNumber = 17,
                            Position = Position.Midfielder.ToString(),
                            Nationality = Nationality.Brazil.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Paul",
                            LastName = "Pogba",
                            JerseyNumber = 6,
                            Position = Position.Midfielder.ToString(),
                            Nationality = Nationality.France.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Bruno",
                            LastName = "Fernandes",
                            JerseyNumber = 18,
                            Position = Position.Midfielder.ToString(),
                            Nationality = Nationality.Portugal.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Marcus",
                            LastName = "Rashford",
                            JerseyNumber = 10,
                            Position = Position.Attacker.ToString(),
                            Nationality = Nationality.England.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Anthony",
                            LastName = "Martial",
                            JerseyNumber = 9,
                            Position = Position.Attacker.ToString(),
                            Nationality = Nationality.France.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Ederson",
                            LastName = string.Empty,
                            JerseyNumber = 1,
                            Position = Position.GoalKeeper.ToString(),
                            Nationality = Nationality.Brazil.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MCI.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "John",
                            LastName = "Stones",
                            JerseyNumber = 5,
                            Position = Position.Defender.ToString(),
                            Nationality = Nationality.England.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MCI.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Kevin",
                            LastName = "De Bruyne",
                            JerseyNumber = 17,
                            Position = Position.Midfielder.ToString(),
                            Nationality = Nationality.Belgium.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MCI.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Sergio",
                            LastName = "Agüero",
                            JerseyNumber = 10,
                            Position = Position.Attacker.ToString(),
                            Nationality = Nationality.Argentina.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MCI.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Bernd",
                            LastName = "Leno",
                            JerseyNumber = 1,
                            Position = Position.GoalKeeper.ToString(),
                            Nationality = Nationality.Belgium.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.ARS.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "David",
                            LastName = "Luiz",
                            JerseyNumber = 23,
                            Position = Position.Defender.ToString(),
                            Nationality = Nationality.Brazil.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.ARS.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Dani",
                            LastName = "Ceballos",
                            JerseyNumber = 8,
                            Position = Position.Midfielder.ToString(),
                            Nationality = Nationality.Spain.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.ARS.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Alexandre",
                            LastName = "Lacazette",
                            JerseyNumber = 9,
                            Position = Position.Attacker.ToString(),
                            Nationality = Nationality.France.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.ARS.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Kepa",
                            LastName = string.Empty,
                            JerseyNumber = 1,
                            Position = Position.GoalKeeper.ToString(),
                            Nationality = Nationality.Spain.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.CHE.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Thiago",
                            LastName = "Silva",
                            JerseyNumber = 6,
                            Position = Position.Defender.ToString(),
                            Nationality = Nationality.Brazil.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.CHE.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Mason",
                            LastName = "Mount",
                            JerseyNumber = 19,
                            Position = Position.Midfielder.ToString(),
                            Nationality = Nationality.England.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.CHE.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Timo",
                            LastName = "Werner",
                            JerseyNumber = 11,
                            Position = Position.Attacker.ToString(),
                            Nationality = Nationality.Germany.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.CHE.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Alisson",
                            LastName = string.Empty,
                            JerseyNumber = 1,
                            Position = Position.GoalKeeper.ToString(),
                            Nationality = Nationality.Brazil.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.LIV.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Joe",
                            LastName = "Gomez",
                            JerseyNumber = 12,
                            Position = Position.Defender.ToString(),
                            Nationality = Nationality.England.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.LIV.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Thiago",
                            LastName = string.Empty,
                            JerseyNumber = 6,
                            Position = Position.Midfielder.ToString(),
                            Nationality = Nationality.Spain.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.LIV.ToString()).Id
                        },
                        new Player
                        {
                            Id = new Guid(),
                            FirstName = "Roberto",
                            LastName = "Firmino",
                            JerseyNumber = 9,
                            Position = Position.Attacker.ToString(),
                            Nationality = Nationality.Brazil.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.LIV.ToString()).Id
                        }
                    );

                    await context.SaveChangesAsync();
                }

                #endregion

                #region Generate Managers Mock Data

                if (!context.Managers.Any())
                {
                    context.Managers.AddRange(
                        new Manager
                        {
                            Id = new Guid(),
                            FirstName = "Ole",
                            LastName = "Gunner Solskjær",
                            Nationality = Nationality.Norway.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id
                        },
                        new Manager
                        {
                            Id = new Guid(),
                            FirstName = "Pep",
                            LastName = "Guardiola",
                            Nationality = Nationality.Spain.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.MCI.ToString()).Id
                        },
                        new Manager
                        {
                            Id = new Guid(),
                            FirstName = "Mikel",
                            LastName = "Arteta",
                            Nationality = Nationality.Spain.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.ARS.ToString()).Id
                        },
                        new Manager
                        {
                            Id = new Guid(),
                            FirstName = "Thomas",
                            LastName = "Tuchel",
                            Nationality = Nationality.Germany.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.CHE.ToString()).Id
                        },
                        new Manager
                        {
                            Id = new Guid(),
                            FirstName = "Jurgen",
                            LastName = "Klopp",
                            Nationality = Nationality.Germany.ToString(),
                            TeamId = context.Teams.Single(a => a.Code == TeamCode.LIV.ToString()).Id
                        }
                    );

                    await context.SaveChangesAsync();
                }

                #endregion

                #region Generate User Credentials

                await context.Managers.ForEachAsync(async a =>
                {
                    a.UserName = a.FirstName.ToLower();
                    a.Password = a.FirstName.ToLower();
                    await context.SaveChangesAsync();
                });

                #endregion

                #region Assign Players and Manager to Teams

                await context.Teams.ForEachAsync(async a =>
                {
                    if (a.Players.Count <= 0)
                    {
                        a.Players = await context.Players.Where(p => p.TeamId == a.Id).ToListAsync();
                    }
                    if (a.ManagerId != null || a.ManagerId != Guid.Empty)
                    {
                        a.ManagerId = context.Managers.FirstOrDefault(p => p.TeamId == a.Id).Id;
                    }
                    
                    await context.SaveChangesAsync();
                });

                #endregion

                #region Generate Fixture Mock Data

                if (!context.Fixtures.Any())
                {
                    context.Fixtures.AddRange(
                        new Fixture
                        {
                            Id = new Guid(),
                            HomeTeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id,
                            AwayTeamId = context.Teams.Single(a => a.Code == TeamCode.MCI.ToString()).Id,
                            FixtureDate = DateTime.Now.AddDays(2),
                            FixtureStatus = FixtureStatus.Upcoming
                        },
                        new Fixture
                        {
                            Id = new Guid(),
                            HomeTeamId = context.Teams.Single(a => a.Code == TeamCode.MCI.ToString()).Id,
                            AwayTeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id,
                            Score = "0 - 1",
                            FixtureDate = DateTime.Now.AddDays(-12),
                            FixtureStatus = FixtureStatus.Played
                        },
                        new Fixture
                        {
                            Id = new Guid(),
                            HomeTeamId = context.Teams.Single(a => a.Code == TeamCode.CHE.ToString()).Id,
                            AwayTeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id,
                            FixtureDate = DateTime.Now.AddDays(5),
                            FixtureStatus = FixtureStatus.Upcoming
                        },
                        new Fixture
                        {
                            Id = new Guid(),
                            HomeTeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id,
                            AwayTeamId = context.Teams.Single(a => a.Code == TeamCode.CHE.ToString()).Id,
                            Score = "2 - 1",
                            FixtureDate = DateTime.Now.AddDays(-25),
                            FixtureStatus = FixtureStatus.Played
                        },
                        new Fixture
                        {
                            Id = new Guid(),
                            HomeTeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id,
                            AwayTeamId = context.Teams.Single(a => a.Code == TeamCode.ARS.ToString()).Id,
                            FixtureDate = DateTime.Now.AddDays(18),
                            FixtureStatus = FixtureStatus.Upcoming
                        },
                        new Fixture
                        {
                            Id = new Guid(),
                            HomeTeamId = context.Teams.Single(a => a.Code == TeamCode.ARS.ToString()).Id,
                            AwayTeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id,
                            Score = "1 - 1",
                            FixtureDate = DateTime.Now.AddDays(-22),
                            FixtureStatus = FixtureStatus.Played
                        },
                        new Fixture
                        {
                            Id = new Guid(),
                            HomeTeamId = context.Teams.Single(a => a.Code == TeamCode.LIV.ToString()).Id,
                            AwayTeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id,
                            FixtureDate = DateTime.Now.AddDays(4),
                            FixtureStatus = FixtureStatus.Upcoming
                        },
                        new Fixture
                        {
                            Id = new Guid(),
                            HomeTeamId = context.Teams.Single(a => a.Code == TeamCode.MUN.ToString()).Id,
                            AwayTeamId = context.Teams.Single(a => a.Code == TeamCode.LIV.ToString()).Id,
                            FixtureDate = DateTime.Now.AddDays(-1),
                            Score = "3 - 1",
                            FixtureStatus = FixtureStatus.Played
                        }
                    );

                    await context.SaveChangesAsync();
                }

                #endregion
            }
        }
    }
}
