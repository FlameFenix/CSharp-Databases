using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace ADO.NET
{
    class StartUp
    {
        static async Task Main(string[] args)
        {

            SqlConnection conn = new SqlConnection(Configuration.connectionString);

            using (conn)
            {
                await conn.OpenAsync();

                await SelectFromEmplyeesAsync(conn, Queries.SELECT_FROM_EMPLOYEES);
            }

        }

        private static async Task SelectFromEmplyeesAsync(SqlConnection conn, string querry)
        {
            SqlCommand cmd = new SqlCommand(Queries.SELECT_FROM_EMPLOYEES, conn);

            SqlDataReader reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                Console.WriteLine(@$"Full Name: '{reader["FirstName"]}{(string.IsNullOrEmpty(reader["MiddleName"].ToString()) ? "" : $" {reader["MiddleName"]}")} {reader["LastName"]}' with salary: {reader["Salary"]}");
            }
        }

    }
}
