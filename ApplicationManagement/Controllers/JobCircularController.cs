using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationManagement.DbModel;

namespace ApplicationManagement.Controllers
{
    public class JobCircularController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobCircularController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: JobCircular
        public async Task<IActionResult> Index()
        {
            return View(await _context.JobCirculars.ToListAsync());
        }

        // GET: JobCircular/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCircular = await _context.JobCirculars
                .SingleOrDefaultAsync(m => m.Id == id);
            if (jobCircular == null)
            {
                return NotFound();
            }

            return View(jobCircular);
        }

        // GET: JobCircular/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobCircular/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostName,Description,StartDate,EndDate,NoticeImageFileUrl,NoOfTotalAvailablePosts")] JobCircular jobCircular)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobCircular);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobCircular);
        }

        // GET: JobCircular/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCircular = await _context.JobCirculars.SingleOrDefaultAsync(m => m.Id == id);
            if (jobCircular == null)
            {
                return NotFound();
            }
            return View(jobCircular);
        }

        // POST: JobCircular/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PostName,Description,StartDate,EndDate,NoticeImageFileUrl,NoOfTotalAvailablePosts")] JobCircular jobCircular)
        {
            if (id != jobCircular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobCircular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobCircularExists(jobCircular.Id))
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
            return View(jobCircular);
        }

        // GET: JobCircular/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobCircular = await _context.JobCirculars
                .SingleOrDefaultAsync(m => m.Id == id);
            if (jobCircular == null)
            {
                return NotFound();
            }

            return View(jobCircular);
        }

        // POST: JobCircular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var jobCircular = await _context.JobCirculars.SingleOrDefaultAsync(m => m.Id == id);
            _context.JobCirculars.Remove(jobCircular);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JobCircularExists(long id)
        {
            return _context.JobCirculars.Any(e => e.Id == id);
        }
    }
}
