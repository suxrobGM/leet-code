namespace LeetCode.Solutions;

public class Solution134
{
    /// <summary>
    /// 134. Gas Station
    /// <a href="https://leetcode.com/problems/gas-station">See the problem</a>
    /// </summary>
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        var totalGas = 0;
        var totalCost = 0;
        var tank = 0;
        var start = 0;
        
        for (var i = 0; i < gas.Length; i++)
        {
            totalGas += gas[i];
            totalCost += cost[i];
            tank += gas[i] - cost[i];
            
            if (tank < 0)
            {
                start = i + 1;
                tank = 0;
            }
        }
        
        return totalGas < totalCost ? -1 : start;
    }
}
