using BookReadingApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookReadingApp.Controllers
{
    public class EventController : Controller
    {
        private readonly DataContext _db;
        public EventController(DataContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var allEvents = _db.Events.Where(u => u.EventType == EventType.Public || u.EventType == EventType.Private);
                var upcoming = allEvents.Where(u => u.StartTime > DateTime.Now).ToList();
                var past = allEvents.Where(u => u.StartTime < DateTime.Now).ToList();
                var AllEvents = new PastUpcomingEventsDTO()
                {
                    UpcomingEvents = upcoming,
                    PastEvents = past
                };
                return View(AllEvents);
            }
            else
            {
                var allEvents = _db.Events.Where(u => u.EventType == EventType.Public);
                var upcoming = allEvents.Where(u => u.StartTime > DateTime.Now).ToList();
                var past = allEvents.Where(u => u.StartTime < DateTime.Now).ToList();
                var AllEvents = new PastUpcomingEventsDTO()
                {
                    UpcomingEvents = upcoming,
                    PastEvents = past
                };
                return View(AllEvents);
            }
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Event obj)
        {
            // var identity = User.Identity.Name;
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            obj.UserId = claim.Value;
            obj.Date = DateTime.Now;
           
            if (ModelState.IsValid)
            {
                _db.Events.Add(obj);
                _db.SaveChanges();
                if(obj.InviteByEmail.Length>0)
                {
                    string[] inviteArray = obj.InviteByEmail.Split(',');
                    foreach(var inv in inviteArray)
                    {
                        var invitation = new Invitation()
                        {
                            Invitee = inv,
                            EventId = obj.Id
                        };
                        _db.Invitations.Add(invitation);
                        _db.SaveChanges();
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public IActionResult MyEvents()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var events = _db.Events.Where(u => u.UserId == claim.Value).OrderBy(u => u.Date).ToList();
            return View(events);
        }
        [Authorize]
        public IActionResult EventsInvitedTo()
        {
            
            var userName = User.Identity.Name;
            var events = from e in _db.Events join i in _db.Invitations
                         on e.Id equals i.EventId where i.Invitee == userName
                         select e;
            
            
            return View(events);
        }
        [HttpGet]
        public IActionResult ViewHome(int id)
        {
            var events = _db.Events.FirstOrDefault(u=>u.Id == id);
            var countInvitation = _db.Invitations.Count(u=>u.EventId == id);
            var pastComments = _db.Comments.Where(u => u.EventId == id).ToList();
            var eventModel = new EventViewModel()
            {
                Title = events.Title,
                StartTime = events.StartTime,
                Location = events.Location,
                Duration = events.Duration,
                Description = events.Discription,
                Others = events.Others,
                TotalInvited = countInvitation,
                PastComments = pastComments,
                EventId = id
            };
            return View(eventModel);
        }
        [Authorize]
        public IActionResult EventsInvitedToViewEvent(int id)
        {
            var events = _db.Events.FirstOrDefault(u => u.Id == id);
            var countInvitation = _db.Invitations.Count(u => u.EventId == id);
            var pastComments = _db.Comments.Where(u => u.EventId == id).ToList();
            var eventModel = new EventViewModel()
            {
                Title = events.Title,
                StartTime = events.StartTime,
                Location = events.Location,
                Duration = events.Duration,
                Description = events.Discription,
                Others = events.Others,
                TotalInvited = countInvitation,
                PastComments = pastComments,
                EventId = id
            };
            return View(eventModel);
        }
        [Authorize]
        public IActionResult EditMyEvent(int id)
        {
            var events = _db.Events.FirstOrDefault(u => u.Id == id);

            if(events == null)
            {
                return NotFound();
            }

            return View(events);
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditMyEvent(Event obj)
        {
            if (obj.StartTime < DateTime.Now)
            {
                ModelState.AddModelError("", "Past Event can't Edited");
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    obj.Date = DateTime.Now;
                    _db.Events.Update(obj);
                    _db.SaveChanges();
                }

                return RedirectToAction(nameof(MyEvents));
            }
        }

        [HttpPost]
        public IActionResult ViewHome(string comment, int eventId)
        {
            var name = "Anonymous";
            if (User.Identity.IsAuthenticated)
            {
                name = User.Identity.Name;
            }
            if (comment.Length > 0)
            {
                var newComment = new Comment()
                {
                    message = comment,
                    userName = name,
                    EventId = eventId
                };
                _db.Comments.Add(newComment);
                _db.SaveChanges();
            }
            return ViewHome(eventId);
        }
        [HttpPost]
        public IActionResult EventsInvitedToViewEvent(string comment,int eventId)
        {
            var name = "Anonymous";
            if (User.Identity.IsAuthenticated)
            {
                name = User.Identity.Name;
            }
            if (comment.Length > 0)
            {
                var newComment = new Comment()
                {
                    message = comment,
                    userName = name,
                    EventId = eventId
                };
                _db.Comments.Add(newComment);
                _db.SaveChanges();
            }
            return EventsInvitedToViewEvent(eventId);
        }
    }
}
