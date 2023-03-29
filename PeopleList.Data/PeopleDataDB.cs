namespace PeopleList.Data
{
    public class PeopleDataDB
    {
        public string _connectionString { get; set; }
        public PeopleDataDB(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Listing> SelectAll()
        {

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"select * from Listings Order by DateCreated DESC";




            connection.Open();
            List<Listing> listings = new List<Listing>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listings.Add(new Listing
                {
                    Id = (int)reader["Id"],
                    DateCreated = (DateTime)reader["DateCreated"],
                    Description = (string)reader["Description"],
                    Name = reader.GetOrNull<string>("Name"),
                    PhoneNumber = (string)reader["PhoneNumber"],

                });
            }

            return listings;

        }
    }
}