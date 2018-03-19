using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Summit.Controllers
{
    public class HomeController : Controller
    {
        public class LatLng
        {
            public string VenueLatitude;
            public string VenueLongitude;
            public LatLng(string Lat, string Lng)
            {
                this.VenueLatitude = Lat;
                this.VenueLongitude = Lng;
            }
        }
        public class EventSession
        {
            public string Time;
            public string Title;
            public EventSession(string Time, string Title)
            {
                this.Time = Time;
                this.Title = Title;
            }
        }
        public class EventDay
        {
            public List<EventSession> Sessions;
        }
        public ActionResult Index(string Region, string Program)
        {
            ViewBag.Title = "Home Page";
            ViewBag.Region = Region = String.IsNullOrEmpty(Region) ? "Austin" : Region;

            ViewBag.Program = Program = String.IsNullOrEmpty(Program) ? "ITDP" : Program;

            ViewBag.Regions = new string[] { "India", "Austin", "Malaysia" };
            ViewBag.Programs = new string[] { "ITDP", "ITLP", "Leaders" };
            ViewBag.LatLngs = new KeyValuePair<string, string>[] {  new KeyValuePair<string, string>("Austin", "30.266620,-97.740375"),
                                                                    new KeyValuePair<string, string>("India", "28.580132,77.189365"),
                                                                    new KeyValuePair<string, string>("Malaysia", "3.153875,101.714669")
                                                                  };
            ViewBag.Agenda = GetAgenda(Region, Program);
            return View();
        }
        public List<EventDay> GetAgenda(string Region, string Program)
        {
            List<EventDay> Agenda = new List<EventDay>();
            switch (Region.ToLower())
            {
                case "austin":
                    //First day
                    EventDay day_one = new EventDay();
                    day_one.Sessions = new List<EventSession>();
                    day_one.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration Austin"));
                    day_one.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Induction austin"));
                    Agenda.Add(day_one);

                    //Preparing day two with respect to programs
                    EventDay day_two = new EventDay();
                    day_two.Sessions = new List<EventSession>();
                    switch (Program.ToLower())
                    {
                        case "itdp":
                            day_two.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for Austin ITDPs"));
                            break;
                        case "itlp":
                            day_two.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for ITLPs"));
                            break;
                        case "leaders":
                            day_two.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for Leaders"));
                            break;
                    }
                    Agenda.Add(day_two);
                    //Preparing day three with a mix of common + program specific sessions
                    EventDay day_three = new EventDay();
                    day_three.Sessions = new List<EventSession>();
                    day_three.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for third day - Common"));
                    switch (Program.ToLower())
                    {
                        case "itdp":
                            day_three.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for ITDPs"));
                            break;
                        case "itlp":
                            day_three.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for ITLPs"));
                            break;
                        case "leaders":
                            day_three.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for Leaders"));
                            break;
                    }
                    Agenda.Add(day_three);
                    break;
                case "india":
                    //First day
                    day_one = new EventDay();
                    day_one.Sessions = new List<EventSession>();
                    day_one.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration india"));
                    day_one.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Induction india"));
                    Agenda.Add(day_one);

                    //Preparing day two with respect to programs
                    day_two = new EventDay();
                    day_two.Sessions = new List<EventSession>();
                    switch (Program.ToLower())
                    {
                        case "itdp":
                            day_two.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for india ITDPs"));
                            break;
                        case "itlp":
                            day_two.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for ITLPs"));
                            break;
                        case "leaders":
                            day_two.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for Leaders"));
                            break;
                    }
                    Agenda.Add(day_two);
                    //Preparing day three with a mix of common + program specific sessions
                    day_three = new EventDay();
                    day_three.Sessions = new List<EventSession>();
                    day_three.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for third day - Common"));
                    switch (Program.ToLower())
                    {
                        case "itdp":
                            day_three.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for ITDPs"));
                            break;
                        case "itlp":
                            day_three.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for ITLPs"));
                            break;
                        case "leaders":
                            day_three.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for Leaders"));
                            break;
                    }
                    Agenda.Add(day_three);
                    break;
                case "malaysia":
                    //First day
                    day_one = new EventDay();
                    day_one.Sessions = new List<EventSession>();
                    day_one.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration malaysia"));
                    day_one.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Induction malaysia"));
                    Agenda.Add(day_one);

                    //Preparing day two with respect to programs
                    day_two = new EventDay();
                    day_two.Sessions = new List<EventSession>();
                    switch (Program.ToLower())
                    {
                        case "itdp":
                            day_two.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for malaysia ITDPs"));
                            break;
                        case "itlp":
                            day_two.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for ITLPs"));
                            break;
                        case "leaders":
                            day_two.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for Leaders"));
                            break;
                    }
                    Agenda.Add(day_two);
                    //Preparing day three with a mix of common + program specific sessions
                    day_three = new EventDay();
                    day_three.Sessions = new List<EventSession>();
                    day_three.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for third day - Common"));
                    switch (Program.ToLower())
                    {
                        case "itdp":
                            day_three.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for ITDPs"));
                            break;
                        case "itlp":
                            day_three.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for ITLPs"));
                            break;
                        case "leaders":
                            day_three.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for Leaders"));
                            break;
                    }
                    Agenda.Add(day_three);
                    break;
            }
            return Agenda;
        }
        public JsonResult GetLatitudeLongitude(string Region)
        {
            LatLng LL = null;
            switch (Region.ToLower())
            {
                case "austin":
                    LL = new LatLng("30.266620", "-97.740375");
                    break;
                case "india":
                    LL = new LatLng("28.580132", "77.189365");
                    break;
                case "malaysia":
                    LL = new LatLng("3.153875", "101.714669");
                    break;
                default:
                    LL = new LatLng("0", "0");
                    break;
            }
            return Json(LL);
        }

    }
}
