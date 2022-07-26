namespace MapRepositoryService.Core.Configuration;

public class ValidationSettings 
{
    public IReadOnlyList<string> AllowedFileExtensions { get; set; } = new List<string>(`);
    public long MaxFileByteSize { get; set; } = 0;
}