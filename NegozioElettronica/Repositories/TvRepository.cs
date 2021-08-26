using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegozioElettronica.Repositories
{
    class TvRepository
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb;" +
                                      "Initial Catalog = NegozioElettronica;" +
                                      "Integrated Security = true;";

        const string _discriminator = "Tv";
        public void Delete(Tv tv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Products where Id = @id";
                command.Parameters.AddWithValue("@id", tv.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Tv> Fetch()
        {

            List<Tv> tvs = new List<Tv>();
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
                    var inch = (int)reader["Inches"];
                    var id = (int)reader["Id"];

                    Tv tv = new Tv();
                    tvs.Add(tv);
                }
            }
            return tvs;
        }


        internal void Insert(Tv tv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "insert into Products values (@brand, @model, @qta, @gb, @t, @discriminator)";
                command.Parameters.AddWithValue("@brand", tv.Brand);
                command.Parameters.AddWithValue("@model", tv.Model);
                command.Parameters.AddWithValue("@qta", tv.Quantity);
                command.Parameters.AddWithValue("@inch", tv.Inches);
                 command.Parameters.AddWithValue("@discriminator", _discriminator);

                command.ExecuteNonQuery();

            }
        }
    }
}
