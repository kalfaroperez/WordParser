using System;
using System.Collections.Generic;
using System.Linq;

/*
Write a program that parses a sentence and replaces each word with the following: 
1) The first letter of the word
2) The number of distinct characters between first and last character
3) The last letter of the word. 
For example, Smooth would become S3h. 
Words are separated by spaces or non-alphabetic characters and these separators should be maintained in their original form and location in the answer. 
A few of the things we will be looking at is accuracy, efficiency, solution completeness. 
*/

namespace TestIntertec
{
    public class Sentences
    {
        public Sentences() { }
        public Sentences(string sentence, string expectedSentence)
        {
            Sentence = sentence;
            ExpectedSentence = expectedSentence;
        }
        public Sentences(string sentence)
        {
            Sentence = sentence;
        }

        public string Sentence { get; set; }
        public string ExpectedSentence { get; set; }
        public string ResultParsed { get; set; }

        private string CountWords(string wordInput)
        {
            if (string.IsNullOrEmpty(wordInput)) return string.Empty;

            if (wordInput.Length == 1) return wordInput;

            var firstChar = wordInput.First();
            var lastChar = wordInput.Last();

            var charactersIntoWord = wordInput.Substring(1, wordInput.Length - 2);
            var count = charactersIntoWord.Distinct().Count();

            return string.Format("{0}{1}{2}", firstChar, count, lastChar);
        }

        public string WordParser()
        {
            var wordFlag = string.Empty;
            var wordResult = string.Empty;

            for (int i = 0; i < Sentence.Length; i++)
            {
                var character = Sentence[i];
                var isChar = char.IsLetter(character);
                var isEndOfTheWord = (Sentence.Length - 1) == i;

                if (isChar)
                {
                    wordFlag += character;
                }

                if (!isChar || isEndOfTheWord)
                {
                    wordResult += CountWords(wordFlag);

                    wordResult += (!isChar) ? Convert.ToString(character) : string.Empty;

                    wordFlag = string.Empty;
                }
            }
            return wordResult;
        }

        public string WordParser(string expression)
        {
            var wordFlag = string.Empty;
            var wordResult = string.Empty;

            for (int i = 0; i < expression.Length; i++)
            {
                var character = expression[i];
                var isChar = char.IsLetter(character);
                var isEndOfTheWord = (expression.Length - 1) == i;

                if (isChar)
                {
                    wordFlag += character;
                }

                if (!isChar || isEndOfTheWord)
                {
                    wordResult += CountWords(wordFlag);

                    wordResult += (!isChar) ? Convert.ToString(character) : string.Empty;

                    wordFlag = string.Empty;
                }
            }
            return wordResult;
        }
    }

    public class Test
    {
        static void Main(string[] args)
        {
            Sentences sentence = new Sentences();
            if (args.Length == 0)
            {
                Console.WriteLine("Please write a sentence: ");
                var input = Console.ReadLine();
                var parsed = sentence.WordParser(input);
                Console.WriteLine("Output parsed expression: {0}", parsed);
            }

            if (args.Length > 0)
            {
                var input = args[0];
                var parsed = sentence.WordParser(input);
                Console.WriteLine("Output parsed expression: {0}", parsed);
            }

            Console.ReadKey();
        }
    }

}

