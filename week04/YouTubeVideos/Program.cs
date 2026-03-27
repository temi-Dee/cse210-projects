using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            new Video("C# for Beginners", "CodeAcademy", 620),
            new Video("OOP Explained", "TechWithTim", 480),
            new Video("Clean Code Tips", "DevMastery", 310)
        };

        videos[0].AddComment(new Comment("Alice", "Very helpful, thanks!"));
        videos[0].AddComment(new Comment("Bob", "Finally understood classes."));
        videos[0].AddComment(new Comment("Carol", "Great pacing."));

        videos[1].AddComment(new Comment("Dan", "Best OOP video out there."));
        videos[1].AddComment(new Comment("Eve", "Loved the examples."));
        videos[1].AddComment(new Comment("Frank", "Watched it twice!"));

        videos[2].AddComment(new Comment("Grace", "Changed how I write code."));
        videos[2].AddComment(new Comment("Hank", "Short and to the point."));
        videos[2].AddComment(new Comment("Ivy", "Sharing this with my team."));

        foreach (Video v in videos)
            v.DisplayInfo();
    }
}