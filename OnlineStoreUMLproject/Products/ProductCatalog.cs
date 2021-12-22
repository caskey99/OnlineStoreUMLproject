using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStoreUMLproject.Products
{
    class ProductCatalog
    {
        public List<Product> productList;
        public int numProducts;
        
        public ProductCatalog() { numProducts = 0; productList = new List<Product>(); }
        public void addItem(Product product)
        {
            productList.Add(product);
            numProducts++;
        }

        public void addParty(List<Product> productParty)
        {
            productList.AddRange(productParty);
            numProducts += productParty.Count;
        }



        //GET
        public Product getItem(int id)
        {
            var find = productList.Find(x => x.ID == id);
            //if (find != null)
            //    throw new Exception("find == null!"); 
            return find;
        }

        public void remItem(int id)
        {
            productList.Remove(productList.Find(x => x.ID == id));
            numProducts--;
        }
    }
}
