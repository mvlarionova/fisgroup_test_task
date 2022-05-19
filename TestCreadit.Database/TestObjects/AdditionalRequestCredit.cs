using System;

namespace TestCreadit.Database.TestObjects
{
    public class AdditionalRequestCredit
    {
        public Guid Id { get; set; }

        public string NameService { get; set; }
        public decimal Price { get; set; }
        
        public DateTime Updated { get; set; }
    }
}