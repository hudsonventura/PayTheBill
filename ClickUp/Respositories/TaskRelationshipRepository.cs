using RestSharp;


namespace ClickUp.Repositories;

public class TaskRelationshipRepository : BaseRepository
{
    public TaskRelationshipRepository(RestClient client)
    {
        this.client = client;
    }

    public void AddDependency(string task_id, string task_id_depends)
    {
        var request = new RestRequest($"/task/{task_id}/dependency", Method.Post);
        request.AddBody(new { depends_on = task_id_depends });
        var response = client.Execute(request);
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception(response.Content);
        }
    }
    
    

}