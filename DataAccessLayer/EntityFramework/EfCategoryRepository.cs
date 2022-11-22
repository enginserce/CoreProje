using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repostories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        Context context = new Context();

        public void TChangeToFalseCategory(int id)
        {
            var values = context.Categories.Find(id);
            values.CategoryStatus = false;
            context.Update(values);
            context.SaveChanges();

        }

        public void TChangeToTrueCategory(int id)
        {
            var values = context.Categories.Find(id);
            values.CategoryStatus = true;
            context.Update(values);
            context.SaveChanges();
        }
    }
}
