namespace AddressBook
{
    public class Contact
    {
        public string FIO { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Contact contact)
            {
                return FIO == contact.FIO
                       && Address == contact.Address
                       && Phone == contact.Phone;
            }
            
            return false;
        }
    }
}