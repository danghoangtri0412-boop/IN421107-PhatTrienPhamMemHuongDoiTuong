using EduHub.Ch02.Domain;

namespace EduHub.Ch02.DesignPattern;

public interface IEventObserver
{
    void OnEventCreate(Event ev, Club club);
}