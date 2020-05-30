namespace CellService.Settings
{
   public interface ICellServiceDataStoreSettings
    {
        string CollectionName { get; set; }
        string ChunkCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }

    public class CellServiceDatastoreSettings : ICellServiceDataStoreSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ChunkCollectionName { get; set; }

    }
}

