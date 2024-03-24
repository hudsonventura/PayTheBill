using ClickUp.Repositories;


namespace ClickUp;

public class ClickUpClient
{
    public TaskRepository Tasks { get; }
    public ListRepository Lists { get; }
    public FoldersRepository Folders { get; }
    public TimerRepository Timers { get; }
    public TaskRelationshipRepository TaskRelationships { get; }

    public ClickUpClient(string token) {
        HttpClient client = new HttpClient();
        string url = "https://api.clickup.com/api/v2";
        client.BaseAddress = new Uri(url);

        client.DefaultRequestHeaders.Add("Authorization", token);


        Tasks = new TaskRepository(client, url);
        Lists = new ListRepository(client,url);
        Folders = new FoldersRepository(client, url);
        Timers = new TimerRepository(client, url);
        TaskRelationships = new TaskRelationshipRepository(client, url);
    }







    

    
}
