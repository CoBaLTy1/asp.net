using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace working.Views.Home
{
    public class Index1Model : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();

        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ardak\\Documents\\firstDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";

                using (SqlConnection connection = new SqlConnection(connectionString)) // Corrected variable name
                {
                    connection.Open();
                    string sql = "SELECT * FROM clients";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = reader.GetInt32(0).ToString(); // Fixed case and added ToString conversion
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.address = reader.GetString(4);
                                clientInfo.created_at = reader.GetDateTime(5).ToString();

                                listClients.Add(clientInfo); // Add to list
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error or handle it
                Console.WriteLine(ex.Message); // Example log
            }
        }
    }

    public class ClientInfo
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string created_at { get; set; }
    }
}
