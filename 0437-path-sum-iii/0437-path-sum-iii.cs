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
    public int PathSum(TreeNode root, int targetSum) {
        Dictionary <long , int > map = new ();
        map[0]= 1;
        return DFS ( root , targetSum , 0,map);
        
    }
    int DFS ( TreeNode root , int targetsum , long currentsum , Dictionary <long , int > map){
        if ( root == null){
            return 0 ;
        }
        currentsum += root.val;
        int count =0;
        if ( map.ContainsKey(currentsum-targetsum)){
            count += map[currentsum - targetsum];
        }
        if ( map.ContainsKey(currentsum)){
            map[currentsum ]++;

        }
        else {
            map[currentsum]=1;
        }
        count += DFS ( root.left , targetsum , currentsum , map);
        count += DFS ( root.right , targetsum , currentsum , map);
        map[currentsum]--;
        return count ;
    }
}