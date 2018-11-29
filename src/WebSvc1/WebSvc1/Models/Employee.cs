using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebSvc1.Models
{
    [Serializable]
    [XmlRoot(ElementName = "employee")]
    public class Employee
    {
        [XmlElement(ElementName = "EmployeeNo", DataType = "long")]
        public long EmployeeNo { get; set; }

        [XmlElement(ElementName = "Name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "DateOfBirth", DataType = "dateTime")]
        public DateTime DateOfBirth { get; set; }

        [XmlElement(ElementName = "HomeAddress")]
        public string Address { get; set; }

        [XmlElement(ElementName = "Role")]
        public string Role { get; set; }

        [XmlElement(ElementName = "Department")]
        public string Dept { get; set; }
    }
}