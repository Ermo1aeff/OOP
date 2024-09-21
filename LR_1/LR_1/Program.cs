using LR_1;
using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        Employee employee = new Employee { Id = 1, FirstName = "Вася" };
        Warehouse warehouse = new Warehouse() { Id = 1, Storekeeper = employee };
        warehouse.StockItems.Add(new StockItem() { Id = 1, Quantity = 10 });



        Product product = new Product() { Id = 1 };
        product.StockItems.Add(warehouse.StockItems.FirstOrDefault(u => u.Id == 1));

        StockItem stockItem = new StockItem() { Id = 1, Quantity = 10 };

        warehouse.StockItems.Add(new StockItem() { Id = 1, Quantity = 10 });

    }
}