using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Data;
using MvcApplication1.Models;

namespace MvcApplication1.Logic
{
    public class ExchangeCalculator
    {
        public double calculateExchangeRate(String fromCurrency, String toCurrency, double amount)
        {
            ExchangeRateDAL dal = new ExchangeRateDAL();
            ExchangeRate rate = dal.findExchangeRateforConversion(fromCurrency, toCurrency);

            return rate.Rate*amount;
        }
    }
}