using ShoeCart.Models;

namespace ShoeCart.Repository
{
    public interface IAdminRepository
    {
        public IEnumerable<Admin> GetAllAdmins();
        public Admin GetAdmin(int id);
        public Admin Add(Admin admin);
        public bool Update(Admin admin);
        public bool Remove(int id);

    }
}
