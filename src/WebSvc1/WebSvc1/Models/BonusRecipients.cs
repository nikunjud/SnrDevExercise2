using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSvc1.Models
{
    public class BonusRecipients
    {
        public decimal BonusAmount { get; set; }

        public IEnumerable<Employee> Recipients { get; set; }
    }
}