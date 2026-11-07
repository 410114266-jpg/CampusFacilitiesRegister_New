using System.Data;
using System.Data.SqlClient;

namespace CampusFacilitiesRegister
{
    public class IssueRepository
    {
        private readonly string dbConnection =
            @"Data Source=(localdb)\MSSQLLocalDB;
              Initial Catalog=CampusFacilitiesDB;
              Integrated Security=True;";

        private SqlConnection OpenConnection()
        {
            return new SqlConnection(dbConnection);
        }
    }
}