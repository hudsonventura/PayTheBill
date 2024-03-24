using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text;

namespace ClickUp.Repositories;

public class TaskRepository : BaseRepository
{
    public TaskRepository(HttpClient client, string baseURL) : base(client, baseURL)
    {
    }

    public List<Task> GetTasks(double list_id, int page = 0, bool include_closed = false)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseURL}/list/{list_id}/task?page={page}&include_closed={include_closed}");

        var jsonObj = CallAPI(request);
        var json = jsonObj["tasks"].ToString();
        List<Task> list = JsonConvert.DeserializeObject<List<Task>>(json);
        return list;
    }

    public List<Task> ListTasks(double list_id, int page = 0, bool include_closed = false)
    {
        return GetTasks(list_id, page, include_closed);
    }
    
    public Task GetTask(string task_id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseURL}/task/{task_id}");
        var jsonObj = CallAPI(request);
        var json = jsonObj.ToString();
        Task obj = JsonConvert.DeserializeObject<Task>(json);
        return obj;
    }




    public Task CreateTask(double list_id, Task task)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseURL}/list/{list_id}/task");
        try
        {
            string jsonBody = JsonConvert.SerializeObject(TaskCreation.FromTask(task));
            request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var jsonObj = CallAPI(request);
            var json = jsonObj.ToString();
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
        //Remove the '#' before task_id
        task_id = task_id.StartsWith("#") ? task_id.Substring(1) : task_id;

        //Remove the '#' before task_id
        links_to = links_to.StartsWith("#") ? links_to.Substring(1) : links_to;
        

        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseURL}/task/{task_id}/link/{links_to}");
        try
        {
            var jsonObj = CallAPI(request);
        }
        catch (Exception error)
        {
            throw new Exception($"Error on get a task: {error.Message}");
        }
    }

    public void UpdateTask(Task task)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, $"{baseURL}/task/{task.id}");
        try
        {
            string jsonBody = JsonConvert.SerializeObject(task);
            request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            
            var jsonObj = CallAPI(request);
        }
        catch (Exception error)
        {
            throw new Exception($"Error on create task: {error.Message}");
        }
    }

    public void PostComment(string task_id, string comment, int? assignee = null, bool notify_all = true)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"{baseURL}/task/{task_id}/comment");
        try
        {
            string jsonBody = JsonConvert.SerializeObject(new {
                comment_text = comment,
                assignee = assignee,
                notify_all = notify_all
            });
            request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var response = CallAPI(request);
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