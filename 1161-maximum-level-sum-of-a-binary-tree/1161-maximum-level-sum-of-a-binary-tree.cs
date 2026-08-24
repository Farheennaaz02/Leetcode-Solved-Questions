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
    public int MaxLevelSum(TreeNode root) {
        // print the number off  the level with the max sum 
        // bfs and level sum ceck
        // update the maxum    
        int level =1;
        int maxsum = int.MinValue;
        int ans =1;
        if ( root == null){
            return 0;
        }
        Queue<TreeNode> q = new ();
        q.Enqueue(root);
        while ( q.Count >0){
            int size = q.Count ;
             int sum =0;
            for ( int i =0;i<size ;i++){
                TreeNode node = q.Dequeue();
                sum+= node.val;
                if ( node.left!= null){
                    q.Enqueue(node.left);
                }
                if ( node.right != null){
                    q.Enqueue(node.right);
                }
            }
            if ( sum >maxsum){
                maxsum = sum ;
                ans = level;
            }
            level ++;
        }
        return   ans;
        
    }
}