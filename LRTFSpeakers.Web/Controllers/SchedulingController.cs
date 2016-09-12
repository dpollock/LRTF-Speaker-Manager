using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LRTFSpeakers.Web.Models;
using System.Data.Entity;
using Humanizer;


namespace LRTFSpeakers.Web.Controllers
{
    public class SchedulingController : Controller
    {
        SpeakerContext db = new SpeakerContext();
        // GET: Scheduling
        public ActionResult Index()
        {
            var pres = db.Presentations.AsNoTracking().Include(p => p.MainSpeaker).Where(x => x.Status == Status.Accepted).ToList();
            foreach (var presentation in pres)
            {
                presentation.TopicTitle = presentation.TopicTitle.Truncate(50);
            }
            return View(pres);
        }
    }
}