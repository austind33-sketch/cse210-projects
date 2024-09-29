using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "What made you smile today?",
            "Describe a challenge you faced and how you overcame it.",
            "What are you grateful for today?",
            "Reflect on a moment when you felt truly happy. What contributed to that feeling?",
            "What is one goal you want to achieve this week? What steps will you take to accomplish it?",
            "Write about a person who has influenced your life. How have they shaped who you are today?",
            "What are your favorite childhood memories? Why do they stand out to you?",
            "Describe your ideal day from start to finish.",
            "What does self-care mean to you? List some self-care activities you enjoy.",
            "Write about a book or movie that changed your perspective on something. What did you learn?",
            "If you could travel anywhere in the world, where would you go and why?",
            "What are your core values? How do they influence your decisions?",
            "What are three qualities you admire in others? How can you incorporate them into your life?",
            "Reflect on a recent accomplishment. What did it take to achieve it?",
            "What are some of your favorite quotes or sayings? Why do they resonate with you?",
            "If you could have dinner with anyone, living or dead, who would it be and why?",
            "Write about a time you stepped out of your comfort zone. What was the experience like?",
            "What are some things you want to learn or improve about yourself?",
            "Describe a significant life event and how it shaped your perspective.",
            "What is your definition of success? How has it changed over time?",
            "List three things you can do this week to take care of your mental health."

        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
