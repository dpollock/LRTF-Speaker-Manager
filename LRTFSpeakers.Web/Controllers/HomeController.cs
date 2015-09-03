﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Xsl;
using Humanizer;
using LinqToExcel;
using LRTFSpeakers.Web.Models;
using Newtonsoft.Json;

namespace LRTFSpeakers.Web.Controllers
{
    public class HomeController : Controller
    {
        SpeakerContext db = new SpeakerContext();
        public ActionResult Index()
        {
            var data = db.SpeakerDatas.ToList();
            return View(data);
        }

        public ActionResult GetImages()
        {
            var speakers = db.SpeakerDatas.ToList();

            WebClient webClient = new WebClient();
            foreach (var speaker in speakers)
            {
                try
                {
                    var fileextension = "";
                    if (speaker.Photo.EndsWith("png"))
                        fileextension = "png";
                    else if (speaker.Photo.EndsWith("jpg"))
                        fileextension = "jpg";
                    else if (speaker.Photo.EndsWith("jpeg"))
                        fileextension = "jpeg";

                    if (!string.IsNullOrWhiteSpace(fileextension))
                    {
                        string calcFilename = speaker.LastName + "-" + speaker.FirstName + "." + fileextension;
                       
                        webClient.DownloadFile(speaker.Photo, Server.MapPath("~/App_Data/Images/" + calcFilename.ToLower()));
                       // speaker.Photo =
                        //   $"/public/img/speakers/{speaker.LastName}-{speaker.FirstName}.{fileextension}".ToLower();
                    }
                 
                }
                catch (Exception ex )
                {
                    //return Content(ex.Message);
                }


            }
            db.SaveChanges();

            return Content("ok");

        }

        public ActionResult GetPresentationStats(string groupby, bool? filter)
        {
            var data = db.Presentations.Include("MainSpeaker").ToList();
            IEnumerable<IGrouping<string, Presentation>> result = data.GroupBy(d => d.Status.ToString());
            switch (groupby)
            {
                case "status":
                    result = data.GroupBy(d => d.Status.ToString());
                    break;
                case "track":
                    result = data.GroupBy(d => d.Track.ToString());
                    break;
                case "room":
                    result = data.GroupBy(d => d.Room);
                    break;
                default:
                    result = data.GroupBy(d => d.Status.ToString());
                    break;
            }



            var final = from g in result
                        select new { Grouping = g.Key, Count = g.Count(), Pres = g.Where(x => x.Status == Status.Accepted || !filter.GetValueOrDefault()).Select(p => new { p.TopicTitle, p.MainSpeaker.FullName, Status = p.Status.ToString() }) };


            return Content(JsonConvert.SerializeObject(final, Formatting.Indented), "json");
        }
        public ActionResult GetSpeakerJSON()
        {
            var data = db.Speakers.Include("Presentations").ToList();
            var result = data.Where(x => x.Presentations.Any(p => p.Status == Status.Accepted)).Select(x => new
            {
                //Edit = Url.Action("Edit", "Speakers", new { id = x.Id }, Request.Url.Scheme),
                x.Id,
                x.FirstName,
                x.LastName,
                x.Bio,
                x.Website,
                x.Twitter,
                x.Photo,
                x.Company,
                x.LinkedIn,
                Presentations = x.Presentations.Where(p => p.Status == Status.Accepted).Select(p => new
                {

                    //Edit = Url.Action("Edit", "Presentations", new { id = p.Id }, Request.Url.Scheme),
                    p.Id,
                    p.Track,
                    Topic = p.TopicTitle,
                    Description = p.TopicDescription
                })
            });

            return Content(JsonConvert.SerializeObject(result, Formatting.Indented), "json");


        }
        public ActionResult About()
        {

            var data = db.Speakers.ToList();
            foreach (var speaker in data)
            {
                speaker.FirstName = speaker.FirstName.Pascalize();
                speaker.LastName = speaker.LastName.Pascalize();
                speaker.Photo = $"/public/img/speakers/{speaker.LastName}-{speaker.FirstName}.png".ToLower();
            }
            db.SaveChanges();
            //var speakerNames = data.GroupBy(g=> new { g.FirstName, g.LastName});

            //foreach (var n in speakerNames)
            //{
            //    var speaker = n.First();
            //    var newSpeaker = new Speaker
            //    {
            //        Address = speaker.Address,
            //        Address2 = speaker.Address2,
            //        Bio = speaker.Bio,
            //        City = speaker.City,
            //        Email = speaker.Email,
            //        FirstName = speaker.FirstName,
            //        LastName = speaker.LastName,
            //        Photo = speaker.Photo,
            //        Phone = speaker.Phone,
            //        ShirtSize = speaker.ShirtSize,
            //        State = speaker.State,
            //        Website = speaker.Website,
            //        Zip = speaker.Zip,
            //        Presentations = n.Select(pres => new Presentation
            //        {
            //            CreatedOn = pres.CreatedOn,
            //            EntryID = pres.EntryID,
            //            TopicDescription = pres.TopicDescription,
            //            TopicTitle = pres.TopicTitle,
            //            Track = pres.Track
            //        }).ToList()
            //    };



            //    db.Speakers.Add(newSpeaker);
            //}

            //db.SaveChanges();
            var excel = new ExcelQueryFactory(@"c:\ironyard\lrtf2015.csv");
            var speakerdata = from c in excel.Worksheet<SpeakerData>()
                              select c;


            //db.SpeakerDatas.AddRange(speakerdata);
            //db.SaveChanges();

            return View(new List<SpeakerData>());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}