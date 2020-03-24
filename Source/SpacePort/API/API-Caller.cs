using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace SpacePort
{
    public class ApiFetchData
    {
        private static readonly RestClient client = new RestClient("https://swapi.co/api/");
        public async Task<IRestResponse> GetPersonResponse(string search)
        {
            var request = new RestRequest("people/?search=" + search, DataFormat.Json);
            var response = client.ExecuteAsync<PersonDataRoot>(request);

            return await response;
        }

        public async Task<IRestResponse> GetPersonResponse(int index)
        {
            var request = new RestRequest("people/" + index, DataFormat.Json);
            var response = client.ExecuteAsync<PersonDataRoot>(request);

            return await response;
        }
        public async Task<IRestResponse> GetSpaceshipResponse(string search)
        {
            var request = new RestRequest("starships/?search=" + search, DataFormat.Json);
            var response = client.ExecuteAsync<SpaceshipDataRoot>(request);

            return await response;
        }

        public async Task<IRestResponse> GetSpaceshipResponse(int index)
        {
            var request = new RestRequest("starships/" + index, DataFormat.Json);
            var response = client.ExecuteAsync<SpaceshipDataRoot>(request);

            return await response;
        }

        public SpaceshipData GetSpaceShip(int index)
        {
            var dataResponse = GetSpaceshipResponse(index);

            return JsonConvert.DeserializeObject<SpaceshipData>(dataResponse.Result.Content);
        }

        public SpaceshipData GetSpaceShip(string search)
        {
            var dataResponse = GetSpaceshipResponse(search);
            var data = JsonConvert.DeserializeObject<SpaceshipDataRoot>(dataResponse.Result.Content);
            return data.results[0];
        }

    }
    
}

