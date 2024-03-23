using Newtonsoft.Json.Linq;
using RestSharp;

namespace ClickUp.Repositories;

public abstract class BaseRepository
{
    protected RestClient client;
    protected JObject CallAPI(RestRequest request) {
        var response = client.Execute(request);
        var jsonObj = JArray.Parse($"[{response.Content}]");
        if(!response.IsSuccessStatusCode){
            throw new Exception(jsonObj[0]["err"].ToString());
        }
        return (JObject)JArray.Parse($"[{response.Content}]")[0];
    }

    protected string CallAPIs(RestRequest request) {
        var response = client.Execute(request);
        var jsonObj = JArray.Parse($"[{response.Content}]");
        if(!response.IsSuccessStatusCode){
            throw new Exception(jsonObj[0]["err"].ToString());
        }
        return $"[{response.Content}]";
    }
}
