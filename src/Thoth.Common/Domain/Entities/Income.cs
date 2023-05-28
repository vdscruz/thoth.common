using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Thoth.Common.Domain.Entities;

namespace Thoth.Common.Domain.Entities;

[Table("income")]
public class Income: ModelBase
{
    public DateTime Date { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitValue { get; set; }
    public decimal TotalValue { get; set; }
    public Guid AssetId { get; set; }

    [JsonIgnore]
    public virtual Asset Asset { get; set; } = null!;
    public Income():base()
    {
        
    }
}
