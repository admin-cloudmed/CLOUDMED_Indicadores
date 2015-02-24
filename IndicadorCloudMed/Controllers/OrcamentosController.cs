﻿using System;
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
    public class OrcamentosController : Controller
    {

        IndicadorCloudMedEntities Database = new IndicadorCloudMedEntities();

        public ActionResult Index()
        {
            if (Session["id"] != null & Session["email"] != null & Session["verified_email"] != null & Session["name"] != null & Session["hd"] != null) 
            {
                var Empresas = Database.Orcamentos.Select(i => new { i.IdEmpresa, i.NomeEmpresa }).Distinct().OrderBy(i => i.IdEmpresa);
                ViewBag.Empresas = new SelectList(Empresas, "IdEmpresa", "NomeEmpresa");
                ViewBag.TotalOrcamentos = Database.Orcamentos.Select(i => new { i.Quantidade }).Sum(i => (int?)i.Quantidade) ?? 0;
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



        public JsonResult AutoCompleteTotalOrcamentos(int idempresa)
        {
            long result = 0;
            if (idempresa == 0)
            {
                result = Database.Orcamentos.Select(i => new { i.Quantidade }).Sum(i => (int?)i.Quantidade) ?? 0;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                result = Database.Orcamentos.Where(c => c.IdEmpresa == idempresa).Select(i => new { i.Quantidade }).Sum(i => (int?)i.Quantidade) ?? 0;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }



        //public JsonResult AutoCompleteTotalOrcamentos(int idempresa, string data1, string data2)
        //{
        //    int result = 0;
        //    if (idempresa == 0)
        //    {
        //        if ((data1.Replace("_", "").Replace("/", "") != "") && ((data1.Replace("_", "").Replace("/", "").Length == 8)))
        //        {
        //            DateTime entityData1 = DateTime.Parse(data1);
        //            if ((data2.Replace("_", "").Replace("/", "") != "") && ((data2.Replace("_", "").Replace("/", "").Length == 8)))
        //            {
        //                DateTime entityData2 = DateTime.Parse(data2);
        //                entityData2 = entityData2.AddHours(23);
        //                entityData2 = entityData2.AddMinutes(59);
        //                entityData2 = entityData2.AddSeconds(59);
        //                entityData2 = entityData2.AddMilliseconds(999);
        //                result = Database.Orcamentos.Where(c => c.DataPedidoOrcamento >= entityData1 && c.DataPedidoOrcamento <= entityData2).Select(i => new { i.IdEmpresa }).Count(); //data um e data dois
        //            }
        //            else
        //            {
        //                result = Database.Orcamentos.Where(c => c.DataPedidoOrcamento >= entityData1).Select(i => new { i.IdEmpresa }).Count(); // data um
        //            }
        //        }
        //        else
        //        {
        //            if ((data2.Replace("_", "").Replace("/", "") != "") && ((data2.Replace("_", "").Replace("/", "").Length == 8)))
        //            {
        //                DateTime entityData1 = DateTime.Parse("01/01/1990");
        //                DateTime entityData2 = DateTime.Parse(data2);
        //                entityData2 = entityData2.AddHours(23);
        //                entityData2 = entityData2.AddMinutes(59);
        //                entityData2 = entityData2.AddSeconds(59);
        //                entityData2 = entityData2.AddMilliseconds(999);
        //                result = Database.Orcamentos.Where(c => c.DataPedidoOrcamento >= entityData1 && c.DataPedidoOrcamento <= entityData2).Select(i => new { i.IdEmpresa }).Count(); //data um e data dois
        //            }
        //            else
        //            {
        //                result = Database.Orcamentos.Select(i => new { i.IdEmpresa }).Count();
        //            }
        //        }
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //    {
        //        if ((data1.Replace("_", "").Replace("/", "") != "") && ((data1.Replace("_", "").Replace("/", "").Length == 8)))
        //        {
        //            DateTime entityData1 = DateTime.Parse(data1);
        //            if ((data2.Replace("_", "").Replace("/", "") != "") && ((data2.Replace("_", "").Replace("/", "").Length == 8)))
        //            {
        //                DateTime entityData2 = DateTime.Parse(data2);
        //                entityData2 = entityData2.AddHours(23);
        //                entityData2 = entityData2.AddMinutes(59);
        //                entityData2 = entityData2.AddSeconds(59);
        //                entityData2 = entityData2.AddMilliseconds(999);
        //                result = Database.Orcamentos.Where(c => c.DataPedidoOrcamento >= entityData1 && c.DataPedidoOrcamento <= entityData2 && c.IdEmpresa == idempresa).Select(i => new { i.IdEmpresa }).Count(); //data 1 e data dois
        //            }
        //            else
        //            {
        //                result = Database.Orcamentos.Where(c => c.DataPedidoOrcamento >= entityData1 && c.IdEmpresa == idempresa).Select(i => new { i.IdEmpresa }).Count(); // data2 um
        //            }
        //        }
        //        else
        //        {
        //            if ((data2.Replace("_", "").Replace("/", "") != "") && ((data2.Replace("_", "").Replace("/", "").Length == 8)))
        //            {
        //                DateTime entityData1 = DateTime.Parse("01/01/1990");
        //                DateTime entityData2 = DateTime.Parse(data2);
        //                entityData2 = entityData2.AddHours(23);
        //                entityData2 = entityData2.AddMinutes(59);
        //                entityData2 = entityData2.AddSeconds(59);
        //                entityData2 = entityData2.AddMilliseconds(999);
        //                result = Database.Orcamentos.Where(c => c.DataPedidoOrcamento >= entityData1 && c.DataPedidoOrcamento <= entityData2 && c.IdEmpresa == idempresa).Select(i => new { i.IdEmpresa }).Count(); //data um e data dois
        //            }
        //            else
        //            {
        //                result = Database.Orcamentos.Where(c => c.IdEmpresa == idempresa).Select(i => new { i.IdEmpresa }).Count();
        //            }
        //        }
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //}


    }
}