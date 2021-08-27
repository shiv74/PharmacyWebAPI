using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PharmacyWebApp.Helper;
using PharmacyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace PharmacyWebApp.Controllers
{
    public class HomeController : Controller
    {
        MedicineAPI api = new MedicineAPI();
        public async Task<IActionResult> Index()
        {
            List<MedicineData> medicines = new List<MedicineData>();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Medicine");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                medicines = JsonConvert.DeserializeObject<List<MedicineData>>(results);
            }
            return View(medicines);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MedicineData medicine)
        {
            HttpClient client = api.Initial();

            var postData = client.PostAsJsonAsync<MedicineData>("/api/Medicine", medicine);
            postData.Wait();

            var result = postData.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(string id)
        {
            var medicine = new MedicineData();
            HttpClient client = api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/Medicine/{id}");

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
 