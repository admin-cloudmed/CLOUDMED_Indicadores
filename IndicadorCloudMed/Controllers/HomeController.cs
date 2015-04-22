using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IndicadorGedWeb.Controllers;

namespace IndicadorGedWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
            //if (Session["id"] != null & Session["email"] != null & Session["verified_email"] != null & Session["name"] != null & Session["hd"] != null) 
            //{
            //    return View();
            //}
            //else
            //{
            //    Session["id"] = null;
            //    Session["email"] = null;
            //    Session["verified_email"] = null;
            //    Session["name"] = null;
            //    Session["given_name"] = null;
            //    Session["family_name"] = null;
            //    Session["link"] = null;
            //    Session["picture"] = null;
            //    Session["gender"] = null;
            //    Session["locale"] = null;
            //    Session["hd"] = null;
            //    Session["LoginError"] = "Ops, algo de errado aconteceu. Por favor, faça login novamente!";
            //    LoginController login = new LoginController();
            //    login.IndexError();
            //    return View("../Login/IndexError");
            //}
        }
    }
}
