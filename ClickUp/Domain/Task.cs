using ClickUp.Utils;
using Newtonsoft.Json;


namespace ClickUp;

public class Task
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

    public List<User> assignees { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    public DateTime? due_date { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    public DateTime? start_date { get; set; }

    public string url { get; set; }

    public string permission_level { get; set; }

    public Priority priority { get; set; }


    public List<Tag>? tags { get; set; }

    public bool notify_all { get; set; }

    public int? time_estimate { get; set; }

    public List<dynamic> links_to { get; set; } //TODO: Alterar para objeto ou string

    public List<CustomFields>? custom_fields { get; set; }
}
