using System.Web;
using TaskHistory.Api.Users;

namespace TaskHistory
{
	public class UserContext
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
