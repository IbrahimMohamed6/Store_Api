using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.Identity;

namespace Store.Repository.ContextSeed
{
    public class StoreIdentityContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    Displayname="Hema",
                    Email="Hema@Gmail.Com",
                    UserName="HEmaMohamed",
                    Address=new Address()
                    {
                        FirstName="Ahmed",
                        LastName="Mohamed",
                        City="Mansoura",
                        Streate="25Moharmbj",
                        PostalCode="73673",
                       

                    }

                };
                await userManager.CreateAsync(user,"Password123!");
            }
        }
    }
}
