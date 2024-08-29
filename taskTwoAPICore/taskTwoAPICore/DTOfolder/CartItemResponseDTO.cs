namespace taskTwoAPICore.DTOfolder
{
    public class CartItemResponseDTO
    {
        public int CartItemId { get; set; }
        public int? CartId { get; set; }

        public int Quantity { get; set; }

        public productDTO? Product { get; set; }

    }

    public class productDTO
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
    }

}


