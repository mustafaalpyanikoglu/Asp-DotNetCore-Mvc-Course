using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Filters
{
	public class ValidFirstName : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext context)
		{
			var dictionary = context.ActionArguments.FirstOrDefault(t => t.Key == "customer");
			var customer = dictionary.Value as Customer;
            if (customer.FirstName == "yavuz") //ad yavuz ise bu sayfaya yönlendirilecek.
            {
				context.Result = new RedirectResult("/Home/Index");
            }
            base.OnActionExecuting(context);
		}
	}
}
