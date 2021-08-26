using NegozioElettronica.DBManager;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Entities
{
    public class LaptopRepository : ILaptopDBManger
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                      "Initial Catalog = NegozioElettronica;" +
                                      "Integrated Security = true;";

        const string _discriminator = "Laptop";
        public void Delete(Laptop laptop)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Products where Id = @id";
                command.Parameters.AddWithValue("@id", laptop.Id);

                command.ExecuteNonQuery();
            }
        }

        public  List<Laptop> Fetch()
        {

            List<Laptop> laptops = new List<Laptop>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Products where Discriminator = @discriminator";
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var brand = (string)reader["Brand"];
                    var model = (string)reader["Model"];
                    var op = (string)reader["OpSystem"];
                    var qta = (int)reader["Quantity"];
                    var t = (bool)reader["Touch"];
                    var id = (int)reader["Id"];

                    Laptop laptop = new Laptop();
                    laptops.Add(laptop);
                }
            }
            return laptops;
        }


        internal void Insert(Laptop laptop)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "insert into Products values (@brand, @model, @qta, @op, @t, @discriminator)";
                command.Parameters.AddWithValue("@brand", laptop.Brand);
                command.Parameters.AddWithValue("@model", laptop.Model);                 
                command.Parameters.AddWithValue("@qta", laptop.Quantity);
                command.Parameters.AddWithValue("@op", laptop.OpSystem);
                command.Parameters.AddWithValue("@t", DBNull.Value);
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                command.ExecuteNonQuery();

            }
        }
    }
}
