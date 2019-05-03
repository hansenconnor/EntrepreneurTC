using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace entrepreneur_tc_auth.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
        public string Category { get; set; }
        public string AuthorName { get; set; }

        public Post()
        {
        }
    }
}
