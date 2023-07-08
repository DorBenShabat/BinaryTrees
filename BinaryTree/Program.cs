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
        if(branch == null) return true;

        if(branch.Value <= minValue || branch.Value >= maxValue) return false;

        return IsValidBSTree(branch.Left, minValue, branch.Value) && IsValidBSTree(branch.Right, branch.Value, maxValue);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter Root Number: ");
        int rootNum = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Right Branch Number: ");
        int rightBranch = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Right Branch Of Right Branch Number: ");
        int rightRightBranch = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Left Branch Of Right Branch Number: ");
        int rightLeftBranch = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Left Branch Number: ");
        int leftBranch = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Left Branch Of Left Branch Number: ");
        int leftLeftBranch = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Right Branch Of Left Branch Number: ");
        int leftRightBranch = int.Parse(Console.ReadLine());



        TreeObjects rootTrre = new TreeObjects(rootNum);
        rootTrre.Right = new TreeObjects(rightBranch);
        rootTrre.Right.Right = new TreeObjects(rightRightBranch);
        rootTrre.Right.Left = new TreeObjects(rightLeftBranch);
        rootTrre.Left = new TreeObjects(leftBranch);
        rootTrre.Left.Left = new TreeObjects(leftLeftBranch);
        rootTrre.Left.Right = new TreeObjects(leftRightBranch);
        
        Console.WriteLine(CheckValidBSTree.IsValidBSTree(rootTrre));
    }
}
