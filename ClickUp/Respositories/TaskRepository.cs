using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace ClickUp.Repositories;

public class TaskRepository : BaseRepository
{

    public TaskRepository(RestClient client)
    {
        this.client = client;
    }

    public List<Task> GetTasks(double list_id, int page = 0, bool include_closed = false)
    {
        var request = new RestRequest($"/list/{list_id}/task", Method.Get);
        request.AddParameter("page", page);
        request.AddParameter("include_closed", include_closed);
        var jsonObj = CallAPI(request);
        var json = jsonObj["tasks"].ToString();
        List<Task> list = JsonConvert.DeserializeObject<List<Task>>(json);
        return list;
    }

    public List<Task> ListTasks(double list_id, int page = 0, bool include_closed = false)
    {
        return GetTasks(list_id, page, include_closed);
    }
    
    internal Task GetTask(string task_id)
    {
        var request = new RestRequest($"/task/{task_id}", Method.Get);
        var jsonObj = CallAPI(request);
        var json = jsonObj.ToString();
        Task obj = JsonConvert.DeserializeObject<Task>(json);
        return obj;
    }




    public Task CreateTask(double list_id, Task task)
    {
        var request = new RestRequest($"/list/{list_id}/task", Method.Post);
        try
        {
            string jsonBody = JsonConvert.SerializeObject(task);
            request.AddBody(jsonBody);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.Content);
            }
            var jsonObj = JArray.Parse($"[{response.Content}]");
            var json = jsonObj[0].ToString();
            Task obj = JsonConvert.DeserializeObject<Task>(json);
            return obj;
        }
        catch (Exception error)
        {
            throw new Exception($"Error on create task: {error.Message}");
        }
    }

    internal void AddTaskLink(string task_id, string links_to)
    {
        if (task_id.StartsWith("#") || links_to.StartsWith("#"))
        {
            throw new Exception("Task(s) ID cannot start with '#'. Remove it before.");
        }
        var request = new RestRequest($"/task/{task_id}/link/{links_to}", Method.Post);
        try
        {
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.Content);
            }
        }
        catch (Exception error)
        {
            throw new Exception($"Error on get a task: {error.Message}");
        }
    }

    public void UpdateTask(Task task)
    {
        var request = new RestRequest($"/task/{task.id}", Method.Put);
        try
        {
            string jsonBody = JsonConvert.SerializeObject(task);
            request.AddBody(jsonBody);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.Content);
            }
        }
        catch (Exception error)
        {
            throw new Exception($"Error on create task: {error.Message}");
        }
    }

    public void PostComment(string task_id, string comment, int? assignee = null, bool notify_all = true)
    {
        var request = new RestRequest($"/task/{task_id}/comment", Method.Post);
        try
        {
            string jsonBody = JsonConvert.SerializeObject(new {
                comment_text = comment,
                assignee = assignee,
                notify_all = notify_all
            });
            request.AddBody(jsonBody);
            var response = client.Execute(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.Content);
            }
        }
        catch (Exception error)
        {
            throw new Exception($"Error on post comment on task: {error.Message}");
        }
    }


    public void StopTimer(string id)
    {
        throw new NotImplementedException();
    }
}