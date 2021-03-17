using Microsoft.AspNetCore.Mvc;
using ValidPasswordInterfaces.Business;

namespace ValidPasswordAPI.Controllers.ValidPassword
{
    [ApiController]
    [Route("[controller]")]
    public class ValidPasswordController : ControllerBase
    {
        private readonly IPasswordBusiness _passwordBusiness;

        public ValidPasswordController(IPasswordBusiness passwordBusiness)
        {
            _passwordBusiness = passwordBusiness;
        }

        [Route("IsValid"), HttpGet]
        public bool IsValid(string password)
        {
            return _passwordBusiness.IsValid(password);
        }
    }
}
