using CreditGuardApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditGuardApi.Repositories;
using System.Security.Cryptography;
using System.Text;
namespace CreditGuardApi.Services
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        { 
            _transactionRepository = transactionRepository;
        }
        public Transaction AddTransaction(TransactionRequest request)
        {
            request.CardNumber = ComputeSha256Hash(request.CardNumber);
            Transaction transaction = new Transaction(request.CardNumber, DateTime.UtcNow);           
            _transactionRepository.AddTransaction(transaction);
            return transaction;
        }
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
