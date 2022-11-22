using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class WritterManager : IGenericService<Writer>
	{
		IWriterDal _writerDal;

		public WritterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

		public Writer GetId(int id)
		{
			return _writerDal.GetId(id);
		}

		public List<Writer> GetList()
		{
			throw new NotImplementedException();
		}
        public List<Writer> GetWriterById(int id)
        {
			return _writerDal.GetAll(x => x.WriterID == id);
        }

        public void TAdd(Writer t)
		{
            _writerDal.Insert(t);
        }

        public void TDelete(Writer t)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(Writer t)
		{
			_writerDal.Update(t);
		}
    }
}
