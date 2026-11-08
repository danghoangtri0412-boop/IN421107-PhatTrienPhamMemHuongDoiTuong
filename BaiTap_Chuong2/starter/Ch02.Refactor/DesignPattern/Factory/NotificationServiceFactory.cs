using EduHub.Ch02.Interface;
using EduHub.Ch02.Infractructure;

namespace EduHub.Ch02.DesignPattern;

public class NotificationServiceFactory : INotificationServiceFactory
{
    public INotificationServices Create(NofiticationChannel channel)
    {
        switch (channel)
        {
            case NofiticationChannel.Email : return new EmailNofiticationService();
            case NofiticationChannel.SMS : return new SMSNotificationService();
            case NofiticationChannel.Slack : return new SLACKNotificationService();
            
            default: throw new ArgumentOutOfRangeException(nameof(channel));
        }
        
    }
}