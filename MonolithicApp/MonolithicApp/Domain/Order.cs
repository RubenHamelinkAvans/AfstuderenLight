namespace MonolithicApp.Domain
{
    public class Order
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string Item { get; set; }

        public Order()
        {
        }

        public Order(string customerId, string item)
        {
            CustomerId = customerId;
            Item = item;
        }

        public Order(string id, string customerId, string item)
        {
            Id = id;
            CustomerId = customerId;
            Item = item;
        }
    }
}