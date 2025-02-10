using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VideoGameApp.Data;

namespace VideoGameApp.Auth
{
    public class AuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtService _jwtService;

        public AuthenticationService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, JwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtService = jwtService;
        }

        public async Task<string> RegisterAsync(RegisterModel model)
        {
            var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return string.Join(", ", result.Errors);

            return "User registered successfully!";
        }

        public async Task<string> LoginAsync(LoginModel model)
        {

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
                return "Invalid username or password.";

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
            if (!result.Succeeded)
                return "Invalid username or password.";

            return _jwtService.GenerateToken(user.UserName);
        }
    }
}
