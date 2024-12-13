using BPKB.Data;
using BPKB.Models;
using BPKB.Services;
using Microsoft.AspNetCore.Mvc;

namespace BPKB.Controllers
{
    public class LoginFormController : Controller
    {
        private readonly BpkbService _bpkbService;

        private readonly BPKBContext _context;

        
        public LoginFormController(BpkbService bpkbService, BPKBContext context)
        {
            _bpkbService = bpkbService;
            _context = context;
        }
        public IActionResult LoginForm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] UserModel data)
        {
            UserModel user = await _bpkbService.GetUser(data);
            HttpContext.Session.SetString("UserName", user.Username);
            
            //await _bpkbService.SubmitBPKB(user);

            return Json(new { message = "Login successfully!" });

        }
    }
}
