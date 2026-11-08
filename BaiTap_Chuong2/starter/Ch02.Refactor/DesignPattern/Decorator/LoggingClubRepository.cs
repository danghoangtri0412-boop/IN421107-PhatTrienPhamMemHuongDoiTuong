using System.Reflection.Metadata.Ecma335;
using EduHub.Ch02.Domain;
using EduHub.Ch02.Interface;

namespace EduHub.Ch02.DesignPattern;

public class LoggingClubRepository : IClubRepository
{
    private readonly IClubRepository _clubs;
    private readonly IAppLogger _logger;

    public LoggingClubRepository(IClubRepository club, IAppLogger logger)
    {
        _clubs = club;
        _logger = logger;
    }

    public void Add(Club club)
    {
        _logger.Log($"Add club {club.Name}");
        _clubs.Add(club);
    }

    public Club? GetById(Guid id)
    {
        _logger.Log($"GetById {id}");
        return _clubs.GetById(id);
    }

    public IReadOnlyList<Club> GetAll()
    {
        _logger.Log("Get All");
        return _clubs.GetAll();
    }
}