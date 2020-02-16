using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebSvc1.Models
{
    [Serializable]
    [XmlRoot(ElementName = "employeebonusinfo")]
    public class EmployeeBonusInfo
    {
        [XmlElement(ElementName = "EmployeeNo", DataType = "long")]
        public long EmployeeNo { get; set; }

        [XmlElement(ElementName = "BonusAmount", DataType = "decimal")]
        public decimal BonusAmount { get; set; }

        [XmlElement(ElementName = "BonusDate", DataType = "date")]
        public DateTime BonusDate { get; set; }
    }
}