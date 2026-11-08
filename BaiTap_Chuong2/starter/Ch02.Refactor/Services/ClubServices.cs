using EduHub.Ch02.Domain;
using EduHub.Ch02.Interface;

namespace EduHub.Ch02.Services;

public class ClubServices
{
    private readonly IClubRepository _clubs;
    private readonly IMemberRepository _members;
    private readonly IAppLogger _logger;
    private readonly INotificationServices _notification;

    public ClubServices (IClubRepository club, IMemberRepository members, IAppLogger logger, INotificationServices notification)
    {
        _clubs = club;
        _members = members;
        _logger = logger;
        _notification = notification;
    }

    public Club CreateClub(string name, string description, string presidentEmail)
    {
        var club = Club.Create(name, description);
        _clubs.Add(club);

        _logger.Log($"Club create: {name}");
        _notification.send(presidentEmail,$"Club {name} has been create");

        return club;
    }

    public Member AddMemberToClub(Guid clubId, string membername, string email)
    {
        var club = _clubs.GetById(clubId) ?? throw new InvalidOperationException("Club not found");

        if(_members.CountByClub(clubId) >= 50)
        {
            throw new InvalidOperationException("Club is full (max 50 member)");
        }

        var member = new Member
        {
            Id = Guid.NewGuid(),
            Name = membername,
            Email = email,
            ClubId = clubId
        };

        _members.Add(member);
        _logger.Log($"Member {membername} joined {club.Name}");
        _notification.send(email,$"Welcome to {club.Name}");

        return member;
    }
}