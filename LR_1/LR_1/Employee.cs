using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1
{
    public enum OrderStatus
    {
        New,          // Новый
        Paid,         // Оплаченный
        Canceled      // Отменённый
    }

    public enum InvoiceStatus
    {
        New,               // Новая
        Issued,            // Выписанная
        Suspended,         // Приостановленная
        Ready,             // Готовая
        Shipped            // Отгруженная
    }

    /// <summary>
    /// Сотрудник
    /// </summary>
    public class Employee
    {
        public required int Id { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public List<Order> Order { get; set; } = [];
        public List<Warehouse> Warehouse { get; set; } = [];
        public List<Invoice> Invoices{ get; set; } = [];
    }

    
    /// <summary>
    /// Склад: Номер, Адрес;
    /// </summary>
    public class Warehouse
    {
        public required int Id { get; set; }
        public required Employee Storekeeper { get; set; }
        public int? WarehouseNumber { get; set; }
        public string? Address { get; set; }

        public List<StockItem> StockItems { get; set; } = [];
    }

    /// <summary>
    /// Накладная: Статус, ДатаВремяОтгрузки, Сумма, Вес, Примечание, ФИОПолучателя
    /// </summary>
    public class Invoice: Document
    {
        public required Employee MaterialResponsiblePerson { get; set; }
        public InvoiceStatus? Status { get; set; }
        public DateTime? ShipmentDateTime { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Weight { get; set; }
        public string? RecipientFullName { get; set; }
        public string? Note { get; set; }

        public List<InvoiceRecord> InvoiceRecords { get; set; } = [];
    }

    /// <summary>
    /// Заказ: Статус, ДатаОтгрузки, ДатаОплаты, Цена
    /// </summary>
    public class Order: Document
    {
        public required Employee Manager { get; set; }
        public OrderStatus? Status { get; set; }
        public DateTime? ShippingDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Price { get; set; }

        public List<OrderLine> OrderLines { get; set; } = [];
        public List<Invoice> Invoices { get; set; } = [];

        public void Cancel() { }
    }

    /// <summary>
    /// ТоварНаСкладе: Количество
    /// </summary>
    public class StockItem
    {
        public required int Id { get; set; }
        public int? Quantity { get; set; }
    }

    /// <summary>
    /// Товар: КодТовара, Название, ЕдиницаИзмерения, Описание, Цена
    /// </summary>
    public class Product
    {
        public required int Id { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? MeasurementUnit { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }


        public List<StockItem?> StockItems { get; set; } = [];
        public List<InvoiceRecord> InvoiceRecords { get; set; } = [];
        public List<Order> Orders { get; set; } = [];
    }

    /// <summary>
    /// ЗаписьВНакладной: Количество, Вес, Цена, Сумма
    /// </summary>
    public class InvoiceRecord
    {
        public required int Id { get; set; }
        public int? Quantity { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalAmount { get; set; }
    }

    /// <summary>
    /// СтрокаЗаказа: Количество, ЦенаСНалогами, Сумма
    /// </summary>
    public class OrderLine
    {
        public required int Id { get; set; }
        public int? Quantity { get; set; }
        public decimal? PriceWithTaxes { get; set; }
        public decimal? TotalAmount { get; set; }
    }

    /// <summary>
    /// Документ: Номер, ДатаЗаполнения
    /// </summary>
    public class Document
    {
        public required string Id { get; set; }
        public int DocumentNumber { get; set; }
        public DateTime FillDate { get; set; }
    }
}
