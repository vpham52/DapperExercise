using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using Dapper;

namespace DapperExercise;
class Program
{
    static void Main(string[] args)
    {
        var config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

        string connString = config.GetConnectionString("DefaultConnection");

        IDbConnection conn = new MySqlConnection(connString);

        var repo = new DapperDepartmentRepository(conn);

        var departments = repo.GetAllDepartments();

        Console.WriteLine("All Departments\n");
        foreach (var dept in departments)
        {
            Console.WriteLine(dept.Name);
        }


        Console.WriteLine("Please enter a new Department name");
        var newDeptName = Console.ReadLine();

        repo.InsertDepartment(newDeptName);

        //get updated dept list
        departments = repo.GetAllDepartments();

        Console.WriteLine("All Departments\n");
        foreach (var dept in departments)
        {
            Console.WriteLine(dept.Name);
        }


        var prodRepo = new DapperProductRepository(conn);
        var products = prodRepo.GetAllProducts();

        foreach (var prod in products)
        {
            Console.WriteLine($"{prod.ProductID} - {prod.Name}");
        }


        //New Product
        Console.WriteLine("What is the name of your new product?");
        var productName = Console.ReadLine();

        Console.WriteLine("What is the price?");
        var productPrice = double.Parse(Console.ReadLine());

        Console.WriteLine("What is the categoryID?");
        var prodCat = int.Parse(Console.ReadLine());

        prodRepo.CreateProduct(productName, productPrice, prodCat);


        //Update Product Method
        Console.WriteLine("What ProductID would you like to update?");
        var prodID = int.Parse(Console.ReadLine());

        Console.WriteLine("What is the new product name?");
        var newName = Console.ReadLine();

        prodRepo.UpdateProduct(prodID, newName);

        //Update Delete Product Method
        Console.WriteLine("What is the productID you'd like to delete?");
        prodID = int.Parse(Console.ReadLine());

        prodRepo.DeleteProduct(prodID);


    }
}

