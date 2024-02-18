namespace TalkToDoc.Models;

public class Document
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Url {  get; set; } = string.Empty;
    public bool IsSelected { get; set; }

}
