namespace MapRepositoryService.Core.Validations.Validators.Interfaces;

public interface IFileExtensionValidator
{
    bool Validate(string extension);
}