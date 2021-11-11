using System;

namespace Modul4HW3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (AppContext app = new AppContext())
            {
                app.SaveChanges();
            }
        }
    }
}
