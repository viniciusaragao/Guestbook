using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Guestbook.Models
{
    public class GuestbookEntry
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class CommentSummary
    {
        public string UserName { get; set; }
        public int NumberOfComments { get; set; }
    }

    public class GuestbookContext : DbContext
    {
        public GuestbookContext()
            : base("Guestbook")
        {
        }
        public DbSet<GuestbookEntry> Entries { get; set; }
        public DbSet<CommentSummary> Comments { get; set; }
    }
}