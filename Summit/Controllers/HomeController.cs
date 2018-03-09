using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Firebase.Storage;

namespace Summit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            ViewBag.Title = "Upload";

            if (file.ContentLength > 0)
            {
                string _FileName = Path.GetFileName(file.FileName);
                string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                file.SaveAs(_path);
                uploadImage(_path);
                ViewBag.Message = "File Uploaded Successfully!!";
               
            }


            return View();
        }


        public void uploadImage(string file)
        {




            // Get any Stream — it can be FileStream, MemoryStream or any other type of Stream
            var stream = System.IO.File.Open(file, FileMode.Open);      //add file path over here..

            //creating a file name
            Random random = new Random();
            int number = random.Next(50);
            var name = RandomString(number);
            name = name + ".png";

            // Construct FirebaseStorage with path to where you want to upload the file and put it there
            var task = new FirebaseStorage("annualsumm.appspot.com")
             .Child("data")
             .Child("summit")
             .Child(name)     // change the file name here
             .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");
            //            System.Threading.Thread.Sleep(5000);
            // Await the task to wait until upload is completed and get the download url from the task variable
            var downloadUrl = task;   //unable to get the url, need some fix
        }
        


    }
}
