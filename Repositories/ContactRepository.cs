using Core.Abstractions.Repositories;
using Core.Models;
#warning check!!
namespace Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactsDbContext _dbContext;

        public ContactRepository(ContactsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Contact> GetAllContacts()
        {
            return _dbContext.Contacts.AsEnumerable();
        }

        public Contact GetContactById(String contactId)
        {
            return _dbContext.Contacts.Find(contactId);
        }

        public Contact GetContactByUserName(String userName)
        {
            return _dbContext.Contacts.FirstOrDefault(x => x.User.UserName == userName);
        }

        public Contact AddContact(Contact contact)
        {
           
            var result = _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public Contact UpdateContact(Contact contact)
        {
            var result = _dbContext.Contacts.Update(contact);
            _dbContext.SaveChanges();

            return result.Entity;
        }

        public void DeleteContact(Contact contact)
        {
            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
        }    
    }
}