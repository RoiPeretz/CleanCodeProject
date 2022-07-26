namespace MapRepositoryService.Core.Validations.Validators.Interfaces;

public interface IUniqueNameValidation
{
    bool Validate(string name, IReadOnlyList<string> existing);
}