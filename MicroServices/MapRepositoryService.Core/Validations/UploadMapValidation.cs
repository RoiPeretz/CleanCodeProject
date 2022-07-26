using MapRepositoryService.Core.Data.Maps.Queries;
using MapRepositoryService.Core.Models;
using MapRepositoryService.Core.Validations.Interfaces;
using MapRepositoryService.Core.Validations.Validators.Interfaces;
using Microsoft.Extensions.Logging;

namespace MapRepositoryService.Core.Validations;

public class UploadMapValidation : IUploadMapValidation
{
    private readonly IFileSizeValidator _fileSizeValidator;
    private readonly IFileExtensionValidator _fileExtensionValidator;
    private readonly IUniqueNameValidation _uniqueNameValidation;
    private readonly IValidNameValidator _nameValidator;
    private readonly ILogger<UploadMapValidation> _logger;

    public UploadMapValidation(IFileSizeValidator fileSizeValidator,
        IFileExtensionValidator fileExtensionValidator,
        IUniqueNameValidation uniqueNameValidation,
        IValidNameValidator nameValidator,
        ILogger<UploadMapValidation> logger)
    {
        _fileSizeValidator = fileSizeValidator;
        _fileExtensionValidator = fileExtensionValidator;
        _uniqueNameValidation = uniqueNameValidation;
        _nameValidator = nameValidator;
        _logger = logger;
    }

    public ResultModel Validate(MapModel model)
    {
        var validExtension = _fileExtensionValidator.Validate(model.FileExtension);
        if (!validExtension)
        {
            var message = "Validation failed - invalid file extension";
            _logger.LogInformation($"Did not add {model.Name}" + message);
            return new ResultModel(false, message);
        }

        var validFileSize = _fileSizeValidator.Validate(model.File);
        if (!validFileSize)
        {
            var message = "Validation failed - exceeded max file size";
            _logger.LogInformation($"Did not add {model.Name}" + message);
            return new ResultModel(false, message);
        }

        var validName = _nameValidator.Validate(model.Name);
        if (!validName)
        {
            var message = "Validation failed - file name is not valid";
            _logger.LogInformation($"Did not add {model.Name}" + message);
            return new ResultModel(false, message);
        }
        
        var uniqueName = _uniqueNameValidation.Validate(model.Name);
        if (!uniqueName)
        {
            var message = "Validation failed - file name is not unique";
            _logger.LogInformation($"Did not add {model.Name}" + message);
            return new ResultModel(false, message);
        }

        return new ResultModel(true, string.Empty);
    }
}