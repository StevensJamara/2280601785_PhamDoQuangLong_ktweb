using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using _2280601785_PhamDoQuangLong.Models;

namespace _2280601785_PhamDoQuangLong.Controllers
{
    public class HocPhanController : Controller
    {
        private readonly KtwebQlongContext _context;
        public HocPhanController(KtwebQlongContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ListHP()
        {
            // Query the database for HocPhan records
            var hocPhanList = await _context.HocPhans.ToListAsync();
            return View(hocPhanList);
        }
    }
}
