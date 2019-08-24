using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testAPI.Model;


namespace testAPI.DAL
{
  
        public class BlogRepository : IBlogRepository, IDisposable
        {
            private REEviewContext context;

            public BlogRepository(REEviewContext context)
            {
                this.context = context;
            }
           public Blogger GetBlogByUrl(string url)
            {
                return context.Blogger.Find(url);
            }

            public void InsertBlog(Blogger blog)
        {
                context.Blogger.Add(blog);
            }

            public void DeleteBlog(int blogId)
        {
            Blogger video = context.Blogger.Find(blogId);
                context.Blogger.Remove(video);
            }

            public void UpdateBlog(Blogger blog)
        {
                context.Entry(blog).State = EntityState.Modified;
            }

            public void Save()
            {
                context.SaveChanges();
            }

            private bool disposed = false;

            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        context.Dispose();
                    }
                }
                this.disposed = true;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }
    
}
