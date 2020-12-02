using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Driver.Core;
using MongoDB.Bson;
using WebApplication8.App_Start;
using WebApplication8.Models;
using MongoDB.Driver;

namespace WebApplication8.Controllers
{
   
    public class UploadsController : Controller
    {
        private MongoDBContext dbContext;
        private IMongoCollection<UploadsModel> uploadsCollection;

        public UploadsController()
        {
            dbContext = new MongoDBContext();
            uploadsCollection = dbContext.database.GetCollection<UploadsModel>("Uploads");

        }
        // GET: Uploads
        public ActionResult Index()
        {
            
            List<UploadsModel> uploads = uploadsCollection.AsQueryable<UploadsModel>().ToList();
            return View(uploads);
        }

        [HttpGet]
        public ActionResult Index(string search)
        {
            ViewBag.search = search;
            
            List<UploadsModel> uploads = uploadsCollection.AsQueryable<UploadsModel>().ToList();
            var fquery = from x in uploads select x;

            if (!String.IsNullOrEmpty(search))
            {
                fquery = fquery.Where(x => x.Subject_Code.Contains(search) || x.Subject_Name.Contains(search) || x.Hashtags.Contains(search));
            }
            //List<UploadsModel> uploads = uploadsCollection.AsQueryable<UploadsModel>().ToList();
            return View(fquery.ToList());
        }


        // GET: Uploads/Details/5


        // GET: Uploads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uploads/Create
        [HttpPost]
        public ActionResult Create(UploadsModel uploads)
        {
            try
            {
                uploadsCollection.InsertOne(uploads);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Uploads/Edit/5
        public ActionResult Edit(string id)
        {
            var uploadId = id;
            var upload = uploadsCollection.AsQueryable<UploadsModel>().SingleOrDefault(x => x.Id == uploadId);
            //var upload = uploadsCollection.AsQueryable<UploadsModel>().SingleOrDefault(x => x.Id == id);
            return View(upload);
        }

        // POST: Uploads/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, UploadsModel uploads)
        {
            try
            {

                var filter = Builders<UploadsModel>.Filter.Eq("_id", ObjectId.Parse(id));
                //var filter = Builders<UploadsModel>.Filter.Eq("_id", uploads.Id);
                var update = Builders<UploadsModel>.Update
                    .Set("UserId", uploads.UserId)
                    .Set("Subject_Code", uploads.Subject_Code)
                    .Set("Subject_Name", uploads.Subject_Name)
                    .Set("Study_Year", uploads.Study_Year)
                    .Set("Description", uploads.Description)
                    .Set("Hashtags", uploads.Hashtags)
                    .Set("File_Upload", uploads.File_Upload);
                var result = uploadsCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Uploads/Delete/5
        public ActionResult Delete(string id)
        {
            var uploadId = id;
            var upload = uploadsCollection.AsQueryable<UploadsModel>().SingleOrDefault(x => x.Id == uploadId);
            return View(upload);
            
        }

        // POST: Uploads/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, UploadsModel uploads)
        {
            try
            {

                uploadsCollection.DeleteOne(Builders<UploadsModel>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
