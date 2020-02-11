using System;
using System.Linq;
using AddressBook;
using NUnit.Framework;

namespace AddressBookTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FindTest()
        {
            var addressBook = new AddressBook.AddressBook();
            addressBook.Add( new Contact
            {
                Address = "address",
                FIO = "FIO",
                Phone = "phone"
            });

            var contacts = addressBook.FindByAddress("address");
            
            Assert.True(contacts.Count() == 1);
            
            var contact = contacts.First();
            
            Assert.True(contact.Address == "address");
            Assert.True(contact.FIO == "FIO");
            Assert.True(contact.Phone == "phone");
            
            contacts = addressBook.FindByFIO("FIO");
            
            Assert.True(contacts.Count() == 1);
            
            contact = contacts.First();
            
            Assert.True(contact.Address == "address");
            Assert.True(contact.FIO == "FIO");
            Assert.True(contact.Phone == "phone");
            
            contact = addressBook.FindByPhone("phone");
            
            Assert.True(contact != null);
            Assert.True(contact.Address == "address");
            Assert.True(contact.FIO == "FIO");
            Assert.True(contact.Phone == "phone");
        }
        
        [TestCase("new phone", true)]
        [TestCase("old phone", false)]
        public void EditTest(string newPhone, bool expected)
        {
            var oldContact = new Contact
            {
                Address = "old address",
                FIO = "old FIO",
                Phone = "old phone"
            };
            var newContact = new Contact
            {
                Address = "new address",
                FIO = "new FIO",
                Phone = newPhone
            };
            
            var addressBook = new AddressBook.AddressBook();
            addressBook.Add(oldContact);

            addressBook.Edit(oldContact, newContact);
            var contacts = addressBook.FindByAddress("new address");
            
            Assert.True(contacts.Count() == 1);
            
            var contact = contacts.First();
            
            Assert.True(contact.Address == "new address");
            Assert.True(contact.FIO == "new FIO");
            Assert.Equals(contact.Phone == newPhone, expected);
            
            contacts = addressBook.FindByAddress("old address");
            
            Assert.False(contacts.Any());
        }
    }
}