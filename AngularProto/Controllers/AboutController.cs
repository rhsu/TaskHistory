﻿using System;
using System.Web.Mvc;

namespace AngularProto.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
			var mvcName = typeof(Controller).Assembly.GetName ();
			var isMono = Type.GetType ("Mono.Runtime") != null;

			ViewData ["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
			ViewData ["Runtime"] = isMono ? "Mono" : ".NET";

            return View ();
        }
    }
}
