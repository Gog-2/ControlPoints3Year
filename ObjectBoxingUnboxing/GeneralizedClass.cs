namespace ObjectBoxingUnboxing;
using ObjectBoxingUnboxing.Book;

public class GeneralizedClass
{
    public static void PrintBookInfo<TId>(Book<TId> book)
    {
        Console.WriteLine(book.ToString());
    }

    public void Run()
    {
        var stringBook1 = new Book<string>("ISBN-978-01", "Остров сокровищ", "Роберт Стивенсон", 350);
        var stringBook2 = new Book<string>("ISBN-978-02", "1984", "Джордж Оруэлл", 328);
        
        var intBook1 = new Book<int>(101, "Мастер и Маргарита", "Михаил Булгаков", 480);
        var intBook2 = new Book<int>(102, "Преступление и наказание", "Федор Достоевский", 672);
        
        var guidBook1 = new Book<Guid>(Guid.NewGuid(), "Маленький принц", "Антуан де Сент-Экзюпери", 112);
        var guidBook2 = new Book<Guid>(Guid.NewGuid(), "Граф Монте-Кристо", "Александр Дюма", 1248);
        
        Console.WriteLine("\nКниги (string)");
        PrintBookInfo(stringBook1);
        PrintBookInfo(stringBook2);
        
        Console.WriteLine("\nКниги (string) после ресета");
        stringBook1.Reset();
        stringBook2.Reset();
        PrintBookInfo(stringBook1);
        PrintBookInfo(stringBook2);

        Console.WriteLine("\nКниги (int)");
        PrintBookInfo(intBook1);
        PrintBookInfo(intBook2);
        
        Console.WriteLine("\nКниги (int) после ресета");
        intBook1.Reset();
        intBook2.Reset();
        PrintBookInfo(intBook1);
        PrintBookInfo(intBook2);

        Console.WriteLine("\nКниги (Guid)");
        PrintBookInfo(guidBook1);
        PrintBookInfo(guidBook2);
        
        Console.WriteLine("\nКниги (Guid) после ресета");
        guidBook1.Reset();
        guidBook2.Reset();
        PrintBookInfo(guidBook1);
        PrintBookInfo(guidBook2);
    }
}