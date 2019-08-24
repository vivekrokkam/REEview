using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testAPI.Model;
//using helper.Bloggershelper;
using testAPI.helper;
using testAPI.DAL;

namespace testAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggersController : ControllerBase
    {
        public class URLDTO
        {
          public  string URL { get; set; }


        }

        private readonly REEviewContext _context;

        private IBlogRepository blogRepository;

        public BloggersController(REEviewContext context)
        {
            _context = context;
            this.blogRepository = new BlogRepository(new REEviewContext());
        }

        // GET: api/Bloggers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blogger>>> GetBlogger()
        {
            return await _context.Blogger.ToListAsync();
        }
        // DELETE: api/Blogger/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Blogger>> DeleteBlog(int id)
        {
          
            var blog = await _context.Blogger.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            _context.Blogger.Remove(blog);
            await _context.SaveChangesAsync();

            return blog;
        }

        // GET: api/Bloggers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Blogger>> GetBlogger(int id)
        {
            var blogger = await _context.Blogger.FindAsync(id);

            if (blogger == null)
            {
                return NotFound();
            }

            return blogger;
        }

        // PUT: api/Bloggers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogger(int id, Blogger blogger)
        {
            if (id != blogger.BlogId)
            {
                return BadRequest();
            }

            _context.Entry(blogger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloggerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bloggers
        [HttpPost]
        public async Task<ActionResult<Blogger>> PostBlogger(URLDTO URL)
        {
            Blogger newBlogInfo = Bloggershelper.GetBlogInfo(URL.URL);
            
           

            // Add this video object to the database
            _context.Blogger.Add(newBlogInfo);
            await _context.SaveChangesAsync();

            // Return success code and the info on the video object
            // return CreatedAtAction("GetVideo", new { id = newBlogInfo.BlogId }, newBlogInfo);
            return newBlogInfo;
        }



        private bool BloggerExists(int id)
        {
            return _context.Blogger.Any(e => e.BlogId == id);
        }
    }
}