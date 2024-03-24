using Newtonsoft.Json;

namespace ClickUp;

internal class List
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public double id { get; set; }
    public string name { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public int? orderindex { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string content { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public dynamic status { get; set; }
}
