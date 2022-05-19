using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TestCreadit.Database.TestObjects
{
    public class RequestCredit
    {
        public Guid Id { get; set; }

        public ProductType ProductType { get; set; }
        public PurposeCredit PurposeCredit { get; set; }
        /// <summary>
        /// Сумма кредита
        /// </summary>
        public double Quantity { get; set; }
        /// <summary>
        /// Ставка
        /// </summary>
        public double Percent { get; set; }

        public List<AdditionalRequestCredit> AdditionalRequestCredits { get; set; } //Один ко многим (таблица скорее всего заполняется администратором)
        /// <summary>
        /// Срок кредита
        /// </summary>
        public int TermCredit { get; set; }
        public double QuantityWithAdditional { get; set; }

        public bool Actual { get; set; } // Актуальность заявки

        public DateTime Updated { get; set; }
    }

    public enum ProductType
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "Кредит наличными")]
        CreditCash,
        [EnumMember(Value = "Авто кредит")]
        AutoCredit
    }

    public enum PurposeCredit
    {
        [EnumMember(Value = "")]
        None,
        [EnumMember(Value = "Покупка товаров/услуг")]
        BuyProductOrService
    }

}