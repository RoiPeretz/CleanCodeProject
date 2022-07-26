namespace MapRepositoryService.Core.Models;

public record ResultModel(bool Success, string Message);
public record ResultModel<T>(bool Success, string Message, T Result);