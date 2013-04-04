using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guestbook.Models
{
    public interface IGuestbookRepository
    {
        IList<GuestbookEntry> GetMostRecentEntries();
        GuestbookEntry FindById(int id);
        IList<CommentSummary> GetCommentSummary();
        void AddEntry(GuestbookEntry entry);
    }

    public class GuestbookRepository : IGuestbookRepository
    {
        private GuestbookContext _db = new GuestbookContext();
        public IList<GuestbookEntry> GetMostRecentEntries()
        {
            return (_db.Entries.OrderByDescending(entry => entry.DateAdded)).Take(20).ToList();
        }
        public void AddEntry(GuestbookEntry entry)
        {
            entry.DateAdded = DateTime.Now;
            _db.Entries.Add(entry);
            _db.SaveChanges();
        }
        public GuestbookEntry FindById(int id)
        {
            var entry = _db.Entries.Find(id);
            return entry;
        }
        public IList<CommentSummary> GetCommentSummary()
        {
            var entries =
                _db.Entries.GroupBy(entry => entry.Name)
                   .OrderByDescending(groupedByName => groupedByName.Count())
                   .Select(groupedByName => new CommentSummary
                                                {
                                                    NumberOfComments = groupedByName.Count(),
                                                    UserName = groupedByName.Key
                                                });
            return entries.ToList();
        }
    }

    public class FakeGuestbookRepository : IGuestbookRepository
    {
        private List<GuestbookEntry> _entries = new List<GuestbookEntry>();
        public IList<GuestbookEntry> GetMostRecentEntries()
        {
            return new List<GuestbookEntry>{
               new GuestbookEntry
                 {
                         DateAdded = new DateTime(2011, 6, 1),
                          Id = 1,
                          Message = "Test message",
                          Name = "Jeremy"
                  }
            };
        }

        public void AddEntry(GuestbookEntry entry)
        {
            _entries.Add(entry);
        }
        public GuestbookEntry FindById(int id)
        {
            return _entries.SingleOrDefault(x => x.Id == id);
        }
        public IList<CommentSummary> GetCommentSummary()
        {
            return new List<CommentSummary>
            {
                new CommentSummary
                {
                  UserName = "Jeremy", NumberOfComments = 1
                }
            };
        }
    }


}
