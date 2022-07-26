using MapRepositoryService.Core.Configuration;
using MapRepositoryService.Core.Data.Maps.Commands;
using MapRepositoryService.Core.Data.Maps.Queries;
using MapRepositoryService.Core.Services;
using MapRepositoryService.Core.Services.Interfaces;
using MapRepositoryService.Core.Validations;
using MapRepositoryService.Core.Validations.Interfaces;
using MapRepositoryService.Core.Validations.Validators;
using MapRepositoryService.Core.Validations.Validators.Interfaces;
using MapRepositoryService.Infrastructure.MinIO.Maps.Commands;
using MapRepositoryService.Infrastructure.MinIO.Maps.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace MapRepositoryService.Infrastructure.IocContainer;

public static class ServiceCollectionExtension
{
    public static void AddMapsInfrastructureLibrary(this IServiceCollection services, ValidationSettings mapsSettings)
    {
        services.AddScoped<IMapsService, MapsService>();

        //Validation
        services.AddScoped<IUploadMapValidation, UploadMapValidation>(); //Check Scope
        services.AddScoped<IFileExtensionValidator, FileExtensionValidator>();
        services.AddScoped<IFileSizeValidator, FileSizeValidator>();
        services.AddScoped<IUniqueNameValidation, UniqueNameValidation>();
        services.AddScoped<IMapExistsQuery, MapExistsQuery>();


        //Commands
        services.AddScoped<IAddMapCommand, AddMapCommand>();
        services.AddScoped<IDeleteMapCommand, DeleteMapCommand>();

        //Queries
        services.AddScoped<IGetMapQuery, GetMapQuery>();
        services.AddScoped<IGetMapsQuery, GetMapsQuery>();

    }
}