using ClickUp.Utils;
using Newtonsoft.Json;


namespace ClickUp;

public class Task
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string id { get; set; }


    public string name { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string description { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public dynamic status { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public decimal? orderindex { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? date_created { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? date_updated { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? date_closed { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? date_done { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool? archived { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public dynamic creator { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public dynamic assignees { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? due_date { get; set; }

    [JsonConverter(typeof(UnixTimeConverter))]
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? start_date { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string url { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string permission_level { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public dynamic? priority { get; set; }


    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public dynamic? tags { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool notify_all { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public int time_estimate { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public List<dynamic> links_to { get; set; }





}
