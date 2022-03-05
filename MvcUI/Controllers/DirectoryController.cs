using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MvcUI.Controllers
{
    public class DirectoryController : Controller
    {
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:44367/api/";
        public DirectoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var directories = await _httpClient.GetFromJsonAsync<List<Directory>>(url + "Directories/GetAll");
            return View(directories);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Directory directory)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync(url + "Directories/Add", directory);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var directories = await _httpClient.GetFromJsonAsync<Directory>(url + "Directories/GetById/" + id);
            return View(directories);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Directory directory)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Directories/Update", directory);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync(url + "Directories/Delete/" + id);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
