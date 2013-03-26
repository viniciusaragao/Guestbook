using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Guestbook.Models
{
    public class GuestbookEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class GuestbookContext : DbContext
    {
        public GuestbookContext()
            : base("Guestbook")
        {
        }
        public DbSet<GuestbookEntry> Entries { get; set; }
    }
    
}