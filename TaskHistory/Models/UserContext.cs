using System.Web;
using TaskHistory.Api.Users;

namespace TaskHistory
{
	//TODO: Don't really need this interface but don't know how to fake Ninject
	// Look that up Later
	public interface IUserContext
	{
		IUser User { get; }
	}

	public class UserContext : IUserContext
	{
		public IUser User
		{
			get
			{			
				return HttpContext.Current.Session["CurrentUser"] as IUser;
			}
		}
	}
}
