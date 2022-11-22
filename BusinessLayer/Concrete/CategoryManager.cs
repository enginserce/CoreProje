using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category GetId(int id)
        {
            return _categoryDal.GetId(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetAll();
        }

        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
           _categoryDal.Update(t);
        }

        public void TChangeToFalseCategory(int id)
        {
            _categoryDal.TChangeToFalseCategory(id);
        }

        public void TChangeToTrueCategory(int id)
        {
            _categoryDal.TChangeToTrueCategory(id);
        }
    }
}