using eCommerce.DAL.Data;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.DAL.Repositories
{
    public class BasketItemRepository : RepositoryBase<BasketItem> 
    {
        internal DataContext context;
        internal List<BasketItem> dbSet;
        public BasketItemRepository(DataContext context) : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }

        public void Save(BasketItem item)
        {
            context.BasketItems.Add(item);
            context.SaveChanges();
        }
  
    }
}
