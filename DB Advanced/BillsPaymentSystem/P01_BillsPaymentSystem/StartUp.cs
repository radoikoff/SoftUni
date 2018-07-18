using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Initializer;
using System;

namespace P01_BillsPaymentSystem
{
    public class StartUp
    {
        public static void Main()
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
                Initialize.Seed(context);

            }
        }
    }
}
