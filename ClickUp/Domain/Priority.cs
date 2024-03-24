using System.Security.Cryptography;
namespace ClickUp;

public class Priority
{
    public int id { get; set; }
    public string orderindex { get; set; }
    public string color { get; set; }

    public Priority_Enum priority { get; set; }

    public enum Priority_Enum{
        Urgent = 1,
        
        High = 2,
        Normal = 3,
        Low = 4
        
    }
}
