using EduHub.Ch02.Interface;

namespace EduHub.Ch02.Infractructure;

public class EmailNofiticationService : INotificationServices
{
    public void send(String to, String message)
    {
        System.Console.WriteLine($"Email to {to} {message}");
    }
}