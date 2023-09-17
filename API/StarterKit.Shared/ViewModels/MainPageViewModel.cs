using AirgiCookUI.ViewModels.Interfaces;
using AirgicielsUI.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirgicielsUI.Shared.Extensions;
using AirgiCook.Shared.Models;

namespace AirgiCookUI.ViewModels
{
    internal class MainPageViewModel : IMainPageViewModel
    {
        public IEnumerable<Selection> Selections { get; private set; } = new List<Selection>();

        private readonly HttpClient _httpClient;
        private readonly IAccessTokenService _accessTokenService;

        public MainPageViewModel(HttpClient httpClient
            //,IAccessTokenService accessTokenService
            )
        {
            _httpClient = httpClient;
            //_accessTokenService = accessTokenService;
        }
        private void LoadCurrentObject(IEnumerable<Selection> selections) =>
            Selections = selections.Select(u => u);

        public async Task LoadAllSelections()
        {
            // var jwtToken = await _accessTokenService.GetAccessTokenAsync("jwt_token");
            //var users = await _httpClient.GetAsync<List<Selection>>("selection/getselections", jwtToken);
            var selections = await _httpClient.GetAsync<List<Selection>>("selection/getselections","");
            LoadCurrentObject(selections);
        }
    }
}
