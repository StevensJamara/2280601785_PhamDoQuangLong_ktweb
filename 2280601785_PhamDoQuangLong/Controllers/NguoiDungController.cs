using Microsoft.AspNetCore.Mvc;
using _2280601785_PhamDoQuangLong.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace _2280601785_PhamDoQuangLong.Controllers
{
    public class NguoiDungController : Controller
    {
        private readonly KtwebQlongContext _context;

        public NguoiDungController(KtwebQlongContext context)
        {
            _context = context;
        }

        // Index action to list all users
        public async Task<IActionResult> Index()
        {
            var users = await _context.SinhViens.ToListAsync();
            return View(users);
        }
    }
}
