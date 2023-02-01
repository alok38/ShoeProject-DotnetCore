using ShoeCart.DataAccessLayer;
using ShoeCart.Models;

namespace ShoeCart.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ShoeStoreContext _Shoecontext;
        public AdminRepository(ShoeStoreContext context)
        {
            _Shoecontext = context;
        }
        public Admin Add(Admin admin)
        {
            _Shoecontext.Admins.Add(admin);
            _Shoecontext.SaveChanges();
            return admin;
        }
        public IEnumerable<Admin>GetAllAdmins()
        {
            return _Shoecontext.Admins.ToList();
        }
        public Admin GetAdmin(int id)
        {
            return _Shoecontext.Admins.FirstOrDefault(x => x.AdminId == id);
        }
        public bool Remove(int id)

        {
            var adminToRemove = GetAdmin(id);
            _Shoecontext.Admins.Remove(adminToRemove);
            _Shoecontext.SaveChanges();
            return true;
        }
        public bool Update(Admin admin)
        {
            var AdminToUpdate = GetAdmin(admin.AdminId);
            AdminToUpdate.AdminName = admin.AdminName;
            AdminToUpdate.UserId = admin.UserId;
            AdminToUpdate.AdminPhoneNumber = admin.AdminPhoneNumber;
            AdminToUpdate.Password = admin.Password;
            _Shoecontext.SaveChanges();
            return true;
        }
    }
}
