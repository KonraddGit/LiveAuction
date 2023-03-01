namespace LiveAuction.Domain.Entities;

public class Order
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime OrderPlaced { get; set; }
    public decimal OrderTotal { get; set; }
    public bool OrderPaid { get; set; }
}