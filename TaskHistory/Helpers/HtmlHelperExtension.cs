using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;

namespace TaskHistory.Helpers
{
	public static class HtmlHelperExtension
	{
		public static string IsNavSelected(this HtmlHelper htmlHelper, string controllers = "", string action = "", string cssClass = "selected")
		{
			ViewContext viewContext = htmlHelper.ViewContext;
			bool isChildAction = viewContext.Controller.ControllerContext.IsChildAction;

			if (isChildAction)
				viewContext = htmlHelper.ViewContext.ParentActionViewContext;

			RouteValueDictionary routeValues = viewContext.RouteData.Values;
			string currentAction = routeValues["action"].ToString();
			string currentController = routeValues["controller"].ToString();

			if (String.IsNullOrEmpty(action))
				action = currentAction;

			if (String.IsNullOrEmpty(controllers))
				controllers = currentController;

			string[] acceptedActions = action.Trim().Split(',').Distinct().ToArray();
			string[] acceptedControllers = controllers.Trim().Split(',').Distinct().ToArray();

			return acceptedActions.Contains(currentAction) && acceptedControllers.Contains(currentController) ?
				cssClass : String.Empty;
		}
	}
}

