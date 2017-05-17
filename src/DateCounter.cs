using System;
using MongoDB.Bson;

namespace mongo_aspnet_api
{

    public class MongoEntity
    {
        public ObjectId _id { get; set; }
    }

    public class DateCounter : MongoEntity
    {
        public DateTime LastCount{get;set;}

        public int Count{get;set;}
    }
}