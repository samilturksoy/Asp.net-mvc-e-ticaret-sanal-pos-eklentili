using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Starkk.Models;

[assembly: OwinStartupAttribute(typeof(Starkk.Startup))]
namespace Starkk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoleandUsers();
        }

        private void createRoleandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //program acılınca direk admin kullanıcısı ve rolü oluşturuyoruz.
            if (!roleManager.RoleExists("Admin"))
            {
                //önce admin rolü

                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //admin ve süper kullanıcıyı oluşturuyoruz web sitenin sahibi

                var user = new ApplicationUser();
                user.UserName = "info@starkmss.com";
                user.Email = "info@starkmss.com";

                string userPWD = "Stark@48";
                var chkUser = userManager.Create(user, userPWD);


                //oluşan kullanıcya admin rolünü set ediyoruz.

                if (chkUser.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, "Admin");
                }

            }

            //kullanıcı rolu oluştur.

            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }

            //bayi rolü oluştur

            if (!roleManager.RoleExists("Bayi"))
            {
                var role = new IdentityRole();
                role.Name = "Bayi";
                roleManager.Create(role);

            }
        }
    }
}
