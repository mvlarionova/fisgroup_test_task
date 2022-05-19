using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using TestCreadit.Database;
using TestCreadit.Database.TestObjects;
using TestCreadit.DTO;

namespace TestCreadit.Controllers
{
    public class TestController: ControllerBase
    {
        private readonly TestContext _context;

        public TestController(TestContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("createDatabase")]
        public IActionResult CreateDatabase()
        {
            try
            {
                _context.Database.EnsureCreated();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        
        [HttpGet]
        [Route("getModaRequest")]
        public IActionResult GetModaRequest()
        {
            var request_lastyear = _context.RequestsCredit
                .Where(x => x.Updated >= DateTime.Now.AddYears(-1))
                .Select(x => x.ProductType)
                .ToList();
            
            var moda_group = request_lastyear
                .GroupBy(x => x)
                .OrderByDescending(x => x.Count())
                .FirstOrDefault();
            
            var moda_result = moda_group.Key;

            return Ok(new { ModaLastYear = GetEnumMemberValue(moda_result) });
        }
        
        [HttpGet]
        [Route("getShelderChecks")]
        public IActionResult GetShedulerChecks([FromQuery] RequestCredit requestCredit)
        {
            var result_out = new List<ShedulerChecks>();

            var percent_rate = requestCredit.Percent / (100 * requestCredit.TermCredit);
            
            var month_pay = (requestCredit.Quantity * (percent_rate) /
                             (1 - Math.Pow(1 + percent_rate, -requestCredit.TermCredit)));
            
            var ost = requestCredit.Quantity - month_pay  +
                      ((requestCredit.Quantity / 100 * requestCredit.Percent) / requestCredit.TermCredit);
            
            result_out.Add(new ShedulerChecks()
            {
                Month = 1,
                MonthlyPayment = Math.Round(month_pay,2),
                PrincipalDebt = Math.Round(month_pay - ((requestCredit.Quantity / 100 * requestCredit.Percent) / requestCredit.TermCredit),2),
                InterestDebt = Math.Round((requestCredit.Quantity / 100 * requestCredit.Percent) / requestCredit.TermCredit,2),
                RemainingDebt = Math.Round(requestCredit.Quantity - month_pay  +
                                           ((requestCredit.Quantity / 100 * requestCredit.Percent) / requestCredit.TermCredit),2)
            });
            
            for (int i = 2; i <= requestCredit.TermCredit; i++)
            {
           
                    result_out.Add(new ShedulerChecks()
                    {
                        Month = i,
                        MonthlyPayment = Math.Round(month_pay,2),
                        PrincipalDebt = Math.Round((month_pay - (ost * requestCredit.Percent / 100 / requestCredit.TermCredit)),2),
                        InterestDebt = Math.Round((ost * requestCredit.Percent / 100 / requestCredit.TermCredit),2),
                        RemainingDebt = Math.Round(ost - (month_pay - (ost * requestCredit.Percent / 100 / requestCredit.TermCredit)),2)

                    }); 
                   ost -=  month_pay - (ost * requestCredit.Percent / 100 / requestCredit.TermCredit);
                
                
            }

            return Ok(result_out);
        }
        
        public  string? GetEnumMemberValue<T>( T value)
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }
    }
}