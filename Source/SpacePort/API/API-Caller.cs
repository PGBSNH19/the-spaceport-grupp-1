using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace SpacePort
{
    public class ApiFetchData
    {
        private static readonly RestClient client =  new RestClient("https://swapi.co/api/");
        public PersonDataRoot GetPerson(string search = "")
        {
            var request = new RestRequest("people/?search=" + search, DataFormat.Json);
            var response = client.Get<PersonDataRoot>(request);
            
            return response.Data;
        }

        public PersonDataRoot GetPerson(int index = 1)
        {
            var request = new RestRequest("people/" + index, DataFormat.Json);
            var response = client.Get<PersonDataRoot>(request);

            return response.Data;
        }
        public SpaceshipDataRoot GetSpaceship(string search = "")
        {
            var request = new RestRequest("starships/?search=" + search, DataFormat.Json);
            var response = client.Get<SpaceshipDataRoot>(request);

            return response.Data;
        }

        public SpaceshipDataRoot GetSpaceship(int index = 1)
        {
            var request = new RestRequest("starships/" + index, DataFormat.Json);
            var response = client.Get<SpaceshipDataRoot>(request);

            return response.Data;
        }

    }
    
}

