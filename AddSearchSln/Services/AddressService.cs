using AddressSearchAlpha.Models;
using AddSearchSln.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressSearchAlpha.Services
{
 

    public class AddressService : IAddressHandler
    {
        private readonly IMongoCollection<AddressModel> addresses;

        public AddressService(IAddressDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            addresses = database.GetCollection<AddressModel>(settings.AddressCollectionName);
        }

        public List<AddressModel> Get() =>
            addresses.Find(AddressModel => true).ToList();

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
