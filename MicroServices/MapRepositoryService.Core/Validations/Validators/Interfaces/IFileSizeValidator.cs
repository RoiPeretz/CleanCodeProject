namespace MapRepositoryService.Core.Validations.Validators.Interfaces;

public interface IFileSizeValidator
{
    bool Validate(Stream file);
}