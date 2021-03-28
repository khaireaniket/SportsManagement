using Microsoft.AspNetCore.Http;

namespace SportsManagement.Application.Common.Interface
{
    public interface IUserContext
    {
        HttpContext HttpContext { get; }
    }
}
