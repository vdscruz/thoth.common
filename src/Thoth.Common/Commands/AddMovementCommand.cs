using Vdscruz.CQRS.Core.Commands;
using Thoth.Common.Enums;

namespace Thoth.Common.Commands;

public class AddMovementCommand : BaseCommand
{
    public DateTime DataOperacao { get; set; }
    public OperationType TipoDaOperacao { get; set; }
    public MovementType TipoDoMovimento { get; set; }
    public CurrencyType TipoDaMoeda { get; set; }
    public CategoryType Categoria { get; set; }
    public string Ticker { get; set; } = null!;
    public string NomeDoProduto { get; set; } = null!;
    public string NomeDaInstituicao { get; set; } = null!;
    public decimal Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal ValorDaMoedaNoDia { get; set; }
    public decimal ValorTotalOperacao { get; set; }
}