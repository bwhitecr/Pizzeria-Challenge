namespace LOR.Pizzeria.Application.Store.Queries
{
    /// <summary>
    /// Store details to show in the user interface.
    /// </summary>
    public class StoreDto
    {
        /// <summary>
        /// The unique identifier of the store.
        /// </summary>
        public string StoreId { get; set; }
        
        /// <summary>
        /// The name of the store.
        /// </summary>
        public string StoreName { get; set; }
    }
}