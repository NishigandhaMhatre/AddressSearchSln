
using AddSearchSln.Interfaces;
using AddSearchSln.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AddSearchSln.Services
{
 

    public class AddressService : IAddressHandler
    {
        private readonly IMongoCollection<AddressModel> addresses;
        private readonly IMongoCollection<AddressFormatModel> addressesFormat;

        public AddressService(IAddressDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            addresses = database.GetCollection<AddressModel>(settings.AddressCollectionName);
            addressesFormat = database.GetCollection<AddressFormatModel>(settings.AddressFormatCollectionName);
        }

        public List<AddressModel> GetAddress() =>
            addresses.Find(AddressModel => true).ToList();
        public List<AddressFormatModel> GetAddressFormat() =>
             addressesFormat.Find(AddressFormatModel => true).ToList();

        public AddressModel Get(string id) =>
            addresses.Find<AddressModel>(address => address.Id == id).FirstOrDefault();

        public AddressModel Add(AddressModel address)
        {
            AddressModel temp = new AddressModel();
            temp.AddressLine1 = address.AddressLine1;
            temp.AddressLine2 = address.AddressLine2;
            temp.StateOrCounty = address.StateOrCounty;
            temp.PostCode = address.PostCode;
            temp.Country = address.Country;
            try
            {
                addresses.InsertOne(temp);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("insert failed", ex);
                return temp;
            }

            return temp;
        }

        public List<AddressModel> SearchAddress(string country, string addressLine1, string addreessLine2, string stateOrCounty, string postcode)
        { 
            var result =
                addresses.AsQueryable<AddressModel>()
                .Where(c => c.Country.Contains(country) && c.AddressLine1.Contains(addressLine1)
                            && c.AddressLine2.Contains(addreessLine2) && c.StateOrCounty.Contains(stateOrCounty)
                            &&c.PostCode.Contains(postcode));
            if (result != null)
            {
                return result.ToList();
            }
            return null;
        }

        public AddressFormatModel SearchAddressFormat( string country)
        {
            var result =
                 addressesFormat.AsQueryable<AddressFormatModel>()
                 .Where(c => c.Country.Contains(country));
            return result.FirstOrDefault();
        }

                public void Update(string id, AddressModel addressIn) =>
            addresses.ReplaceOne(address => address.Id == id, addressIn);


        public void Remove(AddressModel addressIn) =>
            addresses.DeleteOne(address => address.Id == address.Id);

        public void Remove(string id) =>
            addresses.DeleteOne(address => address.Id == id);
    }
}
