using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using IndicadorGedWeb.Models;
using Newtonsoft.Json;


namespace IndicadorGedWeb.Controllers
{
    public class DocumentosController : Controller
    {

        IndicadorCloudMedEntities Database = new IndicadorCloudMedEntities();

        public ActionResult Index()
        {
            if (Session["id"] != null & Session["email"] != null & Session["verified_email"] != null & Session["name"] != null & Session["hd"] != null) 
            {
                var Empresas = Database.Documentos.Select(i => new { i.IdEmpresa, i.NomeEmpresa }).Distinct().OrderBy(i => i.IdEmpresa);
                ViewBag.Empresas = new SelectList(Empresas, "IdEmpresa", "NomeEmpresa");
                ViewBag.TotalDocumentos = Database.Documentos.Select(i => new { i.IdEmpresa }).Count();
                return View();
            }
            else
            {
                Session["id"] = null;
                Session["email"] = null;
                Session["verified_email"] = null;
                Session["name"] = null;
                Session["given_name"] = null;
                Session["family_name"] = null;
                Session["link"] = null;
                Session["picture"] = null;
                Session["gender"] = null;
                Session["locale"] = null;
                Session["hd"] = null;
                Session["LoginError"] = "Ops, algo de errado aconteceu. Por favor, faça login novamente!";
                LoginController login = new LoginController();
                login.IndexError();
                return View("../Login/IndexError");
            }
        }

