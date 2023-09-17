using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OroServices.Domain.Common;
using StarterKit.Domain.Interfaces.Services;
using StarterKit.Domain.Models.Responses;
using System.Net.Http.Json;

namespace StarterKit.Shared.Services
{
    public class ExternalDataService : IExternalDataService
    {
        private readonly ILogger<ExternalDataService> _logger;
        protected readonly ExternalEndPoints? _oroEndPoints;

        public ExternalDataService(
            ILogger<ExternalDataService> logger,
            IOptions<ExternalEndPoints> oroEndPoints
            )
        {
            _logger = logger;
            _oroEndPoints = oroEndPoints.Value;
        }
        /// <summary>
        /// https://jsonplaceholder.typicode.com/posts?userId:1
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<UserPost>?> GetUserPostAsync(int userId)
        {
            List<UserPost>? post = null;
            try
            {
                _logger.LogInformation($"End point : {_oroEndPoints.UserPostEndPoint}?userId:{userId}");
                using (var client = new HttpClient())
                {
                    post = await client.GetFromJsonAsync<List<UserPost>>($"{_oroEndPoints.UserPostEndPoint}?userId:{userId}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("GetUserPostAsync error: {0}", ex.Message);
            }

            return post;
        }
    }
}
