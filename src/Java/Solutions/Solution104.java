package Java.Solutions;

import Java.TreeNode;

public class Solution104 {
    /**
     * @see https://leetcode.com/problems/maximum-depth-of-binary-tree
     */
    public int maxDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }

        int leftLength = 0;
        int rightLength = 0;

        if (root.left != null) {
            leftLength = 1 + maxDepth(root.left);
        }
        else {
            leftLength++;
        }

        if (root.right != null) {
            rightLength = 1 + maxDepth(root.right);
        }
        else {
            rightLength++;
        }

        return Math.max(leftLength, rightLength);
    }
}
