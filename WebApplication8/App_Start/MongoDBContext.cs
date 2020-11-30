using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;

namespace WebApplication8.App_Start
{
    public class MongoDBContext
    {
        MongoClient client;
        public IMongoDatabase database;
        
        public MongoDBContext()
        {
            var mongoClient = new MongoClient("mongodb+srv://Themba:Replica@cluster0.1sews.mongodb.net/Opportunities_Galore?retryWrites=true&w=majority");
            database = mongoClient.GetDatabase("Opportunities_Galore");
        }
    }
}