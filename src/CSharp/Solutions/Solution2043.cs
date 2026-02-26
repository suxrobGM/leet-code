namespace LeetCode.Solutions;

public class Solution2043
{
    /// <summary>
    /// 2043. Simple Bank System - Medium
    /// <a href="https://leetcode.com/problems/simple-bank-system">See the problem</a>
    /// </summary>
    public class Bank
    {
        private readonly long[] _accounts;

        public Bank(long[] balance)
        {
            _accounts = balance;
        }

        public bool Transfer(int account1, int account2, long money)
        {
            if (account1 > _accounts.Length || account2 > _accounts.Length)
                return false;

            if (_accounts[account1 - 1] < money)
                return false;

            _accounts[account1 - 1] -= money;
            _accounts[account2 - 1] += money;

            return true;
        }

        public bool Deposit(int account, long money)
        {
            if (account > _accounts.Length)
                return false;

            _accounts[account - 1] += money;
            return true;
        }

        public bool Withdraw(int account, long money)
        {
            if (account > _accounts.Length)
                return false;

            if (_accounts[account - 1] < money)
                return false;

            _accounts[account - 1] -= money;
            return true;
        }
    }
}
