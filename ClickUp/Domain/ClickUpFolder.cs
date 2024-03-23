namespace ClickUp;

public class Folder
{
    public double id { get; set; }
    public string name { get; set; }
    public int orderindex { get; set; }
    public bool override_statuses { get; set; }
    public bool hidden { get; set; }
    public dynamic space { get; set; }
    public string task_count { get; set; }
    public List<dynamic> lists { get; set; }
}