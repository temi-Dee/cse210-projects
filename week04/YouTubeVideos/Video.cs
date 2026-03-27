using System;
using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _lengthSeconds;
    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
    }

    public void AddComment(Comment comment) => _comments.Add(comment);
    public int GetNumComments() => _comments.Count;

    public void DisplayInfo()
    {
        Console.WriteLine($"Title:    {_title}");
        Console.WriteLine($"Author:   {_author}");
        Console.WriteLine($"Length:   {_lengthSeconds}s");
        Console.WriteLine($"Comments: {GetNumComments()}");
        foreach (Comment c in _comments)
            Console.WriteLine($"  - {c.GetCommenterName()}: {c.GetText()}");
        Console.WriteLine();
    }
}
