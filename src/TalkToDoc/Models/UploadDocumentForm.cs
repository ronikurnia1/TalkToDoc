using System.ComponentModel.DataAnnotations;

namespace TalkToDoc.Models;

public class UploadDocumentForm
{
    [Required(ErrorMessage = "Document name is required")]
    public string? DocumentName { get; set; }

    [Required(ErrorMessage = "File document is required")]
    public string? FileName { get; set; }

}
