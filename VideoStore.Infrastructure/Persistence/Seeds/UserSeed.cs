using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoStore.Application.Entities;

namespace VideoStore.Infrastructure.Persistence.Seeds
{
    public static class UserSeed
    {
        public static List<User> Seed()
        {
            var usersDefault = new List<User>()
            {
               new User(1,"Admin","admin@admin.com","6f2cb9dd8f4b65e24e1c3f3fa5bc57982349237f11abceacd45bbcb74d621c25","admin"),
               new User(2,"User","user@user.com","e7f5c00bfc7067a49da98fa9b1eacd8d428a4632197edaa84c9dacd40ca35050","user"),
            };
            return usersDefault;
        }
    }
}
