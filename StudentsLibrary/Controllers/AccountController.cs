using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentsLibrary.Controllers
{
  public class AccountController : Controller
  {
    // GET: Account
    public ActionResult Index()
    {
      return View();
    }
    public ActionResult LogOff()
    {
            IAuthenticationManager AuthenticationManager = HttpContext.GetOwinContext().Authentication;
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
    }
   
  }
}