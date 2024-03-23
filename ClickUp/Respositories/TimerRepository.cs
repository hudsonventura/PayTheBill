using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;


namespace ClickUp.Repositories;

public class TimerRepository : BaseRepository
{
    internal TimerRepository(RestClient client)
    {
        this.client = client;
    }

    public void StartTimer(string id_team, string task_id)
    {
        var request = new RestRequest($"/team/{id_team}/time_entries/", Method.Post);
        var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds().ToString() + "000";
        dynamic jsonObj = new
        {
            start = timestamp,
            duration = 3600,
            tid = task_id,
        };
        string jsonBody = JsonConvert.SerializeObject(jsonObj);
        request.AddBody(jsonBody);
        var response = client.Execute(request);
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception(response.Content);
        }
    }

    public void StopTimers(string id_team)
    {
        var request = new RestRequest($"/team/{id_team}/time_entries/stop/", Method.Post);
        var response = client.Execute(request);
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception(response.Content);
        }
    }


    public bool GetActiveTimer(string id_team, string task_id)
    {
        var request = new RestRequest($"/team/{id_team}/time_entries/current/", Method.Get);
        request.AddQueryParameter("task_id", task_id);
        var response = client.Execute(request);
        if (response.StatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new Exception(response.Content);
        }
        return true;
    }
}