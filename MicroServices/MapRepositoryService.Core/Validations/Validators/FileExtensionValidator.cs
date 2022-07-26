using System.ComponentModel.DataAnnotations;
using MapRepositoryService.Core.Configuration;
using MapRepositoryService.Core.Validations.Validators.Interfaces;

namespace MapRepositoryService.Core.Validations.Validators
{
    public class FileExtensionValidator : IFileExtensionValidator
    {
        private readonly IReadOnlyList<string> _allowedExtension;

        public FileExtensionValidator(ValidationSettings validationSettings)
        {
            _allowedExtension = validationSettings.AllowedFileExtensions;
        }

        public bool Validate (string extension)
        {
            var exists = _allowedExtension.Contains(extension);
            return exists;
        }
    }
}
