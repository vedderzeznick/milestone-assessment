using System;
public class MyMainClass
{
    static void Main()
    {
        // -- exercise 1 --
        Console.WriteLine("\n\n\n----- EXERCISE 1 -----\n");
        Book daVinciCode = new Book("The Da Vinci Code", "ISBN1", "Dan Brown", 100);
        daVinciCode.DisplayInfo();
        Console.WriteLine("-------------");
        CD radioheadOKComputer = new CD("OK Computer", "ISBN2");
        radioheadOKComputer.AddTrack("Airbag", "Radiohead", 120);
        radioheadOKComputer.AddTrack("Paranoid Android", "Radiohead", 180);
        radioheadOKComputer.DisplayInfo();
        Console.WriteLine("-------------");
        DVD wizardOfOz = new DVD("The Wizard of Oz", "ISBN3");
        wizardOfOz.AddTrack("Chapter 1", "L. Frank Baum", 120);
        wizardOfOz.AddTrack("Chapter 2", "L. Frank Baum", 180);
        wizardOfOz.DisplayInfo();

        //  -- exercise 2 --
        Console.WriteLine("\n\n\n----- EXERCISE 2 -----\n");
        string input = @"Book:
Author: Brian Jensen
Title: Texts from Denmark
Publisher: Gyldendal
Published: 2001
Book:
Author: Peter Jensen
Author: Hans Andersen
Title: Stories from abroad
Publisher: Borgen
Published: 2012";

        Library2 library2 = new Library2();
        library2.books = library2.ReadBooks(input);

        Console.WriteLine("\nBooks matching *20*:");
        List<Book2> booksMatching20AndPeter = library2.FindBooks("*20*");
        foreach (var book in booksMatching20AndPeter)
        {
            Console.WriteLine($"{book.Title}, {string.Join(", ", book.Authors)}, {book.Publisher}, {book.PublicationYear}");
        }

        // -- exercise 3 --
        Console.WriteLine("\n\n\n----- EXERCISE 3 -----\n");
        // Test data
        Library3 library3 = new Library3();
        library3.AddBookToShelf("ISBN1", "Pride and Prejudice", "Jane Austen", 1, 1, 1);
        library3.AddBookToShelf("ISBN2", "The Odyssey", "Homer", 1, 1, 2);
        library3.AddBookToShelf("ISBN3", "The Brothers Karamazov", "Fyodor Dostoevsky", 1, 2, 1);
        library3.AddBookToShelf("ISBN4", "The Divine Comedy", "Dante Alighieri", 1, 2, 2);

        // Test searching book by ISBN
        string isbnToFind = "ISBN2";
        Book3 foundBook = library3.FindBookByISBN(isbnToFind);
        if (foundBook != null)
        {
            Console.WriteLine($"Book found: {foundBook.Title} by {foundBook.Author}");
        }
        else
        {
            Console.WriteLine($"Book with ISBN {isbnToFind} not found.");
        }
        Console.WriteLine($"Rooms: {library3.Rooms.Count}");
        Console.WriteLine($"Rows: {library3.Rows.Count}");
        Console.WriteLine($"Shelves: {library3.Shelves.Count}");
    }
}
