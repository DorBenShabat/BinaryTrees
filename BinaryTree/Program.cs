using System;

class TreeObjects
{
    public int Value { get; set; }
    public TreeObjects Left { get; set; }
    public TreeObjects Right { get; set; }

    public TreeObjects(int value)
    {
        this.Value = value;
    }
}

class CheckValidBSTree
{
    public static bool IsValidBSTree(TreeObjects tree)
    {
        return IsValidBSTree(tree, long.MinValue, long.MaxValue);
    }
    private static bool IsValidBSTree(TreeObjects branch, long minValue, long maxValue)
    {
        if (branch == null) return true;

        if (branch.Value <= minValue || branch.Value >= maxValue) return false;

        return IsValidBSTree(branch.Left, minValue, branch.Value) && IsValidBSTree(branch.Right, branch.Value, maxValue);
    }
}

class LowestCommonAncestor
{
    public static TreeObjects FindLCA(TreeObjects root, TreeObjects node1, TreeObjects node2)
    {
        if (root == null || node1 == null || node2 == null)
            return null;

        if (root == node1 || root == node2)
            return root;

        TreeObjects leftLCA = FindLCA(root.Left, node1, node2);
        TreeObjects rightLCA = FindLCA(root.Right, node1, node2);

        if (leftLCA != null && rightLCA != null)
            return root;
        else if (leftLCA != null)
            return leftLCA;
        else
            return rightLCA;
    }

}

class Program
{
    static void Main()
    {
        // Create the tree
        TreeObjects root = new TreeObjects(8);
        root.Left = new TreeObjects(6);
        root.Right = new TreeObjects(14);
        root.Left.Left = new TreeObjects(3);
        root.Left.Right = new TreeObjects(7);
        root.Right.Left = new TreeObjects(10);
        root.Right.Right = new TreeObjects(16);
        root.Left.Left.Left = new TreeObjects(2);
        root.Left.Left.Right = new TreeObjects(5);
        root.Right.Left.Left = new TreeObjects(9);
        root.Right.Left.Right = new TreeObjects(11);

        TreeObjects node1 = root.Right.Left.Left; 
        TreeObjects node2 = root.Left.Left.Left; 
        TreeObjects lca = LowestCommonAncestor.FindLCA(root, node1, node2);
        bool BSTanswer = CheckValidBSTree.IsValidBSTree(root);


        if (BSTanswer) 
            Console.WriteLine("Valid BST Tree");
        else 
            Console.WriteLine("Invalid BST Tree");

        Console.WriteLine($"LCA of {node1.Value} and {node2.Value} is: {lca.Value}"); 
    }

}
