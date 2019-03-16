using NUnit.Framework;
using Acronym;
using System.Collections.Generic;

namespace Tests
{
    public class AcronymTests
    {
        [Test]
        public void CheckAcronym_When_EmptyStringIsPassed()
        {
            Assert.AreEqual("", AcronymFactory.GetAcronym(""));
        }

        [Test]
        public void CheckAcronym_When_StringWithUpperCaseIsPassed()
        {
            Assert.AreEqual("IDK", AcronymFactory.GetAcronym("I Don't Know"));
            Assert.AreEqual("LMSA", AcronymFactory.GetAcronym("Let's Make Some Acronyms"));
        }

        [Test]
        public void CheckAcronym_When_StringWithLowerCaseIsPassed()
        {
            Assert.AreEqual("AJAX", AcronymFactory.GetAcronym("Asynchronous javascript and XML"));
            Assert.AreEqual("RAB", AcronymFactory.GetAcronym("rythm and blues"));
        }

        [Test]
        public void CheckAcronym_When_MoreEmptySpacesBetweenWords()
        {
            Assert.AreEqual("LOL", AcronymFactory.GetAcronym("laughing   out      loud"));
        }

        [Test]
        public void CheckAcronym_When_UsingSpecialConversion()
        {
            Dictionary<string, string> dict1 = new Dictionary<string, string>();
            Dictionary<string, string> dict2 = new Dictionary<string, string>();
            dict1.Add("and", "&");
            dict2.Add("and", "");
            dict2.Add("the", "");
            dict2.Add("of", "");

            Assert.AreEqual("R&B", AcronymFactory.GetAcronym("rythm and blues", dict1));
            Assert.AreEqual("RB", AcronymFactory.GetAcronym("rythm and blues", dict2));
            Assert.AreEqual("TIOE&EE", AcronymFactory.GetAcronym("The Institute of Electrical and Electronics Engineers", dict1));
            Assert.AreEqual("IEEE", AcronymFactory.GetAcronym("The Institute of Electrical and Electronics Engineers", dict2));
        }
    }
}