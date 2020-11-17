using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPlace.Shared
{
    public interface IBlogService
    {
        Task<List<BlogEntry>> GetBlogEntries();
    }
}
