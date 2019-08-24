using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testAPI.Model;

namespace testAPI.DAL
{
    public interface IBlogRepository: IDisposable
    {
   
        Blogger GetBlogByUrl(string url);
        void InsertBlog(Blogger blog);
        void DeleteBlog(int blogId);
        void UpdateBlog(Blogger blog);
        void Save();
    }
}
