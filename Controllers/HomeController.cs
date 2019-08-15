using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lost_woods.Models;

namespace lost_woods.Controllers
{
    public class HomeController : Controller
    {
        private List<Dictionary<string, object>> AllTrails
        {
            get
            {
                return DbConnector.Query("SELECT * FROM Trails;");
            }
        }
        
        public IActionResult Index()
        {
            return View(AllTrails);
        }

    [HttpGet]
        [Route("newtrail")]

        public IActionResult NewTrail()
        {
            return View("NewTrail");
        }

    [HttpPost("create")]
        public IActionResult Create(string name, string description, int length, int elevation, int longlat)
        {
            string insert = $"INSERT INTO Trails (name, description, length, elevation, longlat ) VALUES ('{name}', '{description}', '{length}', '{elevation}', '{longlat}');";
            DbConnector.Execute(insert);
            return RedirectToAction("Index");
        }

    [HttpGet("show/{id}")]


        public IActionResult show(int id)
        {
            string insert = $"SELECT * FROM Trails WHERE id = '{id}'";
            List<Dictionary<string, object>> trail = DbConnector.Query(insert);
            return View(trail);
        }


    [HttpGet("delete/{id}")]
        public IActionResult delete(int id)
        {
            string insert = $"DELETE FROM Trails WHERE id = '{id}'";
            DbConnector.Execute(insert);
            return RedirectToAction("Index");
        }





    }
}
