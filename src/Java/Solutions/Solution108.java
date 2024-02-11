package solutions;

import structures.TreeNode;

public class Solution108 {
    /**
     * @see https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree
     */
    public TreeNode sortedArrayToBST(int[] nums) {
        if (nums.length == 0) {
            return null;
        }

        return buildBST(nums, 0, nums.length - 1);
    }

    private TreeNode buildBST(int[] nums, int left, int right) {
        if (left > right) {
            return null;
        }

        var mid = left + (right - left) / 2;
        var root = new TreeNode(nums[mid]);

        root.left = buildBST(nums, left, mid - 1);
        root.right = buildBST(nums, mid + 1, right);
        return root;
    }
}
