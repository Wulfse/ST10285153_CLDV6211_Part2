using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace CLDVPart1.Models
{
    public class Transaction
    {
        private static readonly string connectionString = "Your connection string here";

        public int TransactionID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime TransactionDate { get; set; }



        public static List<Transaction> GetTransactions(int userID, ApplicationDbContext context)
        {
            return context.Transactions.Where(t => t.UserID == userID).ToList();
        }

        public static void PlaceOrder(Transaction transaction, ApplicationDbContext context)
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();
        }
    }
}