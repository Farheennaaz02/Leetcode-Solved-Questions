public class Solution {

    public int PathSum(TreeNode root, int targetSum) {
        if (root == null) {
            return 0;
        }

        return DFS(root, targetSum)
             + PathSum(root.left, targetSum)
             + PathSum(root.right, targetSum);
    }

    int DFS(TreeNode root, long targetSum) {

        if (root == null) {
            return 0;
        }

        int count = 0;

        if (root.val == targetSum) {
            count++;
        }

        count += DFS(root.left, targetSum - root.val);
        count += DFS(root.right, targetSum - root.val);

        return count;
    }
}