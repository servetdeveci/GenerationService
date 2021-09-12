using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerPlant.Domain.ViewModels;
using System;
using System.Threading.Tasks;

namespace PowerPlant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("allowAll")]
    public class GenerationServiceController : ControllerBase
    {

        // GET: api/<GenerationService>
        [HttpGet("get")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ApiResponse<TimedValues>> Get(string webId, DateTime startTime,DateTime endTime)
        {
            return await Task.Run(() =>{
                try
                {
                    var timedvalues = new TimedValues();
                    Random rnd = new Random();
                    Console.WriteLine($"webid:{webId}, startTime: {startTime}, endTime: {endTime}");
                    var dataSlice = (int)(endTime.Subtract(startTime).TotalHours);

                    for (int i = 0; i < dataSlice; i++)
                    {
                        double random1 = rnd.NextDouble()*100 + rnd.Next(0, startTime.Second) + rnd.Next(endTime.Minute);
                        var timedvalue = new TimedValue
                        {
                            Value =Convert.ToDouble(random1.ToString("N2")),
                            Good = true,
                            Timestamp = startTime.AddHours(i)
                        };

                        if ((int)random1 % 7 == 0)
                        {
                            timedvalue.Good = false;
                            timedvalue.Value = new { error = "santralden veri alınmadı... Random Hata" };
                        }
                        timedvalues.Items.Add(timedvalue);
                    }

                    return new ApiResponse<TimedValues>
                    {
                        Data = timedvalues,
                        Status = true,
                        StatusMessage = "İşlem Başarılı"
                    };
                }
                catch (Exception ex)
                {

                    return new ApiResponse<TimedValues>
                    {
                        Data = new TimedValues(),
                        Status = false,
                        StatusMessage = ex.ToString()
                    };
                }
                

            });

        }


    }
}
