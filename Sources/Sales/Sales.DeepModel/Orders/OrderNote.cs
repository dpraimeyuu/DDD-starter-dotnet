using System;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyCompany.Crm.TechnicalStuff.Crud;
using MyCompany.Crm.TechnicalStuff.Metadata;

namespace MyCompany.Crm.Sales.Orders
{
    [DataStructure]
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class OrderNote : CrudEntity
    {
        [BindNever]
        public Guid OrderId { get; set; }

        [BindNever]
        public Guid AuthorId { get; set; }

        [BindNever]
        public DateTime AddedOn { get; set; }

        [BindRequired]
        public string Text { get; set; }
        //...
    }
}