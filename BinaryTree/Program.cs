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

class Solutions
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

    public static bool IsSymmetric(TreeObjects root)
    {
        if (root == null)
            return true;

        return IsMirror(root.Left, root.Right);
    }

    private static bool IsMirror(TreeObjects leftNode, TreeObjects rightNode)
    {
        if (leftNode == null && rightNode == null)
            return true;

        if (leftNode == null || rightNode == null || leftNode.Value != rightNode.Value)
            return false;

        return IsMirror(leftNode.Left, rightNode.Right) && IsMirror(leftNode.Right, rightNode.Left);
    }
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
    public static int TreeDepth(TreeObjects root)
    {
        if(root == null) return 0;

        int leftDepth = TreeDepth(root.Left);
        int rightDepth = TreeDepth(root.Right);

        return Math.Max(leftDepth, rightDepth) + 1;
    }
    public static List<int> InorderTraversal(TreeObjects root)
    {
        List<int> result = new List<int>();
        if (root == null)
        {
            return result;
        }

        Stack<TreeObjects> stack = new Stack<TreeObjects>();
        TreeObjects currentNode = root;

        while (currentNode != null || stack.Count > 0)
        {
            while (currentNode != null)
            {
                stack.Push(currentNode);
                currentNode = currentNode.Left;
            }

            currentNode = stack.Pop();
            result.Add(currentNode.Value);

            currentNode = currentNode.Right;
        }

        return result;
    }
    public static int FindMaximumValue(TreeObjects root)
    {
        List<int> treeObjects = InorderTraversal(root);

        int maxValue = int.MinValue;
        foreach(var value in treeObjects) 
        {
            if(value > maxValue) maxValue = value;
        }
        return maxValue;
    }
    public static int SumTreeObjects(TreeObjects root)
    {
        List<int> treeObjects = InorderTraversal(root);
        int sum = 0;

        foreach(var obj in treeObjects)
        {
            sum += obj;
        }
        return sum;
    }
}




class Program
{
    static void Main()
    {
        // Create the tree
        TreeObjects root = new TreeObjects(1);
        root.Left = new TreeObjects(2);
        root.Right = new TreeObjects(2);
        root.Left.Left = new TreeObjects(3);
        root.Left.Right = new TreeObjects(4);
        root.Right.Left = new TreeObjects(4);
        root.Right.Right = new TreeObjects(3);
        root.Left.Left.Left = new TreeObjects(5);
        root.Left.Right.Right = new TreeObjects(6);
        root.Right.Left.Left = new TreeObjects(6);
        root.Right.Right.Right = new TreeObjects(5);



        //Answer if its BST tree 
        bool BSTanswer = Solutions.IsValidBSTree(root);
        if (BSTanswer) 
            Console.WriteLine("Valid BST Tree");
        else 
            Console.WriteLine("Invalid BST Tree");

        //Answer if its symmetric tree
        bool symetricAnswer = Solutions.IsSymmetric(root);
        if (symetricAnswer)
            Console.WriteLine("It is a symetric tree");
        else
            Console.WriteLine("It is not a symetric tree");

        //Answer the max depth of the tree
        int depthAnswer = Solutions.TreeDepth(root);
        Console.WriteLine($"The max depth of the tree is: {depthAnswer}");

        //Answer what is the LCA of node1 and node2
        TreeObjects node1 = root.Right.Left;
        TreeObjects node2 = root.Right.Right;
        TreeObjects lca = Solutions.FindLCA(root, node1, node2);
        Console.WriteLine($"LCA of {node1.Value} and {node2.Value} is: {lca.Value}"); 

        //Answer what is the max value in the tree
        int maxValueAnswer = Solutions.FindMaximumValue(root);
        Console.WriteLine("The maximum value in the tree is: " + maxValueAnswer);

        //Answer the sum of the tree objects
        int sumObjectsAnswer = Solutions.SumTreeObjects(root);
        Console.WriteLine("Sum of tree: " + sumObjectsAnswer);
        
    }

}
