using RestSharp;
using ClickUp.Repositories;


namespace ClickUp;

public class ClickUpClient
{
    RestClient client;


    public TaskRepository Tasks { get; }
    public ListRepository Lists { get; }
    public FoldersRepository Folders { get; }
    public TimerRepository Timers { get; }
    public TaskRelationshipRepository TaskRelationships { get; }

    public ClickUpClient(string token) {
        string url = "https://api.clickup.com/api/v2";
        client = new RestClient(url);
        client.AddDefaultHeader("Authorization", token);


        Tasks = new TaskRepository(client);
        Lists = new ListRepository(client);
        Folders = new FoldersRepository(client);
        Timers = new TimerRepository(client);
        TaskRelationships = new TaskRelationshipRepository(client);
    }







    

    
}
