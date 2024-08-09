using MultiTenancy.Data.DTOs;
using MultiTenancy.Models;

namespace MultiTenancy.Services
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAllPersons();
        Person GetPersonById(int id);
        Person CreatePerson(CreatePersonRequest request);
        bool DeletePerson(int id);
    }
}
