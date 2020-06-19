namespace MonolithicApp.Domain
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Customer()
        {
        }

        public Customer(string name)
        {
            Name = name;
        }

        public Customer(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}