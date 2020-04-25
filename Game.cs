
using System;

namespace Spaceman
{
    class Game
    {
        public string CodeWord
        { get; private set; }
        public string CurrentWord
        { get; private set; }
        public int MaxGuesses
        { get; }
        public int NumGuesses
        { get; private set; }
        private string[] cwArray = new string["aperture", "limit", "stars", "light", "rigid"];

        Ufo ufo = new Ufo();

        public Game()
        {
            Random gen = new Random();
            CodeWord = cwArray[gen.Next(0, 5)];
            MaxGuesses = 5;
            NumGuesses = 0;
            for (int i; i < CodeWord.Length; i++)
            {
                CurrentWord += "_";
            }
        }
        public void Display()
        {
            Console.WriteLine(ufo.Stringify());
            Console.WriteLine("The Current Word is: " + CurrentWord);
            Console.WriteLine($"You have {NumGuesses} attempts");
        }
        public void Ask()
        {
            Console.WriteLine("Hey human! Try to guess a letter or I'll take this other human!");
            string answer = Console.ReadLine();
            Console.WriteLine();
            if (answer.Trim().Length != 1)
            {
                Console.WriteLine("Please, one letter at a time.");
                return;
            }
            char charCode = answer.Trim().ToCharArray()[0];

            if (CodeWord.Contains(charCode))
            {
                Console.WriteLine("You've got it right!");
                for (int i = 0; i < CurrentWord.Length; i++)
                {
                    if (CodeWord[i] == charCode)
                    {
                        CurrentWord = CurrentWord.Remove(i, 1).Insert(i, charCode.ToString());
                    }
                }
            }
            else
            {
                NumGuesses++;
                ufo.AddPart();
            }
        }

        public bool DidWin()
        {
            if (CodeWord.Equals(CurrentWord))
            { return true; }
            else { return false; }
        }
        public bool DidLose()
        {
            if (NumGuesses >= MaxGuesses)
            { return true; }
            else { return false; }
        }

        public void Greet()
        {
            Console.WriteLine("Hello there Player!");
        }
    }
}