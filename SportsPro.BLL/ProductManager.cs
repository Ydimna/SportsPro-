using SportsPro.Data;
using SportsPro.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SportsPro.BLL
{
    public class ProductManager
    {
        //this method return list of products from the database
        public static IList<Product> GetAll()
        {
            var context = new SportsProContext();
            var products = context.Products.ToList();
            return products;
        }

        //Method to get only key value items to be populated in the dropdown lists
        public static IList GetProductAsKeyValuePairs()
        {
            var context = new SportsProContext();
            var products = context.Products.Select(p => new
            {
                Value = p.ProductID,
                Text = p.Name
            }).ToList();
            return products;
        }

        //this method add product from the database
        public static void AddProduct(Product product)
        {

            var context = new SportsProContext();
            context.Products.Add(product);
            context.SaveChanges();
        }

        //this method to find product from the database
        public static Product Find(int id)
        {
            var context = new SportsProContext();
            var product = context.Products.Find(id);
            return product;
        }

        //this method to Update product from the database
        public static void UpdateProduct(Product product)
        {
            var context = new SportsProContext();
            var originalProduct = context.Products.Find(product.ProductID);
            originalProduct.ProductCode = product.ProductCode;
            originalProduct.Name = product.Name;
            originalProduct.YearlyPrice = product.YearlyPrice;
            originalProduct.ReleaseDate = product.ReleaseDate;
            context.SaveChanges();

        }

        //this method to delete product from the database
        public static void DeleteProduct(Product product)
        {
            var context = new SportsProContext();
            context.Products.Remove(product);
            context.SaveChanges();
        }

    }
}
