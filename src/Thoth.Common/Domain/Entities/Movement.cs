using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Thoth.Common.Enums;
using Thoth.Common.Domain.Entities;

namespace Thoth.Common.Domain.Entities;

[Table("movement")]
public class Movement: ModelBase
{
    public DateTime Date { get; set; }
    public OperationType Operation { get; set; }
    public MovementType MovementType { get; set; }
    public CurrencyType Currency { get; set; }
    public CategoryType Category { get; set; }
    public string Ticker { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string InstitutionName { get; set; } = null!;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal CurrencyValueAtDay { get; set; }
    public decimal TotalValue { get; set; }
    public Guid AssetId { get; set; }

    [JsonIgnore]
    public virtual Asset Asset { get; set; } = null!;

    public Movement():base()
    {
        
    }
}
