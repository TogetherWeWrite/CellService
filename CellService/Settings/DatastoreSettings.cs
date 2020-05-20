namespace CellService.Settings
{
   public interface ICellServiceDataStoreSettings
    {
        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class CellServiceDatastoreSettings : ICellServiceDataStoreSettings
    {
        public string UserCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}

