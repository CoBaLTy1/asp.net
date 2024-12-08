using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using working.Models; // Reference the proper namespace for ClientInfo.

namespace working.Views.Home
{
    public class CreateModel : PageModel
    {
        public ClientInfo ClientInfo { get; set; } = new ClientInfo();
        public string ErrorMessage { get; set; } = "";
        public string SuccessMessage { get; set; } = "";

        public void OnGet()
        {
            // Handle GET requests (e.g., initializing the form).
        }

        public void OnPost()
        {
            // Retrieve form data from the request.
            ClientInfo.Name = Request.Form["name"];
            ClientInfo.Email = Request.Form["email"];
            ClientInfo.Phone = Request.Form["phone"];
            ClientInfo.Address = Request.Form["address"];

            // Validate required fields.
            if (string.IsNullOrEmpty(ClientInfo.Name) ||
                string.IsNullOrEmpty(ClientInfo.Email) ||
                string.IsNullOrEmpty(ClientInfo.Phone) ||
                string.IsNullOrEmpty(ClientInfo.Address))
            {
                ErrorMessage = "All fields are required.";
                return;
            }

            // Reset the form and display a success message.
            SuccessMessage = "New Client Added Successfully!";
            ClientInfo = new ClientInfo(); // Resetting the client info object.
        }
    }
}

namespace working.Models
{
    public class ClientInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
