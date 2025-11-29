using SchoolOrganization.Integration.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolOrganization.Integration.Manager
{
    public class UserManager : GenericManager<User>
    {
        public UserManager(HttpClient httpClient, string url, User requestBody) :
            base(httpClient, url, requestBody)
        {
            // ReqRes free API requires x-api-key
            _httpClient.DefaultRequestHeaders.Add("x-api-key", "reqres-free-v1");
        }
    }
}
