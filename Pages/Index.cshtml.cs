using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using entrepreneur_tc_auth.Models;
using Microsoft.EntityFrameworkCore;
using entrepreneur_tc_auth.Data;
using Microsoft.AspNetCore.Authorization;
namespace entrepreneur_tc_auth.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Post> Posts { get; set; }
        public async Task OnGetAsync()
        {
            // IQueryable<Post> studentIQ = from s in _context.Post
                                            // select s;
            Posts = await _context.Post.AsNoTracking().ToListAsync();
        }
    }
}
