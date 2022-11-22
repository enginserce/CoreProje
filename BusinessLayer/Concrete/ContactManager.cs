using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ContactManager : IContactService
	{
		IContactDal _contactDal;

		public ContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}

		public void ContactAdd(Contact contact)
		{
			_contactDal.Insert(contact);
		}

		public Contact GetId(int id)
		{
			return _contactDal.GetId(id);
		}

        public List<Contact> GetList(int id)
        {
            return _contactDal.GetAll(x => x.ContactID == id);
        }

        public List<Contact> GetList()
		{
			return _contactDal.GetAll();
		}

		public void TAdd(Contact t)
		{
			throw new NotImplementedException();
		}

		public void TDelete(Contact t)
		{
			_contactDal.Delete(t);
		}

		public void TUpdate(Contact t)
		{
			throw new NotImplementedException();
		}
	}
}
