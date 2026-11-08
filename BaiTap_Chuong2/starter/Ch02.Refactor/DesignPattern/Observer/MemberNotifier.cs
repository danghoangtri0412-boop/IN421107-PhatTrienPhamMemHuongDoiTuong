using EduHub.Ch02.Domain;
using EduHub.Ch02.Interface;

namespace EduHub.Ch02.DesignPattern;

public class MemberNotifier : IEventObserver
{
    private readonly IMemberRepository _members;
    private readonly INotificationServices _notifier;

    public MemberNotifier(IMemberRepository member, INotificationServices notifier)
    {
        _members = member;
        _notifier = notifier;
    }

    public void OnEventCreate(Event ev, Club club)
    {
        foreach(var m in _members.GetByClub(club.Id))
        {
            _notifier.send(m.Email,$"New event: {ev.Title} at {club.Name}");
        }
    }
}