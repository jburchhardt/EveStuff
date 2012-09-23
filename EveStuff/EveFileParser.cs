using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace EveStuff
{
    class EveFileParser
    {
        class Record : IComparable<Record>
        {
            public int Amount { get; set; }
            public double Price { get; set; }

            public int CompareTo(Record other)
            {
                return Price.CompareTo(other.Price);
            }
        }

        static IFormatProvider culture = new CultureInfo("en-US");
        
        public EveFileParser(string[] lines)
        {
             if (lines.Length < 2)
                return;
            
            EveTypeID = Convert.ToInt32(lines[1].Split(',')[2]);
            
            var records = new List<Record>();
            foreach( var line in lines){
                var prop = line.Split(',');
                if(prop[7]=="False" && prop[10] =="60003760")
                    records.Add(new Record { Amount = Decimal.ToInt32(Convert.ToDecimal(prop[1], culture)), Price = Convert.ToDouble(prop[0],culture) });
            }
            records.Sort();

            int count = Math.Min(records.Count, 6);
            if (count == 0)
                return;

            int amount = 0;
            for (int i = 0; i < count; ++i)
            {
                if (i > 0 && records[i].Price > 2 * records[i-1].Price)
                {
                    count = i;
                    break;
                }
                    
                amount += records[i].Amount;
            }

            var averageAmount = amount/count;
            amount = 0;
            foreach (var record in records)
            {
                amount += record.Amount;
                if (amount >= averageAmount)
                {
                    Price = record.Price - 0.01;
                    break;
                }
            }

         }

        public double Price { get; private set; }
        public int EveTypeID { get; private set; }
    }
}
