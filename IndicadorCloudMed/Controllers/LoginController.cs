using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace IndicadorGedWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Login request user credentials tthen send to google/
        public ActionResult Index()
        {
            //return View();
            return View("../Home/Index", null);
        }



        // GET: /Prepare data received from google/
        public ActionResult PrepareData()
        {
            // if do everthing in view with javascript, look there
            return View();
        }



        // POST: / Check data prepared from and verify account
        [HttpPost]
        public ActionResult Access(string access_token)
        {
            if (Request["access_token"] != null)
            {
                String URI = "https://www.googleapis.com/oauth2/v1/userinfo?" + Request["access_token"];
                WebClient webClient = new WebClient();
                Stream stream = webClient.OpenRead(URI);
                string jsonData;
                using (StreamReader br = new StreamReader(stream))
                {
                    jsonData = br.ReadToEnd();
                }
                MemoryStream jsonReturned = new MemoryStream(Encoding.Default.GetBytes(jsonData));
                StreamReader sr = new StreamReader(jsonReturned);
                Dictionary<string, string> userdata = JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());
                //Loop to get values
                foreach (KeyValuePair<string, string> pair in userdata)
                {
                    var keyPair = pair.Key.ToLower();
                    if (keyPair == "id")
                    {
                        @ViewBag.id = pair.Value;
                    }
                    keyPair = pair.Key.ToLower();
                    if (keyPair == "email")
                    {
                        @ViewBag.email = pair.Value;
                    }
                    keyPair = pair.Key.ToLower();
                    if (keyPair == "verified_email")
                    {
                        @ViewBag.verified_email = pair.Value;
                    }
                    keyPair = pair.Key.ToLower();
                    if (keyPair == "name")
                    {
                        @ViewBag.name = pair.Value;
                    }
                    keyPair = pair.Key.ToLower();
                    if (keyPair == "given_name")
                    {
                        @ViewBag.given_name = pair.Value;
                    }
                    keyPair = pair.Key.ToLower();
                    if (keyPair == "family_name")
                    {
                        @ViewBag.family_name = pair.Value;
                    }
                    keyPair = pair.Key.ToLower();
                    if (keyPair == "link")
                    {
                        @ViewBag.link = pair.Value;
                    }
                    keyPair = pair.Key.ToLower();
                    if (keyPair == "picture")
                    {
                        @ViewBag.picture = pair.Value;
                    }
                    keyPair = pair.Key.ToLower();
                    if (keyPair == "gender")
                    {
                        @ViewBag.gender = pair.Value;
                    }
                    keyPair = pair.Key.ToLower();
                    if (keyPair == "locale")
                    {
                        @ViewBag.locale = pair.Value;
                    }
                    keyPair = pair.Key.ToLower();
                    if (keyPair == "hd")
                    {
                        @ViewBag.hd = pair.Value;
                    }
                }
            }
            string error = "";
            //Verify values account
            if (@ViewBag.id != null & @ViewBag.email != null & @ViewBag.verified_email != null & @ViewBag.name != null & @ViewBag.hd != null & @ViewBag.hd == "cloudmed.io")
            {
                Session["id"] = @ViewBag.id;
                Session["email"] = @ViewBag.email;
                Session["verified_email"] = @ViewBag.verified_email;
                Session["name"] = @ViewBag.name;
                Session["given_name"] = @ViewBag.given_name;
                Session["family_name"] = @ViewBag.family_name;
                Session["link"] = @ViewBag.link;
                Session["picture"] = @ViewBag.picture;
                Session["gender"] = @ViewBag.gender;
                Session["locale"] = @ViewBag.locale;
                Session["hd"] = @ViewBag.hd;
                return View("../Home/Index", null);
            }
            else
            {
                if (Convert.ToBoolean(@ViewBag.verified_email) == true & @ViewBag.hd != "cloudmed.io")
                    error = "Você entrou com sua conta google, mas ela não é cloudmed.io";
                else
                    error = "Conta google não autenticada, tente novamente!";
                Session["LoginError"] = error;
                IndexError();
                return View("IndexError");
            }
        }


        // GET: /Login Error/
        public ActionResult IndexError()
        {
            return View();
        }

    }
}
