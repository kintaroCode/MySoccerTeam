using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySoccerTeam.Contracts;

namespace MySoccerTeam.Services
{
    public class UrlBase : Controller
    {
        protected readonly string ApiBaseUrl;

        public UrlBase(IOptions<ApiSettings> options)
        {
            ApiBaseUrl = options.Value.BaseUrl;
        }

        
    }
}
