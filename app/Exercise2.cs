using System.Collections.Generic;
using System.Data;
using System.Linq;

public class Book2
{
    public List<string> Authors { get; set; }
    public string Title { get; set; }
    public string Publisher { get; set; }
    public int PublicationYear { get; set; }
}

public class Library2
{
    public List<Book2> books = new List<Book2>();

    public List<Book2> ReadBooks(string input)
    {
        List<Book2> result = new List<Book2>();
        string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        Book2 currentBook = null;

        foreach (string line in lines)
        {
            if (line.StartsWith("Book:"))
            {
                if (currentBook != null)
                {
                    result.Add(currentBook);
                }
                currentBook = new Book2 { Authors = new List<string>() };
            }
            else if (line.StartsWith("Author:"))
            {
                currentBook.Authors.Add(line.Substring("Author:".Length).Trim());
            }
            else if (line.StartsWith("Title:"))
            {
                currentBook.Title = line.Substring("Title:".Length).Trim();
            }
            else if (line.StartsWith("Publisher:"))
            {
                currentBook.Publisher = line.Substring("Publisher:".Length).Trim();
            }
            else if (line.StartsWith("Published:"))
            {
                currentBook.PublicationYear = int.Parse(line.Substring("Published:".Length).Trim());
            }
        }

        if (currentBook != null)
        {
            result.Add(currentBook);
        }

        return result;
    }

    public List<Book2> FindBooks(string searchString)
    {
        List<Book2> foundBooks = new List<Book2>();

        if (books != null && books.Count != 0)
        {
            string[] searchTerms = searchString.Split(new[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var term in searchTerms)
            {
                string insideAsterisks = ExtractStringInAsterisks(term);

                if (!string.IsNullOrEmpty(insideAsterisks))
                {
                    foundBooks.AddRange(books.Where(book =>
                        book.Authors.Any(author => author.ToLower().Contains(insideAsterisks.Trim())) ||
                        book.Title.ToLower().Contains(insideAsterisks.Trim()) ||
                        book.Publisher.ToLower().Contains(insideAsterisks.Trim()) ||
                        book.PublicationYear.ToString().Contains(insideAsterisks.Trim())));
                }
                else
                {
                    foundBooks.AddRange(books.Where(book =>
                        book.Authors.Any(author => author.ToLower() == term.Trim()) ||
                        book.Title.ToLower() == term.Trim() ||
                        book.Publisher.ToLower() == term.Trim() ||
                        book.PublicationYear.ToString() == term.Trim()));
                }
            }
        }


        return foundBooks.Distinct().ToList();
    }

    private static string ExtractStringInAsterisks(string input)
    {
        int startIndex = input.IndexOf("*");
        int endIndex = input.LastIndexOf("*");

        if (startIndex != -1 && endIndex != -1 && startIndex != endIndex)
        {
            return input.Substring(startIndex + 1, endIndex - startIndex - 1);
        }

        return "";
    }
}

