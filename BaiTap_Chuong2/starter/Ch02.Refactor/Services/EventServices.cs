using System.Data.Common;
using System.Runtime.CompilerServices;
using EduHub.Ch02.Domain;
using EduHub.Ch02.Interface;

namespace EduHub.Ch02.Services;

public class EventServices
{
    private readonly IClubRepository _clubs;
    private readonly IMemberRepository _members;
    private readonly IAppLogger _logger;
    private readonly INotificationServices _notification;

    public EventServices(IClubRepository club, IMemberRepository member, IAppLogger logger, INotificationServices notification)
    {
        _clubs = club;
        _members = member;
        _logger = logger;
        _notification = notification;
    }

    public Event CreateEvent(Guid clubId, string title, DateTime dateTime)
    {
        var club = _clubs.GetById(clubId) ?? throw new InvalidOperationException("Club not found");
        
        var ev = new Event
        {
            Id = Guid.NewGuid(),
            ClubId = clubId,
            Title = title,
            Date = dateTime,
        };

        _logger.Log($"Event create: {title}");
        
        foreach(var m in _members.GetByClub(clubId))
        {
            _notification.send(m.Email,$"New event '{title} at {club.Name}'");
        }
        return ev;
    }
}