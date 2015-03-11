using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing;
using ZXing.QrCode;
using System.Threading;
using camera.Models;
using camera.DAL;
using System.Net;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace camera.Controllers
{
    public class HomeController : Controller
    {
        
        //declares connection to test db context
        //private TLSContext db = new TLSContext();
        private tls_dbEntities db = new tls_dbEntities();
        // GET: /Home/
        public ActionResult Index()
        {

            return View();
        }

        public void Capture()
        {
            //this gets the stream from the camera
            var stream = Request.InputStream;
            //variable to hold string
            string dump;
            //using streamreader to read image file and storing in dump variable
            using (var reader = new StreamReader(stream))
                dump = reader.ReadToEnd();
            //declaring the path to save too
            var path = Server.MapPath("~/test.jpg");
            //write the file to disk once it has returned from the String_To_Bytes method
            System.IO.File.WriteAllBytes(path, String_To_Bytes2(dump));
        }

        public void Decode()
        {
            //map path of file to be read
            //this could be replaced by inputting the direct stream from the camera or passing the byte array directly
            var path = Server.MapPath("~/test.png");
            //creates a new bitmap from the file in the path
            Bitmap bitmap = new Bitmap(path);

            //tries to scan the qr image converted from above
            try
            {
                //new instance of barcode reader
                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryHarder = true };
                //declare result equal to the decoding of the bitmap
                Result result = reader.Decode(bitmap);
                //store res in string variable
                string res = result.Text;
                //send result for more processing
                ProcessCode(res);
            }
            catch
            {
                //throw error if qr cannot be scanned
                throw new Exception("Cannot decode the QR code");
            }

        }
        private byte[] String_To_Bytes2(string strInput)
        {
            //count the length bytes.
            int numBytes = (strInput.Length) / 2;
            //create a byte array to store the length
            byte[] bytes = new byte[numBytes];

            //for loop that converts the byte array 
            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }
            //return the byte[] array
            return bytes;
        }
        //
        // GET: /Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public void ProcessCode(string res)
        {
            //declare input = res 
            string input = res;
            //set pattern for regex
            string pattern = "(-)";
            string email;
            string date;
            //get the current date 
            string currentday = System.DateTime.Today.ToShortDateString();

            string[] substrings = Regex.Split(input, pattern);    // Split on hyphens

            foreach (string match in substrings)
            {
                //set email and date = data read from qr
                email = substrings[0];
                date = substrings[2];
                //do something if todays date matches
                if (currentday.Equals(date))
                {
                    ResultList(1);
                }
            }
        }
        //
        // GET: /Home/Create
        [HttpGet]
        public ActionResult Success(string id)
        {
            //int usid = Convert.ToInt32(id);
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //User user = db.Users.Find(usid);
            //if (user == null)
            //{
            //    return HttpNotFound();
            //}
            return PartialView("_Success");
        }
        [HttpGet]
        public JsonResult ResultByEmail()
        {
            //var stream = Request.InputStream;
            //string dump;

            //using (var reader = new StreamReader(stream))
            //    dump = reader.ReadToEnd();

            ////var path = Server.MapPath("~/test.jpg");
            //int numBytes = (dump.Length) / 2;
            //byte[] bytes = new byte[numBytes];

            //for (int x = 0; x < numBytes; ++x)
            //{
            //    bytes[x] = Convert.ToByte(dump.Substring(x * 2, 2), 16);
            //}
            var path = Server.MapPath("~/test.jpg");

            //set pattern for regex
            string pattern = "(-)";
            string date;
            string email;
            //byte[] imgbytes = String_To_Bytes2(dump);
            Bitmap bmp = new Bitmap(path);
            string res;
            try
            {
                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryHarder = true };
                //declare result equal to the decoding of the bitmap
                Result result = reader.Decode(bmp);
                //store res in string variable
                res = result.Text;
            }
            //get the current date 
            catch
            {
                res = "Login Failed-" + System.DateTime.Today.ToShortDateString();
            }

            string[] substrings = Regex.Split(res, pattern);    // Split on hyphens
            //store values in seperate string 
            email = substrings[0];
            date = substrings[2];
            //query mysql db
            var udet = from ca in db.customers
                       where ca.email == email
                       select new
                       {
                           ca.CustomerName,
                           ca.CustomerID
                       };
            
            //do something if todays date matches
            //if (currentday.Equals(date))
            //{
            //    //ResultList(email);
            //}
            return Json(udet, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult ResultList(int id)
        {
            //query to grab user details based on email match in db
            var jsonResult = from ca in db.customers
                             where ca.CustomerID == id
                             select new
                                 {
                                     ca.CustomerID,
                                     ca.CustomerName, // other Customer properties you desire
                                 };
            //returns json result
            return Json(jsonResult, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Failure()
        {
            return PartialView("_failure");
        }
        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
