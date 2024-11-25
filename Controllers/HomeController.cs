using Inventory_b3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Equipment;

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
    }
}