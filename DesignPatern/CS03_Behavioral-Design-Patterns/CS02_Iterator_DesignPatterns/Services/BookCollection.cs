using System;
using System.Collections;
using System.Collections.Generic;

namespace CS02_Iterator_DesignPatterns.Services;
public class BookCollection : IEnumerable<Book>
{
    private List<Book> _books = new List<Book>();

    // Method to add a book to the collection
    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    // Implementation of the GetEnumerator method for IEnumerable interface
    public IEnumerator<Book> GetEnumerator()
    {
        return new BookIterator(this);
    }

    // Explicit implementation of non-generic IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    // Provide access to book by index (used by the iterator)
    public Book GetBook(int index)
    {
        if (index < _books.Count)
        {
            return _books[index];
        }
        return null;
    }

    public int Count
    {
        get { return _books.Count; }
    }
}