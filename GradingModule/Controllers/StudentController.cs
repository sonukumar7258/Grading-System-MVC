using GradingModule.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.Text;

namespace GradingModule.Controllers
{
    public class StudentController : Controller
    {
		public static string student_id;
		public static string course_id;
		public static string category_name;
		public ActionResult Index()
        {
			return View();
        }


		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(Category category)
		{
			try
			{
				student_id = category.stud_id;
				course_id = category.course_id;
				category_name = category.CategoryName;
				return View("Index");
			}
			catch
			{
				return View();
			}
		}


		public ActionResult FindCategoriesList() {
			IEnumerable<Category> fines;

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri("http://localhost:5018/");

				String QueryString = "api/students/" + student_id + "/" + course_id + "/" + category_name;

                var responseTask = client.GetAsync(QueryString);
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsAsync<IList<Category>>();
					readTask.Wait();

					Console.WriteLine(readTask.Result.Count);

					fines = readTask.Result;
				}
				else
				{
					fines = Enumerable.Empty<Category>();
					ModelState.AddModelError(string.Empty, "Server Error. Please contact Administrator.");
				}
			}			
			return View(fines);
        }

		public ActionResult generateTranscipt()
		{
            IEnumerable<Marks> fines;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5018/");

                String QueryString = "api/students/" + student_id + "/" + course_id;

                var responseTask = client.GetAsync(QueryString);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Marks>>();
                    readTask.Wait();

                    Console.WriteLine(readTask.Result.Count);

                    fines = readTask.Result;
                }
                else
                {
                    fines = Enumerable.Empty<Marks>();
                    ModelState.AddModelError(string.Empty, "Server Error. Please contact Administrator.");
                }
            }
            return View(fines);
		}
	}
}
