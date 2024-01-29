using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Top_Hat_App.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? Userid { get; set; }

    public int? Paymentid { get; set; }

    public DateTime? Orderdate { get; set; }

    public decimal Totalamount { get; set; }

    public string? Orderstatus { get; set; }

    public string? Paymentstatus { get; set; }
    [JsonIgnore]
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    [JsonIgnore]
    public virtual Payment? Payment { get; set; }
    [JsonIgnore]
    public virtual User? User { get; set; }
}
