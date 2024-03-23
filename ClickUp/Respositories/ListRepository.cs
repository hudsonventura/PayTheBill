using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace ClickUp.Repositories;

public class ListRepository : BaseRepository
{
    internal ListRepository(RestClient client)
    {
        this.client = client;
    }


    internal List GetList(double list_id)
    {
        var request = new RestRequest($"/list/{list_id}", Method.Get);
        var jsonResponse = CallAPI(request);
        return JsonConvert.DeserializeObject<List>(jsonResponse.ToString()); 

    }

    internal List CreateList(double folder_id, List list)
    {
        var request = new RestRequest($"/folder/{folder_id}/list", Method.Post);
        try
        {
            string jsonBody = JsonConvert.SerializeObject(list);
            request.AddBody(jsonBody);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.Content);
            }
            var jsonObj = JArray.Parse($"[{response.Content}]");
            var json = jsonObj[0].ToString();
            List obj = JsonConvert.DeserializeObject<List>(json);
            return obj;
        }
        catch (Exception error)
        {
            throw new Exception($"Error on get a task: {error.Message}");
        }
    }

    
}
