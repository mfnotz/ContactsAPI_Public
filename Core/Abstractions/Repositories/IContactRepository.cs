using Core.Models;

namespace Core.Abstractions.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts();
        Contact GetContactById(String contactId);
        Contact GetContactByUserName(String userName);
        Contact AddContact(Contact contact);
        Contact UpdateContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}
