# Binary Tree Project

This project demonstrates various operations on a binary tree using the `TreeObjects` class and the `Solutions` class.

## Project Overview

The project includes the following functionalities:

- Checking if a given binary tree is a valid binary search tree (BST) using the `IsValidBSTree` method.
- Checking if a given binary tree is symmetric using the `IsSymmetric` method.
- Finding the lowest common ancestor (LCA) of two nodes in a binary tree using the `FindLCA` method.
- Calculating the maximum depth of a binary tree using the `TreeDepth` method.
- Performing an inorder traversal of a binary tree and returning the values in a list using the `InorderTraversal` method.
- Finding the maximum value in a binary tree using the `FindMaximumValue` method.
- Calculating the sum of all tree objects in a binary tree using the `SumTreeObjects` method.

## Usage

To use the functionalities provided by the project, you can follow these steps:

1. Create an instance of the `TreeObjects` class to define the binary tree structure.
2. Set the left and right child nodes for each tree object to build the binary tree.
3. Use the various methods from the `Solutions` class to perform the desired operations on the binary tree.

```csharp
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

// Check if the tree is a valid BST
bool isBST = Solutions.IsValidBSTree(root);
if (isBST)
    Console.WriteLine("The tree is a valid BST.");
else
    Console.WriteLine("The tree is not a valid BST.");

// Check if the tree is symmetric
bool isSymmetric = Solutions.IsSymmetric(root);
if (isSymmetric)
    Console.WriteLine("The tree is symmetric.");
else
    Console.WriteLine("The tree is not symmetric.");

// Find the lowest common ancestor of two nodes
TreeObjects node1 = root.Right.Left;
TreeObjects node2 = root.Right.Right;
TreeObjects lca = Solutions.FindLCA(root, node1, node2);
Console.WriteLine($"The lowest common ancestor of {node1.Value} and {node2.Value} is: {lca.Value}");

// Calculate the maximum depth of the tree
int maxDepth = Solutions.TreeDepth(root);
Console.WriteLine($"The maximum depth of the tree is: {maxDepth}");

// Perform an inorder traversal of the tree
List<int> inorderTraversal = Solutions.InorderTraversal(root);
Console.WriteLine("Inorder Traversal: " + string.Join(", ", inorderTraversal));

// Find the maximum value in the tree
int maxValue = Solutions.FindMaximumValue(root);
Console.WriteLine("The maximum value in the tree is: " + maxValue);

// Calculate the sum of all tree objects
int sum = Solutions.SumTreeObjects(root);
Console.WriteLine("The sum of all tree objects is: " + sum);
