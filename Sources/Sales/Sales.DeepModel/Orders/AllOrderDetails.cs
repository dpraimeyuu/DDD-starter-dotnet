﻿using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using MyCompany.Crm.TechnicalStuff.Metadata;

namespace MyCompany.Crm.Sales.Orders
{
    [DataStructure]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AllOrderDetails
    {
        //TODO: DomainModel + Raw
        public Guid ClientId { get; set; }
        public string CurrencyCode { get; set; }
        public List<OrderItemDetails> Items { get; set; }
        
        // TODO: invoicing details, notes, etc.
    }
}