
using AddSearchSln.Interfaces;
using AddSearchSln.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //public List<AddressModel> Get() =>
        //    addresses.Find(AddressModel => true).ToList();
        public List<AddressFormatModel> Get() =>
    addressesFormat.Find(AddressFormatModel => true).ToList();

        public AddressModel Get(string id) =>
            addresses.Find<AddressModel>(address => address.Id == id).FirstOrDefault();

        public AddressModel Create(AddressModel address)
        {
            addresses.InsertOne(address);
            return address;
        }

        public void Update(string id, AddressModel addressIn) =>
            addresses.ReplaceOne(address => address.Id == id, addressIn);

        public void Remove(AddressModel addressIn) =>
            addresses.DeleteOne(address => address.Id == address.Id);

        public void Remove(string id) =>
            addresses.DeleteOne(address => address.Id == id);
    }
}
