using Inspection.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inspection.Startup))]
namespace Inspection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }


        // Create default User roles and System Admin user for login   
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // Creating Admin Role and default user. 
            if (!RoleManager.RoleExists("Admin"))
            {
                // Create an admin role. 
                var Role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                Role.Name = "Admin";
                RoleManager.Create(Role);

                // Create an admin user who will maintain the website 
                var User = new ApplicationUser();
                User.UserName = "admin";
                User.Email = "admin@gmail.com";

                string UserPwd = "123321";

                var CheckUser = UserManager.Create(User, UserPwd);

                if (CheckUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(User.Id, "Admin");

                }
            }

            // Create Manager role.    
            if (!RoleManager.RoleExists("Manager"))
            {
                var Role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                Role.Name = "Manager";
                RoleManager.Create(Role);
            }

            // Creating Supervisor role   
            if (!RoleManager.RoleExists("Supervisor"))
            {
                var Role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                Role.Name = "Supervisor";
                RoleManager.Create(Role);

            }

            // Creating Inspector role      
            if (!RoleManager.RoleExists("Inspector"))
            {
                var Role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                Role.Name = "Inspector";
                RoleManager.Create(Role);

            }
        }
    }
}
