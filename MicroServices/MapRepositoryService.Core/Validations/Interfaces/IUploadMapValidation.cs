using MapRepositoryService.Core.Models;

namespace MapRepositoryService.Core.Validations.Interfaces;

public interface IUploadMapValidation
{
    ResultModel Validate(MapModel model);
}