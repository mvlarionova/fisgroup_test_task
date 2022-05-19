using System;
using System.Collections.Generic;

namespace TestCreadit.Database.TestObjects
{
    public class Debtor
    {
        public Guid Id { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patro { get; set; }
        public long PhoneNumber { get; set; }
        public long AdditionalPhoneNumber { get; set; }
        public string Email { get; set; }

        public int SerialPassport { get; set; }
        public int NumberPassport { get; set; }
        public DateTime DateIssuePassport { get; set; }
        public string CodePassport { get; set; }
        public string WhomIssuePassport { get; set; }
        
        public DateTime Birthdate  { get; set; }
        public string Placebirth  { get; set; }
        public string RegionRegistration { get; set; }

        public DebtorPlaceWork DebtorPlaceWork { get; set; } //Один к Одному - работа и пользователь

        public List<RequestCredit> RequestsCredit { get; set; } //Один ко многим, но, по ТЗ, по форме один к одному и флажок актуальной заявки

        public DateTime Updated { get; set; }
    }
}