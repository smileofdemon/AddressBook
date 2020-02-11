using System.Collections.Generic;

namespace AddressBook
{
    public interface IAddressBook
    {
        void Add(Contact contact);
        void Remove(Contact contact);
        void Edit(Contact oldContact, Contact newContact);
        IEnumerable<Contact> FindByAddress(string address);
        IEnumerable<Contact> FindByFIO(string fio);
        Contact FindByPhone(string phone);
    }
}