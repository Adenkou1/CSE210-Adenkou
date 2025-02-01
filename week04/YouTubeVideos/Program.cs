using System;
using System.Collections.Generic;


class Comment
{
    public string CommenterName { get; set; }
    public string Text { get; set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}


class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Length { get; set; } // in seconds
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return comments.Count;
    }

    public void DisplayVideoInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {Author}");
        Console.WriteLine($"Length: {Length} seconds");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
        Console.WriteLine();
    }
}


class Program
{
    static void Main()
    {
        List<Video> videos = new List<Video>();

        
        Video video1 = new Video("Introduction to C#", "TechGuru", 600);
        Video video2 = new Video("Object-Oriented Programming", "CodeMaster", 900);
        Video video3 = new Video("Design Patterns Explained", "DevSimplified", 1200);

        
        video1.AddComment(new Comment("Alice", "Great introduction!"));
        video1.AddComment(new Comment("Bob", "This was very helpful, thanks!"));
        video1.AddComment(new Comment("Charlie", "Looking forward to more content!"));

        video2.AddComment(new Comment("David", "Very clear explanations!"));
        video2.AddComment(new Comment("Emma", "Love this series!"));
        video2.AddComment(new Comment("Frank", "Well structured and easy to follow."));

        video3.AddComment(new Comment("Grace", "Design patterns finally make sense!"));
        video3.AddComment(new Comment("Henry", "This should be mandatory learning for devs!"));
        video3.AddComment(new Comment("Isabella", "Excellent walkthrough!"));

        
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
        }
    }
}
