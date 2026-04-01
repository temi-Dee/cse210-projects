using System;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    { }

    public void Run()
    {
        DisplayStartMessage();

        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.Write("Breathe in... ");
            int breathTime = Math.Min(4, _duration - elapsed);
            ShowCountdown(breathTime);
            elapsed += breathTime;
            Console.WriteLine();

            if (elapsed >= _duration) break;

            Console.Write("Breathe out... ");
            breathTime = Math.Min(4, _duration - elapsed);
            ShowCountdown(breathTime);
            elapsed += breathTime;
            Console.WriteLine();
        }

        DisplayEndMessage();
    }
}
