public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Only insert if value is not already in the tree
        if (value == Data)
        {
            // Value already exists, do not insert duplicate
            return;
        }
        else if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }

    }

    public bool Contains(int value)
    {
        // Recursively search for the value in the tree
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            if (Left is null)
                return false;
            return Left.Contains(value);
        }
        else // value > Data
        {
            if (Right is null)
                return false;
            return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // Height is 1 + max height of left or right subtree
        int leftHeight = (Left != null) ? Left.GetHeight() : 0;
        int rightHeight = (Right != null) ? Right.GetHeight() : 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}