using LR_1;
using System;
using System.Collections.Generic;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }

    // Связь "один ко многим" с классом Book
    public List<Book> Books { get; set; } = new List<Book>();
}

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }

    // Связь с классом Author
    public Author Author { get; set; }
}

class Program
{
    static void Main()
    {
        // Создание автора
        Author author = new Author { Id = 1, Name = "Александр Пушкин" };

        // Создание книг
        Book book1 = new Book { Id = 1, Title = "Евгений Онегин", Author = author };
        Book book2 = new Book { Id = 2, Title = "Руслан и Людмила", Author = author };

        // Добавление книг к автору
        author.Books.Add(book1);
        author.Books.Add(book2);

        // Вывод информации
        Console.WriteLine($"Автор: {author.Name}");
        foreach (var book in author.Books)
        {
            Console.WriteLine($"Книга: {book.Title}");
        }

        Storekeeper storekeeper = new() { Id = 1 };
        Manager manager = new() { Id = 1 };
        MateriallyResponsiblePerson materiallyResponsiblePerson = new() { Id = 1 };

        storekeeper.FirstName = "Василий";
        manager.FirstName = "Коля";
        manager.FirstName = "Всетлана";

    }
}