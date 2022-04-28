using ASPLaboration.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ASPLaboration.Controllers
{
    public class RestController : Controller
    {
         
        string Baseurl = "http://localhost:44302/";
        public async Task<ActionResult> Index()
        {
            try { 
            List<Rest> EmpInfo = new List<Rest>();

                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri(Baseurl);

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    HttpResponseMessage Res = await client.GetAsync("api/Film/GetFilms");


                    if (Res.IsSuccessStatusCode)
                    {

                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;


                        EmpInfo = JsonConvert.DeserializeObject<List<Rest>>(EmpResponse);

                    }

                    return View(EmpInfo);
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }
    }
}