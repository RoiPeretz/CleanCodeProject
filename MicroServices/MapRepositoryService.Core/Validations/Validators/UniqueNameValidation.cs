using MapRepositoryService.Core.Validations.Validators.Interfaces;

namespace MapRepositoryService.Core.Validations.Validators;

public class UniqueNameValidation : IUniqueNameValidation
{
    public bool Validate(string name, IReadOnlyList<string> existing)
    {
        return !existing.Contains(name);
    }
}