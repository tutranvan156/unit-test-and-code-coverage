
/// <summary>
/// Provide method to check phoneitc of trade mark.
/// </summary>

using System.Collections.Generic;

namespace PIMTool.Service {
    public class PhoneticService {
        /// <summary>
        /// Trades the mark sound like.
        /// </summary>
        /// <param name="protectedTrademark">The protected trademark.</param>
        /// <param name="otherTrademark">The other trademark.</param>
        /// <returns></returns>
        public bool TradeMarkSoundLike(string protectedTrademark, string otherTrademark) {
            // First split each word into syllables 
            List<string> syllables1 = this.SplitWordIntoSyllables(protectedTrademark);
            List<string> syllables2 = this.SplitWordIntoSyllables(protectedTrademark);
		
            // Compare if they have same number of syllables or not.
            if (syllables1.Count != syllables2.Count) {
                return false;
            }
		
            // Compare if all the syllables of the same order sound like each other.
            int size = syllables1.Count;
            for (int i = 0; i < size; i++) {
                if (!this.SyllableSoundLike(syllables1[i], syllables2[i])) {
                    return false;
                }
            }
		
            return true;
        }

        /// <summary>
        /// Splits the word into syllables.
        /// </summary>
        /// <param name="word">The word.</param>
        /// <returns></returns>
        public List<string> SplitWordIntoSyllables(string word) {
            // not implemented yet
            return new List<string>();
        }

        /// <summary>
        /// Syllables the sound like.
        /// </summary>
        /// <param name="syllable1">The syllable1.</param>
        /// <param name="syllable2">The syllable2.</param>
        /// <returns></returns>
        public bool SyllableSoundLike(string syllable1, string syllable2) {
            // not implemented yet.W
            return false;
        }
    }
}
