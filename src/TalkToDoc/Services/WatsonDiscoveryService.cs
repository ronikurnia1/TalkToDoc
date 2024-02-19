using TalkToDoc.Models;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.Discovery.v2;
using TalkToDoc.Client.Shared;

namespace TalkToDoc.Services;


public interface IWatsonDiscoveryService
{
    public Task<string[]> SearchSource(string query, string collectionId);
    public Task<string> UploadDocument(string file, string name);
    public Task<Document[]> GetDocuments();
    public Task RemoveCollection(string collectionId);
}

public class WatsonDiscoveryService : IWatsonDiscoveryService
{
    private readonly WatsonDiscoveryConfig config;
    private readonly DocumentContext documentContext;


    public WatsonDiscoveryService(DocumentContext documentContext, IConfiguration configuration)
    {
        this.documentContext = documentContext;
        config = new WatsonDiscoveryConfig();
        configuration.GetSection(WatsonDiscoveryConfig.Name).Bind(config);
    }
    public async Task<Document[]> GetDocuments()
    {
        var discovery = CreateInstance();
        Document[] docs = [];
        await Task.Run(() =>
        {
            var result = discovery.ListCollections(config.ProjectId);
            docs = result.Result.Collections.Select(c => new Document { Id = c.CollectionId, Name = c.Name }).ToArray();
        });
        return docs;
    }

    public async Task<string[]> SearchSource(string query, string collectionId)
    {
        var discovery = CreateInstance();
        List<string> collectionIds = [collectionId];
        List<string> sources = [];

        await Task.Run(() =>
        {
            var result = discovery.Query(projectId: config.ProjectId, collectionIds: collectionIds,
                naturalLanguageQuery: query, count: 3);
            foreach (var item in result.Result.Results)
            {
                sources.Add(item.DocumentPassages[0].PassageText);
            }
        });
        return [.. sources];
    }

    public async Task<string> UploadDocument(string file, string name)
    {
        var discovery = CreateInstance();

        var memStream = new MemoryStream(File.ReadAllBytes(file));

        // Create collection
        var collectionId = discovery.CreateCollection(projectId: config.ProjectId,
            name: name).Result.CollectionId;

        discovery.AddDocument(config.ProjectId, collectionId, memStream, name, "application/pdf");

        //var fileName = Path.GetFileName(file);
        //var doc = new Document { Id = collectionId, Name = name, Url = $"/data/{fileName}" };
        //documentContext.Documents.Add(doc);
        //await documentContext.SaveChangesAsync();

        await Task.CompletedTask;
        return collectionId;
    }

    private DiscoveryService CreateInstance()
    {
        IamAuthenticator authenticator = new(config.ApiKey);
        DiscoveryService discovery = new(config.ApiVersion, authenticator);
        discovery.SetServiceUrl(config.ApiUrl);
        return discovery;
    }

    public async Task RemoveCollection(string collectionId)
    {
        var discovery = CreateInstance();
        await Task.Run(() =>
        {
            try
            {
                // Delete collection
                discovery.DeleteCollection(config.ProjectId, collectionId);
            }
            catch (Exception ex)
            {
                // Do nothing
            }
        });
        await Task.CompletedTask;
    }
}
