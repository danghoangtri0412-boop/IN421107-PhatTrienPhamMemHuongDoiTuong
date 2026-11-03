using EduHub.Ch02.Domain;

namespace EduHub.Ch02.Interface;

public interface IClubRepository
{
    void Add (Club club);
    Club? GetById(Guid id);
    IReadOnlyList<Club> GetAll();
}