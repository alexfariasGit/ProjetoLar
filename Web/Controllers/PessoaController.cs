using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.Models;

namespace Web.Controllers
{
    public class PessoaController : Controller
    {
        private readonly HttpClient _httpClient;

        public PessoaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para obter todas as pessoas
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetStringAsync("http://localhost:5123/api/pessoa");
            var pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(response);
            return View(pessoas);
        }

        // Método para visualizar os detalhes de uma pessoa
        public async Task<IActionResult> Details(long id)
        {
            var response = await _httpClient.GetStringAsync($"http://localhost:5123/api/pessoa/{id}");
            var pessoa = JsonConvert.DeserializeObject<Pessoa>(response);
            return View(pessoa);
        }

        // Método para criar uma nova pessoa
        public IActionResult Create()
        {
            return View(new Pessoa());
        }

        // Método POST para criar uma nova pessoa
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(pessoa), System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("http://localhost:5123/api/pessoa", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(pessoa);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetStringAsync($"http://localhost:5123/api/pessoa/{id}");
            var pessoa = JsonConvert.DeserializeObject<Pessoa>(response);
            if (pessoa == null)
            {
                return NotFound();
            }

            return View(pessoa);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromBody] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(pessoa), System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync("http://localhost:5123/api/pessoa", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(pessoa);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Send DELETE request to the API
                var response = await _httpClient.DeleteAsync($"http://localhost:5123/api/pessoa/{id}");

                // If deletion is successful, redirect to Index page
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // If deletion failed, return the same page (you could also show an error message)
                    return RedirectToAction(nameof(Index));
                }
            }
            catch
            {
                // Handle any exception that occurs during the deletion process
                return View();
            }
        }
    }
}

