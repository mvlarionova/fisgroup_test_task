using System;

namespace TestCreadit.Database.TestObjects
{
    public class DebtorPlaceWork
    {
        public Guid Id { get; set; }

        public string Region { get; set; }
        public string Name { get; set; }
        public int INN { get; set; }
        public string NamePost { get; set; }
        public decimal ValueSalary { get; set; }
        public DateTime DateStartWork { get; set; }

        public DateTime Updated { get; set; }
    }

}