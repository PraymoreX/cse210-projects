using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to Code in C#", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very helpful."));
        video1.AddComment(new Comment("Charlie", "Thanks for sharing!"));

        Video video2 = new Video("Learn OOP Fast", "Jane Smith", 800);
        video2.AddComment(new Comment("Dave", "Awesome explanation."));
        video2.AddComment(new Comment("Eve", "Loved it!"));
        video2.AddComment(new Comment("Frank", "Clear and simple."));

        Video video3 = new Video("C# Classes Tutorial", "Mike Brown", 700);
        video3.AddComment(new Comment("Grace", "Now I understand."));
        video3.AddComment(new Comment("Henry", "Good job."));
        video3.AddComment(new Comment("Ivy", "Very informative."));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"  {comment._name}: {comment._text}");
            }

            Console.WriteLine();  
        }
    }
}