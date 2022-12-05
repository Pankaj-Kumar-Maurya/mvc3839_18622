using mvc3839_18622.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc3839_18622.Controllers
{
    public class RegController : Controller
    {
        DatabaseContext _db = new DatabaseContext();
        public ActionResult Add(int id=0)
        {
            ViewBag.BT = "Create";
            tblreg obj = new tblreg();
            if(id>0)
            {
                var data = _db.tblregs.Where(x=>x.id==id).ToList();
                obj.id = data[0].id;
                obj.name = data[0].name;
                obj.email = data[0].email;
                obj.password = data[0].password;
                obj.salary = data[0].salary;
                ViewBag.BT = "Update";
            }
            return View(obj);
        }
        [HttpPost]
        public ActionResult Add(tblreg _reg)
        {
            if(_reg.id>0)
            {
                _db.Entry(_reg).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
            _db.tblregs.Add(_reg);
            }
            _db.SaveChanges();
            return RedirectToAction("Show");
        }

        public ActionResult Delete(int id=0)
        {
            var data = _db.tblregs.Find(id);
            _db.tblregs.Remove(data);
            _db.SaveChanges();
            return RedirectToAction("Show");
        }

        public ActionResult Show()
        {
           var data= _db.tblregs.ToList();
            return View(data);
        }
    }
}