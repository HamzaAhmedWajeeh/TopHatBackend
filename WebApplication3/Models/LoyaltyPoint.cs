using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Top_Hat_App.Models;

public partial class LoyaltyPoint
{
    public int Userid { get; set; }

    public int? Points { get; set; }
    [JsonIgnore]
    public virtual User User { get; set; } = null!;
}
