using EduHub.Ch02.Domain;
using EduHub.Ch02.Interface;

namespace EduHub.Ch02.Infractructure;

public class InMemoryClubRepository : IClubRepository
{
    private readonly List<Club> _clubs = new();
    public void Add(Club club)
    {
        _clubs.Add(club);
    }

    public Club? GetById(Guid id)
    {
        return _clubs.FirstOrDefault(c => c.Id == id);
    }

    public IReadOnlyList<Club> GetAll()
    {
        return _clubs;
    }
} 