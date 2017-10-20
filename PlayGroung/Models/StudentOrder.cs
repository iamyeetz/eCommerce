using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayGroung.Models
{
    public class StudentOrder
    {
        public int StudentOrderID { get; set; }

        public int studentID { get; set; }

        public int itemId { get; set; }

        public List<StudentOrder> GetAllStudentOrder()
        {
            List<StudentOrder> studentorder = new List<StudentOrder>();

            StudentOrder order = new StudentOrder
            {
                StudentOrderID = 1,
                studentID = 1,
                itemId = 2
             };
            studentorder.Add(order);

            StudentOrder order1 = new StudentOrder
            {
                StudentOrderID = 2,
                studentID = 2,
                itemId = 2
            };
            studentorder.Add(order1);


            return studentorder;

        }

    }
}