﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskHistory.Controllers
{
    public class TaskController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }
    }
}
