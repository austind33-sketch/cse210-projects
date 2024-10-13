﻿using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How not to resort to kissing Tutorial", "J-learn Academy", 1200);
        Video video2 = new Video("Top 10 Mutual patterns", "Tech With Timmy", 900);
        Video video3 = new Video("Introduction to Dating", "Dating Expert Dylan", 1500);

        video1.AddComment(new Comment("Jared", "Weak tutorial, not very informative!"));
        video1.AddComment(new Comment("Dylan", "Clear and concise."));
        video1.AddComment(new Comment("Bernard", "This helped me a lot, thanks!"));

        video2.AddComment(new Comment("David", "Love the examples, will learn more!"));
        video2.AddComment(new Comment("Eve", "Nice breakdown of concepts to focus on."));
        video2.AddComment(new Comment("Matty", "Can you do more on SOLID principles?"));

        video3.AddComment(new Comment("Grace", "Stuff explained simply, yet profoundly!"));
        video3.AddComment(new Comment("Hank", "I learned somewhat."));
        video3.AddComment(new Comment("Ivy", "Looking forward to more good good."));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine(video.GetVideoInfo());
            Console.WriteLine("Number of comments: " + video.GetNumberOfComments());
            video.DisplayComments();
            Console.WriteLine("--------------------");
        }
    }
}

class Video
{
    private string title;
    private string author;
    private int length;
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public string GetVideoInfo()
    {
        return $"Title: {title}\nAuthor: {author}\nLength: {length} seconds";
    }

    public void DisplayComments()
    {
        foreach (Comment comment in comments)
        {
            Console.WriteLine(comment.GetCommentInfo());
        }
    }
}

class Comment
{
    private string commenterName;
    private string commentText;

    public Comment(string commenterName, string commentText)
    {
        this.commenterName = commenterName;
        this.commentText = commentText;
    }

    public string GetCommentInfo()
    {
        return $"Comment by {commenterName}: {commentText}";
    }
}