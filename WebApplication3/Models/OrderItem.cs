using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Top_Hat_App.Models;

public partial class OrderItem
{
    public int Id { get; set; }

    public int? Orderid { get; set; }

    public int? Itemid { get; set; }

    public int Quantity { get; set; }

    public decimal Subtotal { get; set; }
    [JsonIgnore]
    public virtual MenuItem? Item { get; set; }
    [JsonIgnore]
    public virtual Order? Order { get; set; }
}
