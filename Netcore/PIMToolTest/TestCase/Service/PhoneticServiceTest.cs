using System.Collections.Generic;

using NUnit.Framework;

using System;

namespace NUnitTest.TestCase.Service {
    using PIMTool.Service;

    [TestFixture, Category("Util")]
    public class PhoneticServiceTest {
        private PhoneticService m_service = null;
	
        [SetUp]
        public void Init() {
            this.m_service = new PhoneticService();
        }
	
        [Test, TestCaseSource("GetSplitWordValidTestData")]
        public void TestSplitWordIntoSyllables(string word, List<string> syllables){
            Assert.AreEqual(syllables, this.m_service.SplitWordIntoSyllables(word));
        }
	
        //[Test, TestCaseSource("GetSplitWordInvalidTestData"), ExpectedException(typeof(Exception))]
        public void TestSplitWordIntoSyllablesException(string word) {
            this.m_service.SplitWordIntoSyllables(word);
        }
	

        [Test, Category("Fast"), TestCaseSource("GetSoundLikeTestData")]
        public void SyllableSoundLikeTest(string syllable1, string syllable2, bool likeOrNot) {
            Assert.AreEqual(likeOrNot, this.m_service.SyllableSoundLike(syllable1, syllable2));
        }

        [Test, Category("Medium"), TestCaseSource("GetTradeMarkSoundLikeTestData")]
        public void TradeMarkSoundLikeTest(string word1, string word2, bool likeOrNot) {
            Assert.AreEqual(likeOrNot, this.m_service.TradeMarkSoundLike(word1, word2));
        }

        protected Object[] GetSplitWordValidTestData() {
            return new Object[] {
                new object[] {"CANDIDATE", new List<string>{"CAN", "DI", "DATE"}},	
                new object[] {"TABLE", new List<string>{"TA", "BLE"}},
                new object[] {"WASABI", new List<string>{"WA", "SA", "BI"}},
            };
        }
	

        protected Object[] GetSplitWordInvalidTestData() {
            return new Object[] {
                new object[] {null},	
                new object[] {""}, 
                new object[] {"#$!@#%"}, 
                new object[] {" some spaces "}, 
                new object[] {"  234 234 "},
            };
        }
	
        protected Object[] GetSoundLikeTestData() {
            return new Object[] {
                new object[] {"DAN", "DEM", true},
                new object[] {"DAN", "DEN", true},
                new object[] {"RA", "LA", true},
                new object[] {"TIAL", "CIAL", true},
                new object[] {"TIAL", "SIAL", true},
                new object[] {"DAN", "ZON", false},
                new object[] {"DAN", "TEN", false},
                new object[] {"RA", "FAN", false},
				
            };
        }
	
        protected Object[] GetTradeMarkSoundLikeTestData() {
            return new Object[] {
                new object[] {"PRUDENTIAL", "RODANSIAL", true}, 
                new object[] {"TEMPLE", "TINBL", true},
                new object[] {"ALPELIBE", "ANBENYBE", true}, 
                new object[] {"PRUDENTIAL", "RODANSIALY", false},
                new object[] {"PRUDENTIAL", "PROPINTO", false}, 
                new object[] {"TEMPLE", "DENTAL", true},
                new object[] {"ALPELIBE", "ONTENABE", true}
            };
        }
    }
}
