using Newtonsoft.Json.Linq;

namespace ClickUp.Repositories;

public abstract class BaseRepository
{
    protected HttpClient client;
    protected string baseURL;

    protected BaseRepository(HttpClient client, string baseURL)
    {
        this.client = client;
        this.baseURL = baseURL;
    }

    protected JObject CallAPI(HttpRequestMessage request) {
        HttpResponseMessage response = client.SendAsync(request).Result;
        string responseBody = response.Content.ReadAsStringAsync().Result;

        var jsonObj = JArray.Parse($"[{responseBody}]");
        if(!response.IsSuccessStatusCode){
            throw new Exception(jsonObj[0]["err"].ToString());
        }
        return (JObject)jsonObj[0];
    }
}
