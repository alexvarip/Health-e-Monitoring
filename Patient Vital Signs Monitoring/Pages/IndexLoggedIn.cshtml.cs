using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexLoggedInModel : PageModel
{
    private readonly UserManager<IdentityUser> _userManager;

    public string Email { get; set; }

    public IndexLoggedInModel(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task OnGetAsync()
    {
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            var user = await _userManager.GetUserAsync(User);
            Email = user?.Email ?? "Not available";
        }
    }
}