using eCommerce.Contract.Repositories;
using eCommerce.Services;
using eCommerce.DAL.Data;
using eCommerce.DAL.Repositories;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using eCommerce.ViewModel;

namespace eCommerce.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepositoryBase<Customer> customers;
        IRepositoryBase<Product> products;
        IRepositoryBase<Basket> baskets;
        IRepositoryBase<BasketItem> basketItems;
        BasketService basketService;
        Guid id;
        ViewCustomerBasketModel viewCustomerBasketModel;

        public HomeController(IRepositoryBase<Customer> customers, IRepositoryBase<Product> products, IRepositoryBase<Basket> baskets, IRepositoryBase<BasketItem> basketItems)
        {

            this.customers = customers;
            this.products = products;
            this.baskets = baskets;
            this.basketItems = basketItems;
            this.basketService = new BasketService(this.baskets, this.basketItems);


        }

        public ActionResult Index()
        {

            var toShow = products.GetAll();

            return View(toShow);

        }

        public ActionResult ProductDetails(int id)
        {
            var toShow = products.GetById(id);

            return View(toShow);

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

        //Basket related

        public ActionResult AddToCart(int id)
        {
            //  baskets.GetById(id);
            basketService.AddToBasket(this.HttpContext, id, 1);

            return RedirectToAction("BasketSummary");
        }
        public ActionResult BasketSummary()
        {

            //    var toShow = basketItems.GetAll().Where(x => x.BasketItemId == 20);
            DataContext dbContext = new DataContext();

            var table = (from product in dbContext.Products
                         join basketitem in dbContext.BasketItems
                                         on product.ProductID equals basketitem.ProductId
                         select new ViewCustomerBasketModel()
                         {
                             id = product.ProductID,
                             description = product.Description,
                             imageurl = product.ImageURL,
                             quantity = basketitem.Quantity
                         }).ToList();



            viewCustomerBasketModel = new ViewCustomerBasketModel();
            viewCustomerBasketModel.ListShit = new List<ViewCustomerBasketModel>();
            viewCustomerBasketModel.ListShit = table;
            

            return View(viewCustomerBasketModel);



        }




    }





}
