﻿namespace LeetCode.Solutions;

public class Solution53
{
    /// <summary>
    /// Given an integer array nums, find the contiguous subarray (containing at least one number) which has the largest sum and return its sum.
    /// A subarray is a contiguous part of an array.
    /// <a href="https://leetcode.com/problems/maximum-subarray/">See the problem</a>
    /// </summary>
    public int MaxSubArray(int[] nums)
    {
        int subArrRes = 0;
        int res = int.MinValue;

        foreach (var num in nums)
        {
            subArrRes += num;

            if (subArrRes < num)
            {
                subArrRes = num;
            }

            if (subArrRes > res)
            {
                res = subArrRes;
            }
        }

        return res;
    }
}
