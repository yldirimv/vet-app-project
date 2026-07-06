using Dapper;
using Microsoft.Data.SqlClient;

namespace VetApi.Models
{
    public class Context
    {
        public static string connectionstring = @"Server=DESKTOP-V61E5E4\SQLEXPRESS;Database=VetApiDb;Trusted_Connection=True;TrustServerCertificate=True;";

        public static void ExecuteReturn(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection db = new SqlConnection(connectionstring))
            {
                db.Open();
                db.Execute(procadi, param, commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        public static IEnumerable<T> Listeleme<T>(string procadi, DynamicParameters param = null)
        {
            using (SqlConnection db = new SqlConnection(connectionstring))
            {
                db.Open();
                return db.Query<T>(procadi, param, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
