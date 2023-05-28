using Mediator;
using Thoth.Common.Enums;
using Vdscruz.CQRS.Core.Events;

namespace Thoth.Common.Events
{
    public class MovementAddedEvent : BaseEvent, INotification
    {
        public DateTime Date { get; set; }
        public OperationType OperationType { get; set; }
        public MovementType MovementType { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public CategoryType CategoryType { get; set; }
        public string Ticker { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string InstitutionName { get; set; } = null!;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal CurrencyValue { get; set; }
        public decimal TotalValue { get; set; }

        public MovementAddedEvent(string type) : base(type)
        {

        }
    }
}
