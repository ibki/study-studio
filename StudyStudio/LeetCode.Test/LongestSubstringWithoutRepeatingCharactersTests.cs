/*

https://leetcode.com/problems/longest-substring-without-repeating-characters/

3. Longest Substring Without Repeating Characters

Given a string s, find the length of the longest substring without repeating characters.

Example 1:
Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.

Example 2:
Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.

Example 3:
Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.

Example 4:
Input: s = ""
Output: 0

Constraints:
0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.

 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LeetCode.Test
{
    [TestClass]
    public class LongestSubstringWithoutRepeatingCharactersTests
    {
        [TestMethod]
        [DataRow("abcabcbb", 3)]
        [DataRow("bbbbb", 1)]
        [DataRow("pwwkew", 3)]
        [DataRow("", 0)]        
        public void LengthOfLongestSubstring(string s, int output)
        {
            var result = LengthOfLongestSubstring(s);

            Assert.AreEqual(output, result);
        }

        public int LengthOfLongestSubstring(string s)
        {
            int i = 0;
            int j = 0;
            int max = 0;
            int length = s.Length;
            HashSet<char> longestSubstring = new HashSet<char>();

            while (i < length && j < length)
            {
                if (longestSubstring.Contains(s[j]))
                {
                    longestSubstring.Remove(s[i++]);
                }
                else
                {
                    longestSubstring.Add(s[j++]);
                    if (max < longestSubstring.Count)
                    {
                        max = longestSubstring.Count;
                    }

                }
            }

            return max;
        }
    }
}
