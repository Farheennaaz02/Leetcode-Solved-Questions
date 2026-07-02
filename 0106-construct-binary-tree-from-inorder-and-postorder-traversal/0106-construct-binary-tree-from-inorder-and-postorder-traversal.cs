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
    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        Dictionary <int , int > inordermap = new ();
        int size = postorder.Length -1;
        for ( int i =0 ; i<inorder.Length ;i++){
            inordermap [inorder[i]]=i;
        }
        return Split (postorder , inordermap , size , 0,inorder.Length-1);// size is last element 
    }
    private TreeNode Split ( int [] postorder , Dictionary<int , int > inordermap , int rootindex , int left , int right ){
        if (left >right ){
            return null; }

        TreeNode root = new TreeNode (postorder[rootindex]);
        int mid = inordermap[postorder[rootindex]];

        if ( mid >left ){
            root.left =  Split ( postorder , inordermap   , rootindex-(right-mid)-1  , left , mid-1);
        }
        if ( mid <right ){
            root.right =  Split( postorder , inordermap ,rootindex-1, mid +1, right );//left and right same just in change in the rootindex 
        }
        return root; }}