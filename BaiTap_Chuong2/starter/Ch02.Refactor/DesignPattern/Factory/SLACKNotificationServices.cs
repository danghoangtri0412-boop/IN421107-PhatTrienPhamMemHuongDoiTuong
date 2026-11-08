using EduHub.Ch02.Interface;

namespace EduHub.Ch02.DesignPattern;

public class SLACKNotificationService : INotificationServices
{
    public void send(string to, string message)
    {
        Console.WriteLine($"SLACK to {to}: {message}");
    }
}