using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyContacts.Services;

namespace MyContacts
{
    public class UnitOfWork : IDisposable
    {
        Contact_DBEntities db = new Contact_DBEntities();

        private IContactsRepository _contactsRepository;

        public IContactsRepository contactsRepository
        {
            get
            {
                if (_contactsRepository == null)
                {
                    _contactsRepository = new EFContactRepository(db);
                }

                return _contactsRepository;

            }
        }


        public void Save()
        {
            db.SaveChanges();
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
