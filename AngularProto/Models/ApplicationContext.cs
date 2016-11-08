using System.Web;
using TaskHistory.Api.Users;

namespace AngularProto
{
	public class ApplicationContext
	{
		public IUser CurrentUser
		{
			get
			{
				return HttpContext.Current.Session["CurrentUser"] as IUser;
			}
		}
	}
}