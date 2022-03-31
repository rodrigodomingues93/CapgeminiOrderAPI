namespace CapgeminiOrderAPI.Models
{
	public class OrderModel
	{
		public Guid Id { get; set; }
		public string Number { get; set; }
		public string Client { get; set; }
		public string Adress { get; set; }
		public string Product { get; set; }
	}
}
