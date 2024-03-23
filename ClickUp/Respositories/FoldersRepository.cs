using Newtonsoft.Json;
using RestSharp;

namespace ClickUp.Repositories;

public class FoldersRepository : BaseRepository
{
    

    internal FoldersRepository(RestClient client)
    {
        this.client = client;
    }

    public List<Folder> GetFolders(double space_id) {
        var request = new RestRequest($"/space/{space_id}/folder", Method.Get);
        var jsonResponse = CallAPI(request);

        return JsonConvert.DeserializeObject<List<Folder>>(jsonResponse["folders"].ToString());
    }

    public Folder GetFolder(double folder_id)
    {
        var request = new RestRequest($"/folder/{folder_id}", Method.Get);
        var jsonResponse = CallAPI(request);

        return JsonConvert.DeserializeObject<Folder>(jsonResponse.ToString());
    }

}