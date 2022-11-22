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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentdal;

        public CommentManager(ICommentDal commentdal)
        {
            _commentdal = commentdal;
        }

        public void CommentAdd(Comment comment)
        {
            _commentdal.Insert(comment);
        }

        public void CommentDelete(Comment comment)
        {
            _commentdal.Delete(comment);
        }

        public void CommentUpdate(Comment comment)
        {
            _commentdal.Update(comment);
        }

        public List<Comment> GetAll(int id)
        {
            return _commentdal.GetAll(x => x.BlogID == id);
        }

        public List<Comment> GetComments()
        {
            return _commentdal.GetComments();
        }

        public Comment GetId(int id)
        {
            return _commentdal.GetId(id);
        }
    }
}
