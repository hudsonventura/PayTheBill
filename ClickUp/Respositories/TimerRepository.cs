using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;


namespace ClickUp.Repositories;

public class TimerRepository : BaseRepository
{
    public TimerRepository(HttpClient client, string baseURL) : base(client, baseURL)
    {
    }

    public void StartTimer(string id_team, string task_id)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseURL}/team/{id_team}/time_entries/");
        var timestamp = DateTimeOffset.Now.ToUnixTimeSeconds().ToString() + "000";
        dynamic jsonObj = new
        {
            start = timestamp,
            duration = 3600,
            tid = task_id,
        };
        string jsonBody = JsonConvert.SerializeObject(jsonObj);
        request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        var response = CallAPI(request);
    }

    public void StopTimers(string id_team)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseURL}/team/{id_team}/time_entries/stop/");
        var response = CallAPI(request);
    }


    public bool GetActiveTimer(string id_team, string task_id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseURL}/team/{id_team}/time_entries/current?task_id={task_id}");
        
        var response = CallAPI(request);
        return true;
    }
}