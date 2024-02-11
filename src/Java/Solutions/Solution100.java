package solutions;

import structures.TreeNode;

public class Solution100 {
    /**
     * @see https://leetcode.com/problems/same-tree
     */
    public boolean isSameTree(TreeNode p, TreeNode q) {
        if (p == null && q == null)
            return true;

        if (p == null || q == null || (p.val == q.val))
            return false;
            
        return isSameTree(p.left, q.left) && isSameTree(p.right, q.right);
    }
}
