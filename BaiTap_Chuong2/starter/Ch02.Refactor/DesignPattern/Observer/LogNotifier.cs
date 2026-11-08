using EduHub.Ch02.Domain;
using EduHub.Ch02.Interface;

namespace EduHub.Ch02.DesignPattern;

public class LogNotifier : IEventObserver
{
    private readonly IAppLogger _logger;
    public LogNotifier(IAppLogger logger)
    {
        _logger = logger;
    }

    public void OnEventCreate(Event ev, Club club)
    {
        _logger.Log($"Event create: {ev.Title} at {club.Name}");
    }
}