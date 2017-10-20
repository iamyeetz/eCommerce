using eCommerce.Contract.Repositories;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eCommerce.Services
{
   public class BasketService
    {
        public IRepositoryBase<Basket> baskets;
        public IRepositoryBase<BasketItem> BasketItems;
        public const string BasketSessionName = "eCommerceBasket";

        public BasketService(IRepositoryBase<Basket> baskets, IRepositoryBase<BasketItem> BasketItems)
        {
            this.baskets = baskets;
            this.BasketItems = BasketItems;
        }

        public bool AddToBasket(HttpContextBase httpContext,int productid,int quantity)
        {
            bool success;

            Basket basket = getBasket(httpContext);

            // Not sure if GetBasket always returns a value so checking for NULLs 
            if (basket != null && basket.BasketItems != null && basket.BasketItems.Any())
            {
                BasketItem item = basket.BasketItems.FirstOrDefault(i => i.ProductId == productid);

                if (item == null)
                {
                    item = new BasketItem()
                    {
                        BasketId = basket.BasketId,
                        ProductId = productid,
                        Quantity = quantity
                    };
                    basket.BasketItems.Add(item);
                }
                else
                {
                    item.Quantity = item.Quantity + quantity;
                }

                baskets.Commit();

                success = true;
            }
            else
            {
                // Basket is null or BasketItems does not contain any items. 
                // You could return an error message specifying that if needed.
                BasketItem item;
                item = new BasketItem()
                {
                    BasketId = basket.BasketId,
                    ProductId = productid,
                    Quantity = quantity
                };
                BasketItems.Insert(item);
                BasketItems.Commit();
                success = false;
            }
            return success;
        }


        private Basket getBasket(HttpContextBase httpContext)
        {
            HttpCookie cookie = httpContext.Request.Cookies.Get(BasketSessionName);
            Basket basket;

            Guid BasketId;

            if (cookie != null)
            {
                if(Guid.TryParse(cookie.Value,out BasketId))
                {
                    basket = baskets.GetById(BasketId);
                }
                else
                {
                    basket = createNewBasket(httpContext);
                }
            }
            else
            {

                basket = createNewBasket(httpContext);
            }

            return basket;
        }

        private Basket createNewBasket(HttpContextBase httpContext)
        {
            //create a new cookie

            this.baskets = baskets;
            HttpCookie cookie = new HttpCookie(BasketSessionName);

            //create new basket and set creation date



            var basket = new Basket()
            {
                BasketId = Guid.NewGuid(),
                date = DateTime.Now,

            };

            baskets.Insert(basket);
            baskets.Commit();

            cookie.Value = basket.BasketId.ToString();
            cookie.Expires = DateTime.Now.AddDays(1);
            httpContext.Response.Cookies.Add(cookie);

            return basket;
        }
    }
}
