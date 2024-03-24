using Newtonsoft.Json;

namespace ClickUp.Repositories;

public class FoldersRepository : BaseRepository
{
    public FoldersRepository(HttpClient client, string baseURL) : base(client, baseURL)
    {
    }

    public List<Folder> GetFolders(double space_id) {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseURL}/space/{space_id}/folder");
        var jsonResponse = CallAPI(request);

        return JsonConvert.DeserializeObject<List<Folder>>(jsonResponse["folders"].ToString());
    }

    public Folder GetFolder(double folder_id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{baseURL}/folder/{folder_id}");
        var jsonResponse = CallAPI(request);

        return JsonConvert.DeserializeObject<Folder>(jsonResponse.ToString());
    }

}