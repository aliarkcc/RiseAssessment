using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Mvc;
using MvcUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MvcUI.Controllers
{
    public class ContactInfoController : Controller
    {
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:44367/api/";
        public ContactInfoController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var contactInfos = await _httpClient.GetFromJsonAsync<List<ContactInfo>>(url + "ContactInfos/GetAll");
            return View(contactInfos);
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(int id)
        {
            var contactInfos = await _httpClient.GetFromJsonAsync<List<ContactInfo>>(url + "");
            return View(contactInfos);
        }
        [HttpGet]
        public async Task<IActionResult> GetDirectoryDetailDto(int id)
        {
            var directoryContactInfoDetails = await _httpClient.GetFromJsonAsync<ContactInfoDto>(url + "ContactInfos/GetDirectoryDetailDto?id=" + id);
            return View(directoryContactInfoDetails);
        }
        [HttpGet]
        public IActionResult Add(int id)
        {
            ViewBag.directoryId = id;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ContactAddViewModel addViewModel)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync(url + "ContactInfos/Add", addViewModel);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var contactInfos = await _httpClient.GetFromJsonAsync<ContactInfo>(url + "ContactInfos/GetById/" + id);
            return View(contactInfos);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ContactInfo contactInfo)
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "ContactInfos/Update", contactInfo);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync(url + "ContactInfos/Delete/" + id);
            return RedirectToAction("Index");
        }
    }
}