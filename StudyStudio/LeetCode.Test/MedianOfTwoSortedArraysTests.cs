/*

https://leetcode.com/problems/median-of-two-sorted-arrays/

4. Median of Two Sorted Arrays

Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
Follow up: The overall run time complexity should be O(log (m+n)).

Example 1:
Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.

Example 2:
Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

Example 3:
Input: nums1 = [0,0], nums2 = [0,0]
Output: 0.00000

Example 4:
Input: nums1 = [], nums2 = [1]
Output: 1.00000

Example 5:
Input: nums1 = [2], nums2 = []
Output: 2.00000

Constraints:
nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-106 <= nums1[i], nums2[i] <= 106

 */

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Test
{
    [TestClass]
    public class MedianOfTwoSortedArraysTests
    {
        [TestMethod]
        [DataRow(new int[] { 1, 3 }, new int[] { 2 }, 2d)]
        [DataRow(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5d)]
        [DataRow(new int[] { 0, 0 }, new int[] { 0, 0 }, 0d)]
        [DataRow(new int[] { }, new int[] { 1 }, 1d)]
        [DataRow(new int[] { 2 }, new int[] { }, 2d)]
        public void FindMedianSortedArrays(int[] nums1, int[] nums2, double output)
        {
            var result = FindMedianSortedArrays(nums1, nums2);

            Assert.AreEqual(output, result);
        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int[] arrays = new int[nums1.Length + nums2.Length];
            int i = 0;
            int j = 0;
            int k = 0;

            while (i < nums1.Length || j < nums2.Length)
            {
                if (i < nums1.Length && j < nums2.Length)
                {
                    arrays[k++] = nums1[i] < nums2[j] ? nums1[i++] : nums2[j++];
                }
                else if (i < nums1.Length)
                {
                    arrays[k++] = nums1[i++];
                }
                else if (j < nums2.Length)
                {
                    arrays[k++] = nums2[j++];
                }
            }

            if (arrays.Length == 1)
                return arrays[0];
            else if (arrays.Length % 2 == 0)
                return (arrays[(arrays.Length / 2) - 1] + arrays[(arrays.Length / 2)]) / 2d;
            else
                return arrays[arrays.Length / 2];
        }
    }
}
