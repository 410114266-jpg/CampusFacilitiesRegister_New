using System;
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

        // VIEW ALL ISSUES
        public DataTable GetAllIssues()
        {
            using (SqlConnection con = new SqlConnection(dbConnection))
            {
                string query =
                    "SELECT * FROM FacilitiesIssues ORDER BY IssueID DESC";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }

        // ADD ISSUE
        public void AddIssue(FacilityIssue issue)
        {
            using (SqlConnection con = new SqlConnection(dbConnection))
            {
                string query = @"INSERT INTO FacilitiesIssues
                (Location, Category, Description, DateReported,
                Priority, Status, ReportedBy)
                VALUES
                (@Location, @Category, @Description, @DateReported,
                @Priority, @Status, @ReportedBy)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Location", issue.Location);
                cmd.Parameters.AddWithValue("@Category", issue.Category);
                cmd.Parameters.AddWithValue("@Description", issue.Description);
                cmd.Parameters.AddWithValue("@DateReported", issue.DateReported);
                cmd.Parameters.AddWithValue("@Priority", issue.Priority);
                cmd.Parameters.AddWithValue("@Status", issue.Status);
                cmd.Parameters.AddWithValue("@ReportedBy", issue.ReportedBy);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // UPDATE ISSUE
        public void UpdateIssue(FacilityIssue issue)
        {
            using (SqlConnection con = new SqlConnection(dbConnection))
            {
                string query = @"UPDATE FacilitiesIssues SET
                Location=@Location,
                Category=@Category,
                Description=@Description,
                DateReported=@DateReported,
                Priority=@Priority,
                Status=@Status,
                ReportedBy=@ReportedBy
                WHERE IssueID=@IssueID";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@IssueID", issue.IssueID);
                cmd.Parameters.AddWithValue("@Location", issue.Location);
                cmd.Parameters.AddWithValue("@Category", issue.Category);
                cmd.Parameters.AddWithValue("@Description", issue.Description);
                cmd.Parameters.AddWithValue("@DateReported", issue.DateReported);
                cmd.Parameters.AddWithValue("@Priority", issue.Priority);
                cmd.Parameters.AddWithValue("@Status", issue.Status);
                cmd.Parameters.AddWithValue("@ReportedBy", issue.ReportedBy);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DELETE ISSUE
        public void DeleteIssue(int issueID)
        {
            using (SqlConnection con = new SqlConnection(dbConnection))
            {
                string query =
                    "DELETE FROM FacilitiesIssues WHERE IssueID=@IssueID";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@IssueID", issueID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // SEARCH ISSUE
        public DataTable SearchIssues(string searchText)
        {
            using (SqlConnection con = new SqlConnection(dbConnection))
            {
                string query = @"SELECT * FROM FacilitiesIssues
                WHERE Location LIKE @Search
                OR Category LIKE @Search
                OR Description LIKE @Search
                OR Status LIKE @Search
                OR ReportedBy LIKE @Search";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@Search", "%" + searchText + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }
    }
}