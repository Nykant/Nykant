using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NykantAPI.Data;
using NykantAPI.Models;

namespace NykantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]/")]
    public class ReviewController : BaseController
    {

        public ReviewController(ApplicationDbContext context, ILogger<BaseController> logger) : base(logger, context)
        {
        }

        // GET: Review
        public async Task<ActionResult<List<Review>>> Index()
        {
            var json = JsonConvert.SerializeObject(await _context.Reviews.ToListAsync());
            return Ok(json);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<List<Review>>> GetProductReviews(int productId)
        {
            var reviews = _context.Reviews.Where(x => x.ProductId == productId);
            var json = JsonConvert.SerializeObject(await _context.Reviews.ToListAsync());
            return Ok(json);
        }

        // GET: Review/Details/5
        public async Task<ActionResult<Review>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Reviews
                .FirstOrDefaultAsync(m => m.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            var json = JsonConvert.SerializeObject(review);

            return Ok(json);
        }

        // POST: Review/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult<Review>> Create([Bind("Id,ProductId,Subject,Title,Body,Stars")] Review review)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var entity = _context.Reviews.Add(review).Entity;
                    await _context.SaveChangesAsync();
                    return CreatedAtAction("Details", new { id = entity.Id }, entity);
                }
                catch(Exception e)
                {
                    return NotFound(e);
                }
            }
            return NotFound();
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,ProductId,Subject,Title,Body,Stars")] Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Ok();
            }
            return NotFound();
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
