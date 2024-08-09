using MultiTenancy.Data;
using MultiTenancy.Data.DTOs;
using MultiTenancy.Models;

namespace MultiTenancy.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;
        public PersonService(AppDbContext context)
        {
            _context = context;
        }
        public Person CreatePerson(CreatePersonRequest request)
        {
            var person = new Person();
            person.Name = request.Name;
            person.Designation = request.Designation;
            _context.Persons.Add(person);
            _context.SaveChanges();

            return person;
        }

        public bool DeletePerson(int id)
        {
            var person = _context.Persons.Where(x => x.Id == id).FirstOrDefault();

            if (person != null)
            {
                _context.Remove(person);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons.ToList();
        }

        public Person GetPersonById(int id)
        {
            return _context.Persons.FirstOrDefault(x => x.Id == id);
        }

    }
}
