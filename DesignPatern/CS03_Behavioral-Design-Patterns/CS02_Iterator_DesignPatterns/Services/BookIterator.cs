using System.Collections;

namespace CS02_Iterator_DesignPatterns.Services;
public class BookIterator : IEnumerator<Book>
{
    private BookCollection _collection;
    private int _currentIndex = -1;

    public BookIterator(BookCollection collection)
    {
        _collection = collection;
    }

    // Move to the next book in the collection
    public bool MoveNext()
    {
        _currentIndex++;
        return _currentIndex < _collection.Count;
    }

    // Reset the iterator to the beginning
    public void Reset()
    {
        _currentIndex = -1;
    }

    // Get the current book
    public Book Current
    {
        get
        {
            if (_currentIndex >= 0 && _currentIndex < _collection.Count)
            {
                return _collection.GetBook(_currentIndex);
            }
            return null;
        }
    }

    // Explicit implementation of IEnumerator.Current
    object IEnumerator.Current => Current;

    // Dispose method (not needed in this example, but required by IEnumerator)
    public void Dispose() { }
}
