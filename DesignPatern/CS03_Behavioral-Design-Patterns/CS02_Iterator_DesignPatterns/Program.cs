// See https://aka.ms/new-console-template for more information

using CS02_Iterator_DesignPatterns.Services;

namespace CS02_Iterator_DesignPatterns;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, CS02_Iterator_DesignPatterns!");
         // Create a collection of books
        BookCollection myBooks = new BookCollection();
        myBooks.AddBook(new Book("The Catcher in the Rye", "J.D. Salinger"));
        myBooks.AddBook(new Book("To Kill a Mockingbird", "Harper Lee"));
        myBooks.AddBook(new Book("1984", "George Orwell"));

        // Iterate over the book collection
        foreach (Book book in myBooks)
        {
            Console.WriteLine(book);
        }
    }
}