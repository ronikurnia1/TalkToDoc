namespace TalkToDoc.Client.Shared;


public class WatsonDiscoveryConfig
{
    public const string Name = "WatsonDiscovery";
    public string? ApiVersion { get; set; }
    public string? ApiUrl { get; set; }
    public string? ApiKey { get; set; }
    public string? ProjectId { get; set; }
}

public class WatsonxAssistantConfig
{
    public const string Name = "watsonxAssistant";
    public string? ServiceInstanceID { get; set; }
    public string? Region { get; set; }
    public string? IntegrationId { get; set; }
}