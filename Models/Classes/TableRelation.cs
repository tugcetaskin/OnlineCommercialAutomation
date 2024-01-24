using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCommercialAutomation.Models.Classes
{
    public class TableRelation
    {
        public IEnumerable<Product> ProductValue { get; set; }
        public IEnumerable<Detail> DetailValue { get; set; }
        
    }
}