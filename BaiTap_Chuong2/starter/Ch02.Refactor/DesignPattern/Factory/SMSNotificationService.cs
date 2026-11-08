using EduHub.Ch02.Interface;

namespace EduHub.Ch02.DesignPattern;

public class SMSNotificationService : INotificationServices
{
    public void send(string to, string message)
    {
        Console.WriteLine($"SMS to {to}: {message}");
    }
}