using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayGroung.ViewModels
{
    public class StudentOrderViewModel
    {

        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Order { get; set; }


        public List<StudentOrderViewModel> studentOrder { get; set; }
    }
}