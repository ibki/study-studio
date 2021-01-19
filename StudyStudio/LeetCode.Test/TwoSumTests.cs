/*

https://leetcode.com/problems/two-sum/

1. Two Sum

Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.

Example 1:
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Output: Because nums[0] + nums[1] == 9, we return [0, 1].

Example 2:
Input: nums = [3,2,4], target = 6
Output: [1,2]

Example 3:
Input: nums = [3,3], target = 6
Output: [0,1]
 
Constraints:
2 <= nums.length <= 103
-109 <= nums[i] <= 109
-109 <= target <= 109
Only one valid answer exists.

 */

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeetCode.Test
{
    [TestClass]
    public class TwoSumTests
    {
        [TestMethod]
        [DataRow(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [DataRow(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
        [DataRow(new int[] { 3, 3 }, 6, new int[] { 0, 1 })]
        [DataRow(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        public void TwoSum(int[] nums, int target, int[] output)
        {
            var result = TwoSum(nums, target);

            CollectionAssert.AreEqual(output, result);
        }

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j) continue;

                    if (nums[i] + nums[j] == target)
                    {
                        return new int[2] { i, j };
                    }
                }
            }
            return null;
        }
    }
}
