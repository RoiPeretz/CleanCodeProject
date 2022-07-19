namespace NotificationService.Commands.NewMapEntity;

public interface INewMapEntityCommandHandler
{
    void OnNewMapEntity(string message);
}