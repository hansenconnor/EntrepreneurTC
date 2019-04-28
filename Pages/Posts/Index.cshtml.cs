using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using entrepreneur_tc_auth.Data;
using entrepreneur_tc_auth.Models;

namespace entrepreneur_tc_auth.Pages.Posts
{
    public class IndexModel : PageModel
    {
        private readonly entrepreneur_tc_auth.Data.ApplicationDbContext _context;

        public IndexModel(entrepreneur_tc_auth.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; }

        public async Task OnGetAsync()
        {
            Post = await _context.Post.ToListAsync();
        }
    }
}
