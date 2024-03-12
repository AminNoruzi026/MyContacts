using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Services
{
    public class EFContactRepository : IContactsRepository
    {
        private Contact_DBEntities db;

        public EFContactRepository(Contact_DBEntities context)
        {
            db = context;
        }
        public bool DeleteContact(MyContact contact)
        {
            try
            {
                db.Entry(contact).State = EntityState.Deleted;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteContact(int contactId)
        {
            try
            {
                var contact = GetContactById(contactId);
                DeleteContact(contact);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<MyContact> GetAllContacts()
        {
            return db.MyContacts.ToList();
        }

        public MyContact GetContactById(int contactId)
        {
            return db.MyContacts.Find(contactId);
        }

        public IEnumerable<MyContact> GetContactsByFilter(string parameter)
        {
            return db.MyContacts.Where(c => c.Name.Contains(parameter) || c.Family.Contains(parameter) || c.Mobile.Contains(parameter)|| c.Email.Contains(parameter)|| c.Address.Contains(parameter)).ToList();

        }

        public bool InsertContact(MyContact contact)
        {
            try
            {
                db.MyContacts.Add(contact);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateContact(MyContact contact)
        {
            try
            {
                db.Entry(contact).State = EntityState.Modified;
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
