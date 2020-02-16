using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;
using System.Xml.Serialization;
using WebSvc1.App_Start;
using WebSvc1.Models;

namespace WebSvc1.Controllers
{
    [CustomExceptionFilter]
    public class RemunerationController : ApiController
    {
        public HttpResponseMessage Post(BonusRecipients br)
        {
            IList<EmployeeBonusInfo> list = new List<EmployeeBonusInfo>();
            DateTime dt = DateTime.UtcNow;
            foreach (var employee in br.Recipients)
            {
                EmployeeBonusInfo ebi = new EmployeeBonusInfo();
                ebi.BonusAmount = br.BonusAmount;
                ebi.EmployeeNo = employee.EmployeeNo;
                ebi.BonusDate = dt;
                list.Add(ebi);
            }

            WriteXML(list);

            return Request.CreateResponse(HttpStatusCode.OK); ;

        }

        private void WriteXML(IList<EmployeeBonusInfo> list)
        {
            try
            {
                const string resourceName = "employeebonusinfo.xml";
                string path = AppDomain.CurrentDomain.BaseDirectory;
                var serialiser = new XmlSerializer(typeof(EmployeeBonusInfo));

                using (TextWriter tw = new StreamWriter(path + "\\Resources\\" + resourceName, append: true))
                {
                    foreach (var item in list)
                    {
                        serialiser.Serialize(tw, item);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new FileLoadException("Could not read file.", ex);
            }
        }
    }
}
