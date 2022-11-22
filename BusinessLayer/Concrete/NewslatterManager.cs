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
	public class NewslatterManager : INewsletterService
	{
		INewsletterDal _newsletterDal;
		public NewslatterManager(INewsletterDal newsletterDal)
		{
			_newsletterDal = newsletterDal;
		}

		public void NewsletterAdd(Newsletter newsletter)
		{
			_newsletterDal.Insert(newsletter);
		}
	}
}
