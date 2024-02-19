using Microsoft.AspNetCore.Mvc;
using TalkToDoc.Client.Shared;

namespace TalkToDoc.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConfigController(IConfiguration configuration) : ControllerBase
{
    private readonly IConfiguration configuration = configuration;

    [HttpGet]
    public WatsonxAssistantConfig GetConfiguration()
    {
        var config = new WatsonxAssistantConfig();
        configuration.GetSection(WatsonxAssistantConfig.Name).Bind(config);
        return config;
    }
}
