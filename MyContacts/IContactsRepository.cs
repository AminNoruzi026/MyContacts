using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts
{
    public interface IContactsRepository
    {
        List<MyContact> GetAllContacts();
        MyContact GetContactById(int contactId);
        IEnumerable<MyContact> GetContactsByFilter(string parameter);
        bool InsertContact(MyContact contact);

        bool UpdateContact(MyContact contact);

        bool DeleteContact(MyContact contact);

        bool DeleteContact(int contactId);

    }
}
