﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace AddSearchSln.Models
{
    public class AddressModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        public string Country { get; set; } = null;
        public string AddressLine1 { get; set; } = null;
        public string AddressLine2 { get; set; } = null;
        public string StateOrCounty { get; set; } = null;
        public string PostCode { get; set; } = null;

       
    }
}
