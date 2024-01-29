using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Top_Hat_App.Models;

public partial class Cart
{
    public int Id { get; set; }

    public int? Userid { get; set; }

    public int? Itemid { get; set; }

    public int Quantity { get; set; }
    [JsonIgnore]
    public virtual MenuItem? Item { get; set; }
    [JsonIgnore]
    public virtual User? User { get; set; }
}
