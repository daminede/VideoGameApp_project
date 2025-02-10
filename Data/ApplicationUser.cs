using Microsoft.AspNetCore.Identity;

namespace VideoGameApp.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty; // Inițializare implicită
        public string ApiKey { get; set; } = string.Empty; // Inițializare implicită

        // Constructor implicit
        public ApplicationUser() { }

        // Constructor cu parametri (opțional)
        public ApplicationUser(string fullName, string apiKey)
        {
            FullName = fullName;
            ApiKey = apiKey;
        }
    }


}
