using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using MyCompany.Crm.Sales.Commons;
using MyCompany.Crm.Sales.Orders;

namespace MyCompany.Crm.Sales.Database.Sql.Documents;

[UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
public class DbOrder : Order.Data
{
    // Marten doesn't support value objects as identifiers.
    OrderId Order.Data.Id => new(Id);
    public Guid Id { get; set; }
    public Money MaxTotalCost { get; set; }
    public bool IsPlaced { get; set; }
    public List<Order.Item> Items { get; set; }

    IReadOnlyCollection<Order.Item> Order.Data.Items => Items;
    public void Add(Order.Item item) => Items.Add(item);
    public void Remove(Order.Item item) => Items.Remove(item);
}