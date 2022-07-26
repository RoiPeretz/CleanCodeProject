
using MapRepositoryService.Core.Configuration;
using MapRepositoryService.Core.Validations.Validators.Interfaces;

namespace MapRepositoryService.Core.Validations.Validators;

public class FileSizeValidator : IFileSizeValidator
{
    private readonly long _maxFileSize;

    public FileSizeValidator(ValidationSettings validationSettings)
    {
        _maxFileSize = validationSettings.MaxFileByteSize;
    }

    public bool Validate(Stream file)
    {
        var size = file.Length;
        return size < _maxFileSize;
    }
}