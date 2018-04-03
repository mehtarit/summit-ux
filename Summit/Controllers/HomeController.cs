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
            public string Extra;
            public EventSession(string Time, string Title)
            {
                this.Time = Time;
                this.Title = Title;
            }
            public EventSession(string Time, string Title, string Extra)
            {
                this.Time = Time;
                this.Title = Title;
                this.Extra = Extra;
            }
        }
        public class EventDay
        {
            public string location;
            public List<Groups> Groups;
        }
        public class Groups
        {
            public List<EventSession> Sessions;
        }
        public ActionResult Index(string Region, string Program)
        {
            ViewBag.Title = "Home Page";
            ViewBag.Region = Region = String.IsNullOrEmpty(Region) ? "Austin" : Region;

            ViewBag.Program = Program = String.IsNullOrEmpty(Program) ? "ITDP" : Program;

            ViewBag.Regions = new string[] { "India", "Austin", "Malaysia" };
            if(Region == "Austin")
                ViewBag.Programs = new string[] { "ITDP", "ITLP Cohort 1", "ITLP Cohort 2" };
            else
                ViewBag.Programs = new string[] { "ITDP", "ITLP"};
            if (Region == "India")
            {
                ViewBag.Date = "June 20-22, 2018";
                if (Program == "ITLP Cohort 1" || Program == "ITLP Cohort 2")
                {
                    ViewBag.Program = "ITLP";
                    Program = "ITLP";
                }
            }
            if (Region == "Malaysia")
            {
                ViewBag.Date = "June 26-27, 2018";
                if (Program == "ITLP Cohort 1" || Program == "ITLP Cohort 2")
                {
                    ViewBag.Program = "ITLP";
                    Program = "ITLP";
                }
            }
            if (Region == "Austin")
                ViewBag.Date = "May 08-10, 2018";
            ViewBag.LatLngs = new KeyValuePair<string, string>[] {  new KeyValuePair<string, string>("Austin", "30.266620,-97.740375"),
                                                                    new KeyValuePair<string, string>("India", "28.580132,77.189365"),
                                                                    new KeyValuePair<string, string>("Malaysia", "3.153875,101.714669")
                                                                  };
            ViewBag.Agenda = GetAgenda(Region, Program);
            ViewBag.Sessions = GetSessions(Region, Program);
            return View();
        }

        private List<string> GetSessions(string region, string program)
        {
            List<string> sessions = new List<string>();
            if (region.ToLower() == "austin")
            {
                sessions.Add("Ajaz and speaker from DT World");
                sessions.Add("Digital Transformation panel");
                sessions.Add("Pivotal");
                if (program.ToLower() != "itdp")
                {
                    sessions.Add("Sara Canaday or Hogan?");
                    sessions.Add("Finance for Non Finance?");
                    sessions.Add("Career Panel?");
                }
                else if(program.ToLower() == "itdp")
                {
                    sessions.Add("Digital IT Future State Simulation");
                    sessions.Add("Coaching by ITLPs");
                    sessions.Add("Judging by Kavitha and Ujjwal");
                }
                if(program.ToLower() == "itlp cohort 1")
                {
                    sessions.Add("Coaching by Goal Success");
                    sessions.Add("Biz simulation by Abilitie");
                }
                else if(program.ToLower() == "itlp cohort 2")
                {
                    sessions.Add("Influence/Presence by DD Sales");
                    sessions.Add("Advancing your career by Christi Miller");
                }
            }
            return sessions;
        }

        public List<EventDay> GetAgenda(string Region, string Program)
        {

            List<EventDay> Agenda = new List<EventDay>();
            Groups group;
            EventDay day_one;
            switch (Region.ToLower())
            {
                case "austin":
                    //First day
                    switch (Program.ToLower())
                    {
                        case "itlp cohort 1":
                        case "itlp cohort 2":
                            day_one = new EventDay();
                            day_one.location = "Pumeria";
                            day_one.Groups = new List<Groups>();
                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("07:15 AM - 08:15AM", "Breakfast & Registration"));
                            group.Sessions.Add(new EventSession("08:15 AM - 09:00AM", "Welcome"));
                            day_one.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("09:00 AM - 12:00PM", "Sara Canaday or Hogan?"));
                            group.Sessions.Add(new EventSession("12:00 PM - 01:00PM", "Lunch"));
                            day_one.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("01:00 PM - 03:00PM", "Finance or Non Finance?"));
                            group.Sessions.Add(new EventSession("03:00 PM - 03:15PM", "Break"));
                            day_one.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("03:15 PM - 05:00PM", "Career Panel", "Pat, Cheryl"));
                            group.Sessions.Add(new EventSession("05:00 PM - 05:15PM", "Wrap Up"));
                            day_one.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("05:15 PM - 07:00PM", "Exec Networking", "Westin Lobby Restaurant Private Dining Room"));
                            day_one.Groups.Add(group);

                            Agenda.Add(day_one);
                            break;
                    }
                    //Preparing day two with respect to programs
                    EventDay day_two = new EventDay();
                    day_two.location = "Primrose ABC";
                    day_two.Groups = new List<Groups>();
                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("07:15 AM - 08:15AM", "Breakfast & Registration"));
                    group.Sessions.Add(new EventSession("08:15 AM - 09:15AM", "Welcome(Scott Pittman)/ Opening Ceremony"));
                    group.Sessions.Add(new EventSession("09:15 AM - 09:45AM", "Agenda", "Jennifer/Kelli"));
                    group.Sessions.Add(new EventSession("09:45 AM - 10:15AM", "Break"));
                    day_two.Groups.Add(group);

                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("10:15 AM - 11:45AM", "Ajaz + Speaker from DT World"));
                    group.Sessions.Add(new EventSession("11:45 AM - 12:45PM", "Lunch"));
                    day_two.Groups.Add(group);

                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("12:45 PM - 02:15PM", "Digital Transformation Panel", "Louise- Facilitator, Jaynene"));
                    group.Sessions.Add(new EventSession("02:15 PM - 02:45PM", "Team Contest/ Activity"));
                    group.Sessions.Add(new EventSession("02:45 PM - 03:15PM", "Break"));
                    day_two.Groups.Add(group);

                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("03:15 PM - 04:45PM", "Pivotal", "Kathy Burgees"));
                    group.Sessions.Add(new EventSession("04:45 PM - 06:15PM", "Wrap Up /Raffle"));
                    group.Sessions.Add(new EventSession("06:15 PM - 06:30PM", "Transition"));
                    day_two.Groups.Add(group);

                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("06:30 PM - 08:15PM", "Welcome Reception", "Punchbowl Social"));
                    day_two.Groups.Add(group);
                    Agenda.Add(day_two);

                    //Preparing day three with a mix of common + program specific sessions
                    EventDay day_three = new EventDay();
                    day_three.Groups = new List<Groups>();
                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("07:00 AM - 08:00AM", "Breakfast"));
                    switch (Program.ToLower())
                    {
                        case "itdp":
                            day_three.location = "Primrose ABC";
                            group.Sessions.Add(new EventSession("08:00 AM - 10:00AM", "Digital IT Future State Simulation", "Wronski"));
                            group.Sessions.Add(new EventSession("10:00 AM - 10:15AM", "Break"));
                            group.Sessions.Add(new EventSession("10:15 AM - 12:00PM", "Digital IT Future State Simulation", "Wronski"));
                            day_three.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("12:00 PM - 12:30PM", "Lunch"));
                            group.Sessions.Add(new EventSession("12:30 PM - 01:15PM", "Team Contest/Activity"));
                            day_three.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("01:15 PM - 03:00PM", "Digital IT Future State Simulation", "Wronski"));
                            group.Sessions.Add(new EventSession("03:00 PM - 03:15PM", "Break"));
                            group.Sessions.Add(new EventSession("03:15 PM - 04:15PM", "Coaching", "ITLPs"));
                            group.Sessions.Add(new EventSession("04:15 PM - 05:00PM", "Digital IT Future State Simulation", "Wronski"));
                            day_three.Groups.Add(group);

                            break;
                        case "itlp cohort 1":
                            day_three.location = "Rumeria";
                            group.Sessions.Add(new EventSession("08:00 AM - 10:00AM", "Coaching", "Goal Succcess"));
                            group.Sessions.Add(new EventSession("10:00 AM - 10:15AM", "Break"));
                            group.Sessions.Add(new EventSession("10:15 AM - 12:00PM", "Coaching", "Goal Succcess"));
                            day_three.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("12:00 PM - 12:30PM", "Lunch"));
                            group.Sessions.Add(new EventSession("12:30 PM - 01:15PM", "Team Contest/Activity"));
                            day_three.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("01:15 PM - 03:00PM", "Coaching", "Goal Succcess"));
                            group.Sessions.Add(new EventSession("03:00 PM - 03:15PM", "Break"));
                            group.Sessions.Add(new EventSession("03:15 PM - 05:00PM", "Coaching", "Goal Succcess"));
                            day_three.Groups.Add(group);

                            break;
                        case "itlp cohort 2":
                            day_three.location = "Primrose D";
                            group.Sessions.Add(new EventSession("08:00 AM - 10:00AM", "Influence/Presence", "DD Sales"));
                            group.Sessions.Add(new EventSession("10:00 AM - 10:15AM", "Break"));
                            group.Sessions.Add(new EventSession("10:15 AM - 12:00PM", "Influence/Presence", "DD Sales"));
                            day_three.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("12:00 PM - 12:30PM", "Lunch"));
                            group.Sessions.Add(new EventSession("12:30 PM - 01:15PM", "Team Contest/Activity"));
                            day_three.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("01:15 PM - 03:00PM", "Influence/Presence", "DD Sales"));
                            group.Sessions.Add(new EventSession("03:00 PM - 03:15PM", "Break"));
                            group.Sessions.Add(new EventSession("03:15 PM - 05:00PM", "Influence/Presence", "DD Sales"));
                            day_three.Groups.Add(group);
                            break;
                    }
                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("05:00 PM - 05:15PM", "Wrap Up/Raffle"));
                    day_three.Groups.Add(group);
                    Agenda.Add(day_three);

                    EventDay day_four = new EventDay();
                    day_four.Groups = new List<Groups>();
                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("07:00 AM - 08:00AM", "Breakfast"));
                    switch (Program.ToLower())
                    {
                        case "itdp":
                            day_four.location = "Primrose ABC";
                            group.Sessions.Add(new EventSession("08:00 AM - 10:00AM", "Digital IT Future State Simulation", "Wronski"));
                            group.Sessions.Add(new EventSession("10:00 AM - 10:15AM", "Break"));
                            group.Sessions.Add(new EventSession("10:15 AM - 12:00PM", "Digital IT Future State Simulation", "Wronski"));
                            day_four.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("12:00 PM - 12:30PM", "Lunch"));
                            group.Sessions.Add(new EventSession("12:30 PM - 01:15PM", "Team Contest/Activity"));
                            day_four.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("01:15 PM - 03:00PM", "Digital IT Future State Simulation", "Wronski"));
                            group.Sessions.Add(new EventSession("03:00 PM - 03:15PM", "Break"));
                            group.Sessions.Add(new EventSession("03:15 PM - 04:15PM", "Judging", "Kavitha/Ujjwal"));
                            group.Sessions.Add(new EventSession("04:15 PM - 05:00PM", "Awards", "Wronski"));
                            day_four.Groups.Add(group);

                            break;
                        case "itlp cohort 1":
                            day_four.location = "Rumeria";
                            group.Sessions.Add(new EventSession("08:00 AM - 10:00AM", "Biz Simulation", "Abilitie"));
                            group.Sessions.Add(new EventSession("10:00 AM - 10:15AM", "Break"));
                            group.Sessions.Add(new EventSession("10:15 AM - 12:00PM", "Biz Simulation", "Abilitie"));
                            day_four.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("12:00 PM - 12:30PM", "Lunch"));
                            group.Sessions.Add(new EventSession("12:30 PM - 01:15PM", "Team Contest/Activity"));
                            day_four.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("01:15 PM - 03:00PM", "Biz Simulation", "Abilitie"));
                            group.Sessions.Add(new EventSession("03:00 PM - 03:15PM", "Break"));
                            group.Sessions.Add(new EventSession("03:15 PM - 05:00PM", "Biz Simulation", "Abilitie"));
                            day_four.Groups.Add(group);

                            break;
                        case "itlp cohort 2":
                            day_four.location = "Primrose D";
                            group.Sessions.Add(new EventSession("08:00 AM - 10:00AM", "Advancing your career", "Christi Miller"));
                            group.Sessions.Add(new EventSession("10:00 AM - 10:15AM", "Break"));
                            group.Sessions.Add(new EventSession("10:15 AM - 12:00PM", "Advancing your career", "Christi Miller"));
                            day_four.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("12:00 PM - 12:30PM", "Lunch"));
                            group.Sessions.Add(new EventSession("12:30 PM - 01:15PM", "Team Contest/Activity"));
                            day_four.Groups.Add(group);

                            group = new Groups();
                            group.Sessions = new List<EventSession>();
                            group.Sessions.Add(new EventSession("01:15 PM - 03:00PM", "Advancing your career", "Christi Miller"));
                            group.Sessions.Add(new EventSession("03:00 PM - 03:15PM", "Break"));
                            group.Sessions.Add(new EventSession("03:15 PM - 05:00PM", "Advancing your career", "Christi Miller"));
                            day_four.Groups.Add(group);
                            break;
                    }
                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("05:00 PM - 05:15PM", "Graduate Recognition \r\n Wrap Up/Raffle/Team Awards \r\n Group Picture/Cocktail Reception \r\n w Managers of DPs/LPs, Execs"));
                    day_four.Groups.Add(group);
                    Agenda.Add(day_four);

                    break;
                case "india":
                    //First day
                    day_one = new EventDay();
                    day_one.Groups = new List<Groups>();
                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration india"));
                    group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Induction india"));
                    day_one.Groups.Add(group);
                    Agenda.Add(day_one);

                    //Preparing day two with respect to programs
                    day_two = new EventDay();
                    day_two.Groups = new List<Groups>();
                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    switch (Program.ToLower())
                    {
                        case "itdp":
                            group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for india ITDPs"));
                            break;
                        case "itlp":
                            group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for ITLPs"));
                            break;
                        case "leaders":
                            group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for Leaders"));
                            break;
                    }
                    day_two.Groups.Add(group);
                    Agenda.Add(day_two);
                    //Preparing day three with a mix of common + program specific sessions
                    day_three = new EventDay();
                    day_three.Groups = new List<Groups>();
                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for third day - Common"));
                    switch (Program.ToLower())
                    {
                        case "itdp":
                            group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for ITDPs"));
                            break;
                        case "itlp":
                            group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for ITLPs"));
                            break;
                        case "leaders":
                            group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for Leaders"));
                            break;
                    }
                    day_three.Groups.Add(group);
                    Agenda.Add(day_three);
                    break;
                case "malaysia":
                    //First day
                    day_one = new EventDay();
                    day_one.Groups = new List<Groups>();
                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration malaysia"));
                    group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Induction malaysia"));
                    day_one.Groups.Add(group);
                    Agenda.Add(day_one);

                    //Preparing day two with respect to programs
                    day_two = new EventDay();
                    day_two.Groups = new List<Groups>();
                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    switch (Program.ToLower())
                    {
                        case "itdp":
                            group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for malaysia ITDPs"));
                            break;
                        case "itlp":
                            group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for ITLPs"));
                            break;
                        case "leaders":
                            group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for Leaders"));
                            break;
                    }
                    day_two.Groups.Add(group);
                    Agenda.Add(day_two);
                    //Preparing day three with a mix of common + program specific sessions
                    day_three = new EventDay();
                    day_three.Groups = new List<Groups>();
                    group = new Groups();
                    group.Sessions = new List<EventSession>();
                    group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Breakfast & Registration for third day - Common"));
                    switch (Program.ToLower())
                    {
                        case "itdp":
                            group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for ITDPs"));
                            break;
                        case "itlp":
                            group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for ITLPs"));
                            break;
                        case "leaders":
                            group.Sessions.Add(new EventSession("08:00 AM - 09:00AM", "Specific for Leaders"));
                            break;
                    }
                    day_three.Groups.Add(group);
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
