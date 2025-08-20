using WorkflowLib.InMemoryDb.Core.Primitives;

namespace WorkflowLib.InMemoryDb.Core.Indexes;

/// <summary>
/// The BalancedTreeIndex class, which implements a B-tree index.
/// </summary>
public class BalancedTreeIndex<TKey, TValue> where TKey : IComparable<TKey>
{
    private BalancedTreeElement<KeyValuePair<TKey, TValue>> _root;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public BalancedTreeIndex()
    {
        _root = null;
    }
    
    /// <summary>
    /// Method for adding an element to the index.
    /// </summary>
    public void AddElement(TKey key, TValue value)
    {
        if (_root == null)
        {
            _root = new BalancedTreeElement<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));
        }
        else
        {
            AddElementRecursive(_root, key, value);
        }
    }

    /// <summary>
    /// Method for removing an element from an index.
    /// </summary>
    public void RemoveElement(TKey key)
    {
        if (_root == null)
        {
            return;
        }

        RemoveElementRecursive(_root, key);
    }

    /// <summary>
    /// Method for searching an element by key in the index.
    /// </summary>
    public TValue FindElement(TKey key)
    {
        if (_root == null)
        {
            throw new InvalidOperationException("Index is empty.");
        }

        return FindElementRecursive(_root, key);
    }

    /// <summary>
    /// Implementing adding an element to an index using recursion.
    /// </summary>
    private void AddElementRecursive(BalancedTreeElement<KeyValuePair<TKey, TValue>> node, TKey key, TValue value)
    {
        if (node == null)
        {
            node = new BalancedTreeElement<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));
            return;
        }

        int compareResult = key.CompareTo(node.Data.Key);
        if (compareResult < 0)
        {
            if (node.Left == null)
            {
                node.Left = new BalancedTreeElement<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));
            }
            else
            {
                AddElementRecursive(node.Left, key, value);
            }
        }
        else if (compareResult > 0)
        {
            if (node.Right == null)
            {
                node.Right = new BalancedTreeElement<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value));
            }
            else
            {
                AddElementRecursive(node.Right, key, value);
            }
        }
        else // The key already exists, let's update the value.
        {
            node.Data = new KeyValuePair<TKey, TValue>(key, value);
        }
    }

    /// <summary>
    /// Implementation of removing an element from an index using recursion.
    /// </summary>
    private void RemoveElementRecursive(BalancedTreeElement<KeyValuePair<TKey, TValue>> node, TKey key)
    {
        // Base case: if node is null, end of branch reached.
        if (node == null)
        {
            return;
        }

        int compareResult = key.CompareTo(node.Data.Key);

        if (compareResult < 0) // If the key is less than the node key, go left.
        {
            RemoveElementRecursive(node.Left, key);
        }
        else if (compareResult > 0) // If the key is greater than the node key, go to the right.
        {
            RemoveElementRecursive(node.Right, key);
        }
        else // Found an item to delete.
        {
            if (node.Left == null) // The node does not have a left child.
            {
                if (node.Right != null)
                {
                    node.Data = node.Right.Data;
                    node.Left = node.Right.Left;
                    node.Right = node.Right.Right;
                }
                else
                {
                    node = null;
                }
            }
            else if (node.Right == null) // The node does not have a right child.
            {
                node = node.Left;
            }
            else // The node has both children.
            {
                BalancedTreeElement<KeyValuePair<TKey, TValue>> minRight = FindMin(node.Right);
                node.Data = minRight.Data;
                RemoveElementRecursive(node.Right, minRight.Data.Key);
            }
        }
    }

    /// <summary>
    /// Implementation of searching for an element by key in an index using recursion.
    /// </summary>
    private TValue FindElementRecursive(BalancedTreeElement<KeyValuePair<TKey, TValue>> node, TKey key)
    {
        if (node == null)
        {
            return default(TValue);
        }

        int compareResult = key.CompareTo(node.Data.Key);
        if (compareResult == 0)
        {
            return node.Data.Value;
        }
        else if (compareResult < 0)
        {
            return FindElementRecursive(node.Left, key);
        }
        else
        {
            return FindElementRecursive(node.Right, key);
        }
    }

    /// <summary>
    /// Find the minimum element in a tree node.
    /// </summary>
    private BalancedTreeElement<KeyValuePair<TKey, TValue>> FindMin(BalancedTreeElement<KeyValuePair<TKey, TValue>> node)
    {
        var ret = node;
        while (node.Left != null)
        {
            ret = node.Left;
        }
        return ret;
    }
}