        public JsonResult AutoCompleteTotalDocumentos(int idempresa)
        {
            long result = 0;
            if (idempresa == 0)
            {
                result = Database.Documentos.Select(i => new { i.Quantidade }).Sum(i => (int?)i.Quantidade) ?? 0;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result = Database.Documentos.Where(c => c.IdEmpresa == idempresa).Select(i => new { i.Quantidade }).Sum(i => (int?)i.Quantidade) ?? 0;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }


        //        public JsonResult AutoCompleteTotalDocumentos(int idempresa, string data1, string data2)
        //        {
        //            int result = 0;
        //            if (idempresa == 0)
        //            {
        //                if ((data1.Replace("_", "").Replace("/", "") != "") && ((data1.Replace("_", "").Replace("/", "").Length == 8)))
        //                {
        //                    DateTime entityData1 = DateTime.Parse(data1);
        //                    if ((data2.Replace("_", "").Replace("/", "") != "") && ((data2.Replace("_", "").Replace("/", "").Length == 8)))
        //                    {
        //                        DateTime entityData2 = DateTime.Parse(data2);
        //                        entityData2 = entityData2.AddHours(23);
        //                        entityData2 = entityData2.AddMinutes(59);
        //                        entityData2 = entityData2.AddSeconds(59);
        //                        entityData2 = entityData2.AddMilliseconds(999);
        //                        result = Database.Documentos.Where(c => c.docDataArquivamento >= entityData1 && c.docDataArquivamento <= entityData2).Select(i => new { i.IdEmpresa }).Count(); //data um e data dois
        //                    }
        //                    else
        //                    {
        //                        result = Database.Documentos.Where(c => c.docDataArquivamento >= entityData1).Select(i => new { i.IdEmpresa }).Count(); // data um
        //                    }
        //                }
        //                else
        //                {
        //                    if ((data2.Replace("_", "").Replace("/", "") != "") && ((data2.Replace("_", "").Replace("/", "").Length == 8)))
        //                    {
        //                        DateTime entityData1 = DateTime.Parse("01/01/1990");
        //                        DateTime entityData2 = DateTime.Parse(data2);
        //                        entityData2 = entityData2.AddHours(23);
        //                        entityData2 = entityData2.AddMinutes(59);
        //                        entityData2 = entityData2.AddSeconds(59);
        //                        entityData2 = entityData2.AddMilliseconds(999);
        //                        result = Database.Documentos.Where(c => c.docDataArquivamento >= entityData1 && c.docDataArquivamento <= entityData2).Select(i => new { i.IdEmpresa }).Count(); //data um e data dois
        //                    }
        //                    else
        //                    {
        //                        result = Database.Documentos.Select(i => new { i.IdEmpresa }).Count();
        //                    }
        //                }
        //                return Json(result, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                if ((data1.Replace("_", "").Replace("/", "") != "") && ((data1.Replace("_", "").Replace("/", "").Length == 8)))
        //                {
        //                    DateTime entityData1 = DateTime.Parse(data1);
        //                    if ((data2.Replace("_", "").Replace("/", "") != "") && ((data2.Replace("_", "").Replace("/", "").Length == 8)))
        //                    {
        //                        DateTime entityData2 = DateTime.Parse(data2);
        //                        entityData2 = entityData2.AddHours(23);
        //                        entityData2 = entityData2.AddMinutes(59);
        //                        entityData2 = entityData2.AddSeconds(59);
        //                        entityData2 = entityData2.AddMilliseconds(999);
        //                        result = Database.Documentos.Where(c => c.docDataArquivamento >= entityData1 && c.docDataArquivamento <= entityData2 && c.IdEmpresa == idempresa).Select(i => new { i.IdEmpresa }).Count(); //data 1 e data dois
        //                    }
        //                    else
        //                    {
        //                        result = Database.Documentos.Where(c => c.docDataArquivamento >= entityData1 && c.IdEmpresa == idempresa).Select(i => new { i.IdEmpresa }).Count(); // data2 um
        //                    }
        //                }
        //                else
        //                {
        //                    if ((data2.Replace("_", "").Replace("/", "") != "") && ((data2.Replace("_", "").Replace("/", "").Length == 8)))
        //                    {
        //                        DateTime entityData1 = DateTime.Parse("01/01/1990");
        //                        DateTime entityData2 = DateTime.Parse(data2);
        //                        entityData2 = entityData2.AddHours(23);
        //                        entityData2 = entityData2.AddMinutes(59);
        //                        entityData2 = entityData2.AddSeconds(59);
        //                        entityData2 = entityData2.AddMilliseconds(999);
        //                        result = Database.Documentos.Where(c => c.docDataArquivamento >= entityData1 && c.docDataArquivamento <= entityData2 && c.IdEmpresa == idempresa).Select(i => new { i.IdEmpresa }).Count(); //data um e data dois
        //                    }
        //                    else
        //                    {
        //                        result = Database.Documentos.Where(c => c.IdEmpresa == idempresa).Select(i => new { i.IdEmpresa }).Count();
        //                    }
        //                }
        //                return Json(result, JsonRequestBehavior.AllowGet);
        //            }
        //        }


        //        public string InsertDocumento(string jsonData)
        //        {
        //            string json = "{\"status\" : \"0\"}";
        //            if (jsonData != null)
        //            {
        //                MemoryStream jsonReturned = new MemoryStream(Encoding.Default.GetBytes(jsonData));
        //                StreamReader sr = new StreamReader(jsonReturned);
        //                Dictionary<string, string> registration = JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());
        //                Documentos doc = new Documentos();
        //                foreach (KeyValuePair<string, string> pair in registration)
        //                {
        //                    var keyPair = pair.Key;
        //                    if (keyPair.Contains("IdEmpresa"))
        //                    {
        //                        doc.IdEmpresa = Convert.ToInt32(pair.Value);
        //                    }
        //                    if (keyPair.Contains("NomeEmpresa"))
        //                    {
        //                        doc.NomeEmpresa = pair.Value;
        //                    }
        //                    if (keyPair.Contains("docNumSerie"))
        //                    {
        //                        doc.docNumSerie = Convert.ToInt64(pair.Value);
        //                    }
        //                    if (keyPair.Contains("docTitulo"))
        //                    {
        //                        doc.docTitulo = pair.Value;
        //                    }
        //                    if (keyPair.Contains("docDataArquivamento"))
        //                    {
        //                        doc.docDataArquivamento = Convert.ToDateTime(pair.Value);
        //                    }
        //                    if (keyPair.Contains("docQtdePag"))
        //                    {
        //                        doc.docQtdePag = Convert.ToInt32(pair.Value);
        //                    }
        //                    if (keyPair.Contains("docProprietario"))
        //                    {
        //                        doc.docProprietario = pair.Value;
        //                    }
        //                    if (keyPair.Contains("docStatus"))
        //                    {
        //                        doc.docStatus = Convert.ToInt32(pair.Value);
        //                    }
        //                    if (keyPair.Contains("docTamanho"))
        //                    {
        //                        doc.docTamanho = Convert.ToInt32(pair.Value);
        //                    }
        //                    if (keyPair.Contains("docFileNameDocumento"))
        //                    {
        //                        doc.docFileNameDocumento = pair.Value;
        //                    }
        //                    if (keyPair.Contains("docExtensaoArquivo"))
        //                    {
        //                        doc.docExtensaoArquivo = pair.Value;
        //                    }
        //                    if (keyPair.Contains("docNomeOriginalArquivo"))
        //                    {
        //                        doc.docNomeOriginalArquivo = pair.Value;
        //                    }
        //                }
        //                try
        //                {
        //                    Database.Documentos.Add(doc);
        //                    Database.SaveChanges();
        //                    json = "{\"status\" : \"1\"}";
        //                }
        //                catch (Exception)
        //                {
        //                    json = "{\"status\" : \"0\"}";
        //                }
        //            }
        //            return json;
        //        }


    }
}
