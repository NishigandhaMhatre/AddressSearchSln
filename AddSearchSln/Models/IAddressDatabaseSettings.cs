namespace AddressSearchAlpha.Models
{
    public interface IAddressDatabaseSettings
    {
        string AddressCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    
    }
}