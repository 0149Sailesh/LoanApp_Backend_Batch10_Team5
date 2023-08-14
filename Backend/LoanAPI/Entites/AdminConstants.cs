using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanAPI.Entites
{
    public class AdminConstants
    {
        public static List<AdminEntity> Admins = new List<AdminEntity>()
        {
            new AdminEntity() { Username = "jason", Email = "jason@email.com", Password = "MyPass_w0rd" },
            new AdminEntity() { Username = "elyse_seller", Email = "elyse.seller@email.com", Password = "MyPass_w0rd" }
        };
    }
}