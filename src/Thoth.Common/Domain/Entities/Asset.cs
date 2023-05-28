using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Thoth.Common.Enums;
using Thoth.Common.Domain.Entities;

namespace Thoth.Common.Domain.Entities;

[Table("asset")]
public class Asset: ModelBase
{
    public string Ticker { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string Sector { get; set; } = null!;
    public decimal AveragePrice { get; set; }
    public decimal InvestedAmount { get; set; }
    public decimal Quantity { get; set; }
    public CategoryType Category { get; set; }
    public CurrencyType Currency { get; set; }
    public virtual ICollection<Income> Incomes { get; set; } = null!;
    public virtual ICollection<Movement> Movements { get; set; } = null!;

    public Asset():base()
    {
        
    }

}
