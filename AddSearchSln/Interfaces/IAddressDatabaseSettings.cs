﻿namespace AddSearchSln.Interfaces
{
    public interface IAddressDatabaseSettings
    {
        string AddressCollectionName { get; set; }
        string AddressFormatCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    
    }
}