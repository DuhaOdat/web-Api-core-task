namespace taskTwoAPICore.DTOfolder
{
    public class AddCartRequest
    {
        public int? CartId { get; set; }

        public int? ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
