using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete.Authentication;

public class AppRole:IdentityRole
{
    public AppRole(string roleName) : base()
    {
        Name = roleName;
    }
}
