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

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Post> Post { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Post> studentIQ = from s in _context.Post
                                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentIQ = studentIQ.Where(s => s.AuthorName.Contains(searchString)
                                       || s.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    studentIQ = studentIQ.OrderBy(s => s.PublicationDate);
                    break;
                case "date_desc":
                    studentIQ = studentIQ.OrderByDescending(s => s.PublicationDate);
                    break;
                default:
                    studentIQ = studentIQ.OrderBy(s => s.Id);
                    break;
            }

            int pageSize = 3;
            Post = await PaginatedList<Post>.CreateAsync(
                studentIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
