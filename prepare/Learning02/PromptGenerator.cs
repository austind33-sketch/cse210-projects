using System;
using System.Collections.Generic;

public class PromptGenerator
{
    // List of prompts to generate randomly
    private List<string> _prompts = new List<string>
    {
        "What made you smile today?",
        "Describe a challenge you faced recently.",
        "What are you grateful for today?",
        "What did you learn today?",
        "Describe your favorite moment of the day.",
        "What is something you accomplished today?",
        "What are your goals for tomorrow?"
    };

    // Method to get a random prompt from the list
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count); // Generate random index
        return _prompts[index];
    }
}
