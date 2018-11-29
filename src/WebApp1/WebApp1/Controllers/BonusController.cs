using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebApp1.DataContracts;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class BonusController : Controller
    {
        // GET: Bonus
        public ActionResult Index()
        {
            return View("View");
        }

        // POST: Bonus/Allocate
        [HttpPost]
        public async Task<ActionResult> Allocate(BonusViewModel bonusAllocation)
        {
            try
            {
                var employees = await GetEmployees();
                List<Employee> recipients = new List<Employee>();

                for (int i = 0; i < employees.Count; i++)
                {
                    if (i % bonusAllocation.OneInXEmployees == 0)
                    {
                        var recipient = employees[i];
                        recipients.Add(recipient);
                        employees.Remove(recipient);
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("View");
            }
        }

        private async Task<List<Employee>> GetEmployees()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57652/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync($"api/employee");
            if (response.IsSuccessStatusCode)
            {
                string employeeData = await response.Content.ReadAsStringAsync();
                List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(employeeData);

                return employees;
            }

            return new List<Employee>();
        }
    }
}