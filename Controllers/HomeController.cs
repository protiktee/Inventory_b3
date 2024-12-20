﻿using Inventory_b3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Web;
using System.Web.Mvc;

namespace Inventory_b3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Equipment.EquipmentN baseEquipment = new Equipment.EquipmentN();
            //List<EquipmentN> equipment=baseEquipment.ListEquipment();
            //ViewBag.equipment = equipment;
            return View();
        }
        public ActionResult SaveEquipment(FormCollection frmCollection)
        {
            EquipmentN equipmentN = new EquipmentN();
            equipmentN.EquipmentName = frmCollection["txtEquipName"].ToString();
            equipmentN.Quantity = Convert.ToInt32(frmCollection["txtEquipQuantity"].ToString());
            equipmentN.ReceiveDate = DateTime.ParseExact(frmCollection["txtReceiveDate"].ToString(), "dd/MM/yyyy", null); 
            int returnResult= equipmentN.SaveEquipment();

            Session["OpMsg"] = "Failed";
            if (returnResult == 1)
                Session["OpMsg"] = "Saved Succesfully";

            return RedirectToAction("Index");
        }
        public ActionResult SaveAssignment(FormCollection frmCollection)
        {
            int returnResult = Employee.SaveAssingment(
                Convert.ToInt32(frmCollection["txtCustomerID"].ToString()), 
                Convert.ToInt32(frmCollection["txtEquipID"].ToString()), 
                Convert.ToInt32(frmCollection["txtEquiCount"].ToString())
                );

            Session["OpMsg"] = "Failed";
            if (returnResult == 1)
                Session["OpMsg"] = "Saved Succesfully";

            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public JsonResult GetName()//Home/GetName
        {
            List<Member> sds = new List<Member>();
            Member member=new Member();
            member.Name = "Member 1"; 
            sds.Add(member);

            member = new Member();
            member.Name = "Member 2";
            sds.Add(member);

            return Json(sds, JsonRequestBehavior.AllowGet);
        }
    }
}