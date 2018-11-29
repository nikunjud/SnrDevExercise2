using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Xml;
using System.Web.Http;
using WebSvc1.Models;
using System.Xml.Serialization;

namespace WebSvc1.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        public IEnumerable<Employee> Get()
        {
            if (EmployeesList == null || EmployeesList.Count == 0)
            {
                throw new InvalidDataException("List of companies was not loaded.");
            }

            return EmployeesList;
        }

        // GET: api/Employee/5
        public string Get(int id)
        {
            return "value";
        }

        private static IList<Employee> EmployeesList = LoadEmployees();

        private static IList<Employee> LoadEmployees()
        {
            List<Employee> loadedEmployees= new List<Employee>();
            try
            {
                const string resourceName = "WebSvc1.Resources.employees.xml";
                var serialiser = new XmlSerializer(typeof(Employee));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
                {
                    using (var xmlRdr = XmlReader.Create(stream))
                    {
                        while (xmlRdr.Read())
                        {
                            switch (xmlRdr.NodeType)
                            {
                                case XmlNodeType.Element:
                                {
                                    if (xmlRdr.Name == "employee")
                                    {
                                        var emp = serialiser.Deserialize(xmlRdr) as Employee;
                                        loadedEmployees.Add(emp);
                                    }
                                    break;
                                }
                                default:
                                    break;

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new FileLoadException("Could not read file.", ex);
            }

            return loadedEmployees;
        }
    }
}
