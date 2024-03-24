using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;
namespace ClickUp.Repositories;

public class ListRepository : BaseRepository
{
    public ListRepository(HttpClient client, string baseURL) : base(client, baseURL)
    {
    }

    internal List GetList(double list_id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseURL}/list/{list_id}");
        var jsonResponse = CallAPI(request);
        return JsonConvert.DeserializeObject<List>(jsonResponse.ToString()); 

    }

    internal List CreateList(double folder_id, List list)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseURL}/folder/{folder_id}/list");
        try
        {
            string jsonBody = JsonConvert.SerializeObject(list);
            request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            var jsonObj = CallAPI(request);
            
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
