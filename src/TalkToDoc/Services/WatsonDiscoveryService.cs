using TalkToDoc.Models;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.Discovery.v2;

namespace TalkToDoc.Services;


public interface IWatsonDiscoveryService
{
    public Task<string[]> SearchSource(string query, string collectionId);
    public Task<string> UploadDocument(string file, string name);
    public Task<Document[]> GetDocuments();
    public Task RemoveCollection(string collectionId);
}

public class WatsonDiscoveryService(DocumentContext documentContext,
IConfiguration configuration) : IWatsonDiscoveryService
{
    private readonly DocumentContext documentContext = documentContext;
    private readonly string apiKey = configuration["WatsonDiscovery:ApiKey"] ?? string.Empty;
    private readonly string apiVersion = configuration["WatsonDiscovery:ApiVersion"] ?? "2023-03-31";
    private readonly string apiUrl = configuration["WatsonDiscovery:ApiUrl"] ?? string.Empty;
    private readonly string projectId = configuration["WatsonDiscovery:ProjectId"] ?? string.Empty;

    public async Task<Document[]> GetDocuments()
    {
        var discovery = CreateInstance();
        Document[] docs = [];
        await Task.Run(() =>
        {
            var result = discovery.ListCollections(projectId);
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
            var result = discovery.Query(projectId: projectId, collectionIds: collectionIds,
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
        var collectionId = discovery.CreateCollection(projectId: projectId,
            name: name).Result.CollectionId;

        discovery.AddDocument(projectId, collectionId, memStream, name, "application/pdf", "");

        var fileName = Path.GetFileName(file);
        var doc = new Document { Id = collectionId, Name = name, Url = $"/data/{fileName}" };
        documentContext.Documents.Add(doc);
        await documentContext.SaveChangesAsync();

        return collectionId;
    }

    private DiscoveryService CreateInstance()
    {
        IamAuthenticator authenticator = new(apiKey);
        DiscoveryService discovery = new(apiVersion, authenticator);
        discovery.SetServiceUrl(apiUrl);
        return discovery;
    }

    public async Task RemoveCollection(string collectionId)
    {
        var discovery = CreateInstance();
        await Task.Run(() =>
        {
            // Delete collection
            discovery.DeleteCollection(projectId, collectionId);
        });
        await Task.CompletedTask;
    }
}
