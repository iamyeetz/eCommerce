using PlayGroung.Models;
using PlayGroung.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace PlayGroung.Controllers
{
    public class HomeController : Controller
    {
        Items item = new Items();
        Student student = new Student();
        StudentOrder order = new StudentOrder();
        StudentOrderViewModel StudentOrder = new StudentOrderViewModel();
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            // using lamda
            //var table = item.GetItemList().Where(a => a.type == "Food").ToList();



            //using sql like query
            //IEnumerable<Items> toShow = from a in item.GetItemList()
            //                            where a.type == "Drinks"
            //                            select a;



            //with Join
            var table = (from a in order.GetAllStudentOrder()
                        join b in student.GetAllStudent()
                        on a.studentID equals b.StudentId
                        join c in item.GetItemList()
                        on a.itemId equals c.id
                        select new StudentOrderViewModel
                        {
                            Id = a.StudentOrderID,
                            StudentName = b.Name,
                            Order = c.description

                        }).ToList();

            StudentOrderViewModel OrderList = new StudentOrderViewModel();
            StudentOrder.studentOrder = new List<StudentOrderViewModel>();
            StudentOrder.studentOrder = table;
            



            return View(StudentOrder);
        }


    }
}