using Database2.Models;
using Microsoft.IdentityModel.Abstractions;

namespace Tuto_06.WebApi.Repos
{
    public class CustomerRepo
    {
        private static readonly AppDaContext _db = new AppDaContext();

        public static bool IsExist(string customerName)
        {
            var res = CustomerRepo._db.Customers.Where(c => c.CustomerId.ToString() == customerName.ToString()).FirstOrDefault();

            return (res is not null ) ? true : false;
        }
    }
}
