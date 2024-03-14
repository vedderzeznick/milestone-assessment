using System;

public class Book3
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int RoomNumber { get; set; }
    public int RowNumber { get; set; }
    public int ShelfNumber { get; set; }

    public Book3(string isbn, string title, string author, int roomNumber, int rowNumber, int shelfNumber)
    {
        ISBN = isbn;
        Title = title;
        Author = author;
        RoomNumber = roomNumber;
        RowNumber = rowNumber;
        ShelfNumber = shelfNumber;
    }
}

public class Bookshelf
{
    public int Number { get; set; }
    public int RoomNumber { get; set; }
    public int RowNumber { get; set; }

    public Bookshelf(int number, int roomNumber, int rowNumber)
    {
        Number = number;
        RoomNumber = rowNumber;
        RowNumber = rowNumber;
    }
}

public class Row
{
    public int Number { get; set; }
    public int RoomNumber { get; set; }

    public Row(int number, int roomNumber)
    {
        Number = number;
        RoomNumber = roomNumber;
    }
}

public class Room
{
    public int Number { get; set; }

    public Room(int number)
    {
        Number = number;
    }
}

public class Library3
{
    public List<Room> Rooms { get; set; }
    public List<Row> Rows { get; set; }
    public List<Bookshelf> Shelves { get; set; }
    public List<Book3> Books { get; set; }

    public Library3()
    {
        Rooms = new List<Room>();
        Rows = new List<Row>();
        Shelves = new List<Bookshelf>();
        Books = new List<Book3>();
    }

    public void AddBookToShelf(string isbn, string title, string author, int roomNumber, int rowNumber, int shelfNumber)
    {
        Book3 duplicateBook = FindBookByISBN(isbn);
        if (duplicateBook != null)
        {
            Console.WriteLine($"Book with ISBN {isbn} already exists in the library.");
            return;
        }

        Room room = Rooms.Find(r => r.Number == roomNumber);
        if (room == null)
        {
            room = new Room(roomNumber);
            Rooms.Add(room);
        }

        Row row = Rows.Find(r => r.Number == rowNumber && r.RoomNumber == roomNumber);
        if (row == null)
        {
            row = new Row(rowNumber, roomNumber);
            Rows.Add(row);
        }

        Bookshelf shelf = Shelves.Find(s => s.Number == shelfNumber && s.RowNumber == rowNumber && s.RoomNumber == roomNumber);
        if (shelf == null)
        {
            shelf = new Bookshelf(shelfNumber, roomNumber, rowNumber);
            Shelves.Add(shelf);
        }

        Book3 book = new Book3(isbn, title, author, roomNumber, rowNumber, shelfNumber);
        Books.Add(book);
    }

    // methods to get catalogs
    public Book3 FindBookByISBN(string isbn)
    {
        Book3 foundBook = Books.Find(b => b.ISBN == isbn);
        if (foundBook != null)
        {
            return foundBook;
        }
        return null; // Book not found
    }

    public List<Book3> FindBooksByRoom(int roomNumber)
    {
        return Books.Where(b => b.RoomNumber == roomNumber).ToList();
    }

    public List <Book3> FindBooksByRow(int rowNumber)
    {
        return Books.Where(b => b.RowNumber == rowNumber).ToList();
    }

    public List<Book3> FindBooksByShelf(int shelfNumber)
    {
        return Books.Where(b => b.ShelfNumber == shelfNumber).ToList();
    }
}
