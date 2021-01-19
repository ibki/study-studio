﻿/*

https://leetcode.com/problems/longest-palindromic-substring/

5. Longest Palindromic Substring

Given a string s, return the longest palindromic substring in s.

Example 1:
Input: s = "babad"
Output: "bab"
Note: "aba" is also a valid answer.

Example 2:
Input: s = "cbbd"
Output: "bb"

Example 3:
Input: s = "a"
Output: "a"

Example 4:
Input: s = "ac"
Output: "a"

Constraints:
1 <= s.length <= 1000
s consist of only digits and English letters (lower-case and/or upper-case),

 */

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Test
{
    [TestClass]
    public class LongestPalindromicSubstringTests
    {
        [TestMethod]
        [DataRow("babad", "bab")]
        [DataRow("cbbd", "bb")]
        [DataRow("a", "a")]
        [DataRow("ac", "a")]
        public void LongestPalindrome(string s, string output)
        {
            var result = LongestPalindrome(s);

            Assert.AreEqual(output, result);
        }

        public string LongestPalindrome(string s)
        {
            return null;
        }
    }
}
