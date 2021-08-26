using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Repositories
{
    class MobileRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                      "Initial Catalog = NegozioElettronica;" +
                                      "Integrated Security = true;";

        const string _discriminator = "Mobile";
        public void Delete(Mobile mobile)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Products where Id = @id";
                command.Parameters.AddWithValue("@id", mobile.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Mobile> Fetch()
        {

            List<Mobile> mobiles = new List<Mobile>();
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
                    var qta = (int)reader["Quantity"];
                    var gb = (int)reader["Storage"];
                    var id = (int)reader["Id"];

                    Mobile mobile = new Mobile();
                    mobiles.Add(mobile);
                }
            }
            return mobiles;
        }


        internal void Insert(Mobile mobile)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "insert into Products values (@brand, @model, @qta, @gb, @t, @discriminator)";
                command.Parameters.AddWithValue("@brand", mobile.Brand);
                command.Parameters.AddWithValue("@model", mobile.Model);
                command.Parameters.AddWithValue("@qta", mobile.Quantity);
                command.Parameters.AddWithValue("@gb", mobile.Storage);
                command.Parameters.AddWithValue("@discriminator", _discriminator);

                command.ExecuteNonQuery();

            }
        }
    }
}
