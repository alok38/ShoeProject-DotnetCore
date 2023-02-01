namespace ShoeMartMVC.Models
{
    public class AdminBusinessLayer
    {
        static Admin adminBL;
        public void getAdmin(Admin admin)
        {
            adminBL = admin;
        }
        public Admin ReturnAdmin()
        {
            return adminBL;
        }
    }
}
