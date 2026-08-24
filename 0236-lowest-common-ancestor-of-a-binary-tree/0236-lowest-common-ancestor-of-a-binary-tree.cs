/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        if ( root == null ){// ager root hi khtm oh bs kuch nhi 
            return null;
        }
        if ( root == p || root ==q){//sger p ya q se ek root h toh voh hi print kr do 
            return root ;
        }
        TreeNode left = LowestCommonAncestor ( root.left , p , q);// wwe will travel for left tree 
        TreeNode right = LowestCommonAncestor ( root.right , p , q);// we will travel for right tree
        if ( left != null && right != null){// ager left h and right bhi h toh root hamara anser hoga 
            return root ; 
        }
        if ( left== null){// ager left nhi h toh right hamara anser hoga 
            return right;
        }
        else {// ager right nhi h toh left hamara ansewer hoaga
            return left ;
        }
        
    }
}