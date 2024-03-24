
namespace ClickUp.Utils;

public class Helper
{
    public static User IdToUser(int value)
    {
        return new User(){
                    id = value
                };
    }

    internal static int UserToId(User value)
    {
        return value.id;
    }

    public static List<User> CreateAssigneesByIds(int[] values)
    {
        var assignees = new List<User>();
        foreach (var v in values)
        {
            assignees.Add(
                new User(){
                    id = v
                }
            );
        }
        return assignees;
    }

    internal static List<int> AssigneesToListId(List<User> values)
    {
        var ids = new List<int>();
        foreach (var v in values)
        {
            ids.Add(v.id);
        }
        return ids;
    }

    public static Priority PriorityEnumToObject(Priority.Priority_Enum v)
    {
        return new Priority(){
            priority = v
        };
    }

    internal static int PriorityObjectToEnum(Priority v)
    {
        return (int) v.priority;
    }

    internal static List<string> TagsObjectsToListString(List<Tag> list)
    {
        return list.Select(x => x.name).ToList();
    }

    public static List<Tag> TagsListStringToObjects(List<string> tags)
    {
        return tags.Select(tag => new Tag { name = tag }).ToList();

    }
}
