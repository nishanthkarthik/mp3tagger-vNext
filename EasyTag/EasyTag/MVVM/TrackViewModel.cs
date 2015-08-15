using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace EasyTag.MVVM
{
    class TrackItemViewModel
    {
        List<Track> Tracks { get; set; }
        private TrackItemViewModel() { }

        public async Task<TrackItemViewModel> InitializeAsync(string songName)
        {
            try
            {
                RestClient client = new RestClient(
                $"http://api.gaana.com/?type=search&subtype=search_song&key={songName}");
                RestRequest request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteTaskAsync(request);
                GaanaMeta gaanaMeta = JsonConvert.DeserializeObject<GaanaMeta>(response.Content);
                Tracks = gaanaMeta.tracks;
                return this;
            }
            catch (Exception exception)
            {   
                Debug.WriteLine(exception.Message);
                throw;
            }
        }

        public static Task<TrackItemViewModel> LoadTrackViewModel(string songName)
        {
            TrackItemViewModel trackItemViewModel = new TrackItemViewModel();
            return trackItemViewModel.InitializeAsync(songName);
        } 
    }
}
