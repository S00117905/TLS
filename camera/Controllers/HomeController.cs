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

namespace camera.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        public ActionResult Index()
        {

            return View();
        }
        
        public void Capture()
        {
            
            var stream = Request.InputStream;
            string dump;

            using (var reader = new StreamReader(stream))
                dump = reader.ReadToEnd();
            //Decode(dump);
            var path = Server.MapPath("~/test.jpg");
            System.IO.File.WriteAllBytes(path, String_To_Bytes2(dump));
        }
        public void Decode(string dump)
        {
            var path = Server.MapPath("~/test.jpg");
            Bitmap bitmap = new Bitmap(path);
            //Bitmap bitmap = new Bitmap(dump);

            try
            {
                BarcodeReader reader = new BarcodeReader { AutoRotate = true, TryHarder = true };
                Result result = reader.Decode(bitmap);
                string decodedData = result.Text;
                //DetPartial(decodedData);
            }
            catch
            {
                throw new Exception("Cannot decode the QR code");
            }
          
        }

        //public FileContentResult GetImage()
        //{
        //    if (scan.Photo != null)
        //    {
        //        return File(scan.Photo, "jpg");
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        private byte[] String_To_Bytes2(string strInput)
        {
            int numBytes = (strInput.Length) / 2;
            byte[] bytes = new byte[numBytes];

            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }

            return bytes;
        }
        //
        // GET: /Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create
        public ActionResult DetPartial(string decodedData)
        {
            int usid = Convert.ToInt32(decodedData);
            //var scan = new ScanResult(3, "neil@fallon.ie");
            ScanResult model = new ScanResult(usid, "neil@fallon.ie");
            //model.UserID = Convert.ToInt32(decodedData);
            //model.Email = "neil@fallon.ie";
            return PartialView("DetPartial", model);
        }
        public ActionResult Success()
        {
            int usid = 1;
            ScanResult model = new ScanResult(usid, "neil@fallon.ie");         
            return PartialView("_Success", model);
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
