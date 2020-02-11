using System.Collections.Generic;
using System.Linq;

namespace AddressBook
{
    public class AddressBook : IAddressBook
    {
        private List<Contact> _contacts;

        public AddressBook()
        {
            _contacts = new List<Contact>();
        }

        public void Add(Contact contact)
        {
            if (_contacts.Any(p => p.Equals(contact) || p.Phone == contact.Phone))
            {
                return;
            }
            
            _contacts.Add(contact);
        }

        public void Remove(Contact contact)
        {
            _contacts.Remove(contact);
        }

        public void Edit(Contact oldContact, Contact newContact)
        {
            Remove(oldContact);
            Add(newContact);
        }

        public IEnumerable<Contact> FindByAddress(string address)
        {
            return _contacts.Where(p => p.Address == address);
        }

        public IEnumerable<Contact> FindByFIO(string fio)
        {
            return _contacts.Where(p => p.FIO == fio);
        }

        public Contact FindByPhone(string phone)
        {
            return _contacts.FirstOrDefault(p => p.Phone == phone);
        }
    }
}