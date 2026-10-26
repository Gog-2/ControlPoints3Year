namespace ObjectBoxingUnboxing.Book;

public class Book<TId>
{
    public TId Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public int PagesCount { get; set; }

    public Book(TId id, string name, string author, int pagesCount)
    {
        Id = id;
        Name = name;
        Author = author;
        PagesCount = pagesCount;
    }
    
    public void Reset()
    {
        Id = default;
        Name = default;
        Author = default;
        PagesCount = default;
    }
    
    public override string ToString()
    {
            return $"{Id} {Name}, {Author}, {PagesCount} страниц";
    }
}
