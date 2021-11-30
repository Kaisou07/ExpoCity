using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace App1.Classes
{
    class UsuarioManager
    {
        const String URL = "http://localhost/blast/list.php";

        private HttpClient getClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("connection", "close");

            return client;
        }
        public async Task<IEnumerable<Usuario>> getUsuario()
        {
            HttpClient client = getClient();

            var res = await client.GetAsync(URL);

            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Usuario>>(content);
            }
            return Enumerable.Empty<Usuario>();
        }
    }
}
