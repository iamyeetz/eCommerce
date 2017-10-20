using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.ViewModel
{
    public class ViewCustomerBasketModel
    {

        public int id { get; set; }
        public string imageurl { get; set; }
        public string description { get; set; }

        public int quantity { get; set; }

        public List<ViewCustomerBasketModel> ListShit { get; set; }

       // public List<BasketDetailList> BasketDetailList { get; set; }
    }

  
}
