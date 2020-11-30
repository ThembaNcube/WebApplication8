using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication8.Models
{
    public class UploadsModel
    {
        [BsonId]
        //public ObjectId Id { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; }

        [BsonElement("Subject_Code")]
        public string Subject_Code { get; set; }

        [BsonElement("Subject_Name")]
        public string Subject_Name { get; set; }

        [BsonElement("Study_Year")]
        public string Study_Year { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Hashtags")]
        public string Hashtags { get; set; }

        [BsonElement("File_Upload")]
        public string File_Upload { get; set; }
    }
}