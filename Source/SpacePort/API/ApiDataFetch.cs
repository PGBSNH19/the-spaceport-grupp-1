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
    public class ApiDataFetch
    {
        private static readonly RestClient client = new RestClient("https://swapi.co/api/");

        public async Task<IRestResponse> GetPersonResponse(string name)
        {
            var request = new RestRequest("people/?search=" + name, DataFormat.Json);
            var response = client.ExecuteAsync<PersonDataResults>(request);

            return await response;
        }

        public async Task<IRestResponse> GetPersonResponse(int index)
        {
            var request = new RestRequest("people/" + index, DataFormat.Json);
            var response = client.ExecuteAsync<PersonDataResults>(request);

            return await response;
        }

        public async Task<IRestResponse> GetSpaceshipResponse(string name)
        {
            var request = new RestRequest("starships/?search=" + name, DataFormat.Json);
            var response = client.ExecuteAsync<SpaceshipDataResults>(request);

            return await response;
        }

        public async Task<IRestResponse> GetSpaceshipResponse(int index)
        {
            var request = new RestRequest("starships/" + index, DataFormat.Json);
            var response = client.ExecuteAsync<SpaceshipDataResults>(request);

            return await response;
        }

        public SpaceshipData GetSpaceShip(int index)
        {
            var dataResponse = GetSpaceshipResponse(index);

            return JsonConvert.DeserializeObject<SpaceshipData>(dataResponse.Result.Content);
        }

        public SpaceshipData GetSpaceShip(string name)
        {
            var dataResponse = GetSpaceshipResponse(name);
            var data = JsonConvert.DeserializeObject<SpaceshipDataResults>(dataResponse.Result.Content);

            return data.results[0];
        }

        public PersonData GetPerson(int index)
        {
            var dataResponse = GetPersonResponse(index);

            return JsonConvert.DeserializeObject<PersonData>(dataResponse.Result.Content);
        }

        public PersonData GetPerson(string name)
        {
            var dataResponse = GetPersonResponse(name);
            var data = JsonConvert.DeserializeObject<PersonDataResults>(dataResponse.Result.Content);
            return data.results[0];
        }
    }
}

