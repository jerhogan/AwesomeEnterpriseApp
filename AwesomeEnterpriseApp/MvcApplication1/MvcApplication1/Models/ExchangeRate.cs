using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace MvcApplication1
{
    [Table (Name="EXCHANGERATES")]
    public class ExchangeRate
    {
        [Column(IsPrimaryKey = true)]
        int id;
        [Column (Name="FROMCURRENCY")]
        String fromCurrency;
        [Column(Name = "TOCURRENCY")]
        String toCurrency;
        [Column(Name = "RATE")]
        public double rate;

        public ExchangeRate(String aFrom, String aTo, double aRate)
        {
            this.fromCurrency = aFrom;
            this.toCurrency = aTo;
            this.rate = aRate;
        }

        public double Rate
        {
            get { return rate ;}
        }
    }
}