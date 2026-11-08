using EduHub.Ch02.Interface;

namespace EduHub.Ch02.DesignPattern;

public interface INotificationServiceFactory
{
    INotificationServices Create(NofiticationChannel channel);
}