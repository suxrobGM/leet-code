package solutions;

class Solution70 {
    /**
     * You are climbing a staircase. It takes n steps to reach the top.
     * Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
     * @see https://leetcode.com/problems/climbing-stairs
     */
    public int climbStairs(int n) {
        int num1 = 0;
        int num2 = 1;
        int res = 0;

        for (int i = 0; i < n; i++) {
            res = num1 + num2;
            num1 = num2;
            num2 = res;
        }

        return res;
    }
}
