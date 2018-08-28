using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Passports.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InvalidPassportsController : ControllerBase
    {

        private readonly IDatabaseContext databaseContext;

        public InvalidPassportsController(IDatabaseContext context)
        {
            databaseContext = context;
        }

        // GET: api/InvalidPassports
        [HttpGet()]
        [Produces("application/json")]
        public string Index()
        {
            return "Ready";
        }

        // GET: api/InvalidPassports/Series/Number
        [HttpGet("{series}/{number}", Name = "Get")]
        [Produces("application/json")]
        public ActionResult<JsonResult> Get(string series, string number)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(databaseContext.ConnectionString))
                {
                    connection.Open();
                    String sql = "SELECT s, p FROM slpassport.dbo.passport WHERE s = @Series AND p = @Number;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Series", series));
                        command.Parameters.Add(new SqlParameter("@Number", number));
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return Ok(new { result = "Yes" });
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok(new { result = "No" });
        }

    }
}
