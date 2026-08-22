/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool HasPathSum(TreeNode root, int targetSum) {
        return DFS ( root , 0, targetSum  );

        
    }
    bool DFS ( TreeNode root , int sumsofar , int targetsum ){
        if ( root == null){
            return false ;
        }
        sumsofar+=root.val;
        if ( root.left == null&& root.right== null){
            // leaf reaached
            if ( sumsofar == targetsum ){
                return true ;
            }


        }
            return DFS ( root.left , sumsofar , targetsum )|| DFS (root.right ,sumsofar ,targetsum);

    }
}
