using ClickUp.Utils;
using Newtonsoft.Json;


namespace ClickUp;

internal class TaskCreation
{
    public string id { get; set; }

    public string name { get; set; }

    public string description { get; set; }

    public Status status { get; set; }

    public decimal orderindex { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    public DateTime? date_created { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    public DateTime? date_updated { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    public DateTime? date_closed { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    public DateTime? date_done { get; set; }

    public bool archived { get; set; } = false;

    public User creator { get; set; }

    public List<int> assignees { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    public DateTime? due_date { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    public DateTime? start_date { get; set; }

    public string url { get; set; }

    public string permission_level { get; set; }

    public int priority { get; set; }


    public List<string>? tags { get; set; }

    public bool notify_all { get; set; }

    public int? time_estimate { get; set; }

    public List<dynamic> links_to { get; set; } //TODO: Alterar para objeto ou string

    internal static TaskCreation FromTask(Task task)
    {
        TaskCreation creation = new TaskCreation();
    
        creation.id = task.id;
        creation.name = task.name;
        creation.description = task.description;
        creation.status = task.status;
        creation.orderindex = task.orderindex;
        creation.date_created = task.date_created;
        creation.date_updated = task.date_updated;
        creation.date_closed = task.date_closed;
        creation.date_done = task.date_done;
        creation.archived = task.archived;
        creation.creator = task.creator;
        creation.assignees = Utils.Helper.AssigneesToListId(task.assignees);
        creation.due_date = task.due_date;
        creation.start_date = task.start_date;
        creation.url = task.url;
        creation.permission_level = task.permission_level;
        creation.priority = Helper.PriorityObjectToEnum(task.priority);
        creation.tags = Utils.Helper.TagsObjectsToListString(task.tags);
        creation.notify_all = task.notify_all;
        creation.time_estimate = task.time_estimate;
        creation.links_to = task.links_to;

        return creation;
    }
}
