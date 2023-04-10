using System;
using System.Data.Common;

namespace DapperExercise
{
	public interface IProductRepository
	{

        public IEnumerable<Product> GetAllProducts();

        public void CreateProduct(string name, double price, int categoryID);

        public void UpdateProduct(int newProductID, string updatedName);

        public void DeleteProduct(int productID);
      

    }

}

	

	




