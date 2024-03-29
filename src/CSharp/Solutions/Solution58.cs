﻿namespace LeetCode.Solutions;

public class Solution58
{
    /// <summary>
    /// Given a string s consisting of some words separated by some number of spaces, return the length of the last word in the string.
    /// A word is a maximal substring consisting of non-space characters only.
    /// <a href="https://leetcode.com/problems/length-of-last-word/">See the problem</a>
    /// </summary>
    public int LengthOfLastWord(string s)
    {
        return s.Trim().Split(" ").Last().Trim().Length;
    }
}
