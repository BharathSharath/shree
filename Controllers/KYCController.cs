using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using YourApplication.Data;
using YourApplication.Models;

namespace YourApplication.Controllers
{
    public class KYCController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KYCController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var kycList = await _context.KYC.ToListAsync();
            return View(kycList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(KYC kyc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kyc);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(kyc);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var kyc = await _context.KYC.FindAsync(id);
            if (kyc == null)
            {
                return NotFound();
            }
            return View(kyc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, KYC kyc)
        {
            if (id != kyc.KYCID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kyc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KYCExists(kyc.KYCID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(kyc);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var kyc = await _context.KYC.FindAsync(id);
            if (kyc == null)
            {
                return NotFound();
            }
            return View(kyc);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kyc = await _context.KYC.FindAsync(id);
            _context.KYC.Remove(kyc);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool KYCExists(int id)
        {
            return _context.KYC.Any(e => e.KYCID == id);
        }
    }
}
