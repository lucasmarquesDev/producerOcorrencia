using System;
using System.Collections.Generic;

namespace Template.Persistence.ContextExistings;

public partial class MsPickupPickupRel
{
    public decimal PickupRelId { get; set; }

    public decimal PickupId { get; set; }

    public decimal? PickupWorkflowIdApproved { get; set; }

    public decimal? PickupWorkflowIdDisapproved { get; set; }

    public decimal? TaxInvoiceIdLast { get; set; }
}
