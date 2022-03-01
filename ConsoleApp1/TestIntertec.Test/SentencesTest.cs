using NUnit.Framework;

namespace TestIntertec.Test
{
    public class SentencesTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void WordParser_SentecesWithWordsWithOnlyTwoLetter_ReturnFirstLetterZeroNumberLastLetter()
        {
            //Arrange
            Sentences sentences = new Sentences("It or Be?");

            //Act
            var result = sentences.WordParser();

            //Assert
            Assert.AreEqual("I0t o0r B0e?", result);
        }


        [Test]
        public void WordParser_SentecesWithWordsWithMoreOfTwoLetter_ReturnFirstLetterDistinctNumberCharactersAndLastLetter()
        {
            //Arrange
            Sentences sentence1 = new Sentences("It was many and many a year ago");
            Sentences sentence2 = new Sentences("Copyright,Microsoft:Corporation");
            
            //Act
            var result1 = sentence1.WordParser();
            var result2 = sentence2.WordParser();

            //Assert
            Assert.AreEqual("I0t w1s m2y a1d m2y a y2r a1o", result1);
            Assert.AreEqual("C7t,M6t:C6n", result2);
        }
    }
}