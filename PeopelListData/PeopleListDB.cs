using System.Data.SqlClient;
using System.Reflection;

namespace PeopelListData
{

    public class PeopleListDB
    {
        public string _connectionString { get; set; }
        public PeopleListDB(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<People> SelectAll()
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select * from People Order By LastName";


            connection.Open();
            List<People> people = new List<People>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new People
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"],
                   
                });
            }

            return people;

        }
        public void AddPerson(People p)
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            
                cmd.CommandText = @"insert into People(FirstName, LastName, Age)
                                values(@firstName, @lastName, @age); ";
                cmd.Parameters.AddWithValue("@firstname", p.FirstName);

                cmd.Parameters.AddWithValue("@lastName", p.LastName);
                cmd.Parameters.AddWithValue("@age", p.Age);
           

                connection.Open();
                cmd.ExecuteNonQuery();
            
        }
        public void AddMany(List<People> people)
        {
            foreach (var person in people)
            {
                AddPerson(person);
            }
        }

    }
}