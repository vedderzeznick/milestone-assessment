using System;

// Interface for items that can be borrowed
public interface IBorrowable
{
    string Title { get; }
    string ISBN { get; }
    void BorrowItem();
    void ReturnItem();
}

// Base class for all library items
public abstract class LibraryItem : IBorrowable
{
    public string Title { get; protected set; }
    public string ISBN { get; protected set; }

    public abstract void DisplayInfo();
    public abstract void Download();

    public void BorrowItem()
    {
        // Implementation for borrowing an item
    }

    public void ReturnItem()
    {
        // Implementation for returning an item
    }
}

// Book class representing books in the library
public class Book : LibraryItem
{
    public string Author { get; private set; }
    public int NumPages { get; private set; }

    public Book(string title, string isbn, string author, int numPages)
    {
        Title = title;
        ISBN = isbn;
        Author = author;
        NumPages = numPages;
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("ISBN: " + ISBN);
        Console.WriteLine("Author: " + Author);
        Console.WriteLine("Number of pages: " + NumPages);
    }

    public override void Download()
    {
        // Implementation to download eBook if possible
    }
}

// Track class representing individual tracks on CDs, DVDs, and Blu-ray discs
public class Track
{
    public string Title { get; private set; }
    public string Artist { get; private set; }
    public int Duration { get; private set; }

    public Track(string title, string artist, int duration)
    {
        Title = title;
        Artist = artist;
        Duration = duration;
    }
}

// AudioMedia class representing CDs and audio files with multiple tracks
public class MediaItem : LibraryItem
{
    public List<Track> Tracks { get; private set; }

    public MediaItem(string title, string isbn)
    {
        Title = title;
        ISBN = isbn;
        Tracks = new List<Track>();
    }

    public void AddTrack(string title, string artist, int duration)
    {
        Tracks.Add(new Track(title, artist, duration));
    }

    public override void DisplayInfo()
    {
        Console.WriteLine("Title: " + Title);
        Console.WriteLine("ISBN: " + ISBN);
        Console.WriteLine("Number of tracks: " + Tracks.Count);

        foreach (var track in Tracks)
        {
            Console.WriteLine("  " + track.Title + " by " + track.Artist + " (" + track.Duration + " seconds)");
        }
        // Implementation to display audio media information, including tracks
    }

    public override void Download()
    {
        // Implementation to download audio or video file(s) if possible
    }
}

// Classes for CD, DVD, and Blu-ray discs
public class CD : MediaItem
{
    public CD(string title, string isbn) : base(title, isbn) { }
}

public class DVD : MediaItem
{
    public DVD(string title, string isbn) : base(title, isbn) { }
}
public class BluRay : MediaItem
{
    public BluRay(string title, string isbn) : base(title, isbn) { }
}

