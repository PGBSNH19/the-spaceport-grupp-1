using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using SpacePort.API;

namespace SpacePort
{
    public class API_Caller
    {
        private static RestClient client =  new RestClient("https://swapi.co/api/");
        
        public CharacterInformationRoot GetCharacter(string search = "")
        {
            var request = new RestRequest("people/", DataFormat.Json);
            var response = client.Get<CharacterInformationRoot>(request);
            
            return response.Data;
        }
        public SpaceshipInformationRoot GetSpaceship(string search = "")
        {
            var request = new RestRequest("starships/", DataFormat.Json);
            var response = client.Get<SpaceshipInformationRoot>(request);

            return response.Data;
        }

    }
    
}

