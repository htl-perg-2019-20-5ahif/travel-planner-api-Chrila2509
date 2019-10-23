using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlannerClassLibrary;

namespace API.Controllers
{
    [ApiController]
    [Route("travelplan")]
    public class TravelPlannerController : ControllerBase
    {
        private HttpClient cl;
        private string filename = "travelPlan.json";

        public TravelPlannerController(IHttpClientFactory factory)
        {
            this.cl = factory.CreateClient();
            this.cl.BaseAddress = new Uri("https://cddataexchange.blob.core.windows.net/data-exchange/htl-homework/");
        }

        [HttpGet]
        public async Task<IActionResult> GetTrips([FromQuery] string Dep,
                                                  [FromQuery] string Dest,
                                                  [FromQuery]string Time)
        {
            HttpResponseMessage response = await cl.GetAsync(filename);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            List<Route> RouteList = JsonSerializer.Deserialize<List<Route>>(responseBody);

            var planner = new FindRoute(RouteList);
            var trip = planner.GetTrip(Dep, Dest, Time);

            if (trip != null)
            {
                return Ok(trip);
            }
            else
            {
                return NotFound("No trip found");
            }
        }
    }
}
