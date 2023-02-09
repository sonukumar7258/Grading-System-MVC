using Microsoft.AspNetCore.Mvc;
using GradingModule.Models;
using Newtonsoft.Json;
using System.Text;

namespace GradingModule.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Teacher> fines;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5018/api/teachers/");

                var responseTask = client.GetAsync("AllTeachers");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Teacher>>();
                    readTask.Wait();

                    Console.WriteLine(readTask.Result.Count);

                    fines = readTask.Result;
                }
                else
                {
                    fines = Enumerable.Empty<Teacher>();
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact Administrator.");
                }
            }

            Console.WriteLine(fines);
            return View(fines);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }
        public IActionResult SetGrade()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5018/api/teachers/");

            var json = new
            {
                category.stud_id,
                category.course_id,
                category.CategoryName,
                category.CategoryNameSequence,
                category.marks,
                category.TotalMarks
            };

            var jsonItem = JsonConvert.SerializeObject(json);

            var data = new StringContent(jsonItem, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("CategoryMarks", data);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category category)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5018/api/teachers/");

            var json = new
            {
                category.stud_id,
                category.course_id,
                category.CategoryName,
                category.CategoryNameSequence,
                category.marks
            };

            var jsonItem = JsonConvert.SerializeObject(json);

            var data = new StringContent(jsonItem, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("UpdateMarks", data);
            response.EnsureSuccessStatusCode();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetGrade(Marks m)
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5018/api/teachers/");

            var json = new
            {
                m.stud_id,
                m.course_id
            };

            try
            {
                var jsonItem = JsonConvert.SerializeObject(json);

                var data = new StringContent(jsonItem, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("SetTotalMarks", data);
                response.EnsureSuccessStatusCode();

                return RedirectToAction("Index");
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}

    }
}
