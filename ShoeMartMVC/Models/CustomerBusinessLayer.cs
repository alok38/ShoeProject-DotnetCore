namespace ShoeMartMVC.Models
{
    public class CustomerBusinessLayer
    {
        
        static int newid;
        static string newname;
        public void user(int id)
        {
            newid = id;
        }
       public int ReturnID()
        {
            return newid;
        }
        public void setname(string name)
        {
            newname = name;
        }
        public string getname()
        {
            return newname;
        }
    }
}
