﻿using System;
namespace DapperExercise
{
	public class Product
	{
		public Product()
		{
		}

        public int ProductID { get; set; }
		public string Name { get; set; }
		public double Price { get; set; }
		public string CategoryID { get; set; }
		public int OnSale { get; set; }
		public string StockLevel { get; set; }

    }
}

