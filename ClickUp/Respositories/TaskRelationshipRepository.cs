

using System.Text;
using Newtonsoft.Json;

namespace ClickUp.Repositories;

public class TaskRelationshipRepository : BaseRepository
{
    public TaskRelationshipRepository(HttpClient client, string baseURL) : base(client, baseURL)
    {
    }

    public void AddDependency(string task_id, string task_id_depends)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseURL}/task/{task_id}/dependency");

        string jsonBody = JsonConvert.SerializeObject(new { depends_on = task_id_depends });
        request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        
        var response = CallAPI(request);
    }
    
    

}