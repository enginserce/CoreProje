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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message2 GetId(int id)
        {
            return _messageDal.GetId(id);
        }

        public List<Message2> GetList()
        {
            return _messageDal.GetAll();
        }

        public List<Message2> GetInboxWithMessageByWriter(int id)
        {
            return _messageDal.GetInboxWithMessageByWriter(id);
        }

        public void TAdd(Message2 t)
        {
            _messageDal.Insert(t);
        }

        public void TDelete(Message2 t)
        {
            _messageDal.Delete(t);
        }

        public void TUpdate(Message2 t)
        {
            _messageDal.Update(t);
        }

        public List<Message2> GetSendboxWithMessageByWriter(int id)
        {
            return _messageDal.GetSendboxWithMessageByWriter(id);
        }

        public List<Message2> GetMessageById(int id)
        {
            return _messageDal.GetMessageById(id);
        }
    }
}
