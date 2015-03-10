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

namespace camera.Controllers
{
    public class HomeController : Controller
    {
        //declares connection to test db context
        private TLSContext db = new TLSContext();

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
                    ResultList(email);
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
        public JsonResult ResultList(string email)
        {
            //query to grab user details based on email match in db
            var jsonResult = from u in db.Users
                             where u.Email == email
                             select new
                                 {
                                     u.UserID,
                                     u.Name, // other Customer properties you desire
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
