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
        // TODO Start Problem 1

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
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
        // TODO Start Problem 2

        if (value > Data)
        {
            if (Right is null)
            {
                return false;
            }
            else
            {
                return Right.Contains(value);
            }
        }
        else if (value < Data)
        {
            if (Left is null)
            {
                return false;
            }
            else
            {
                return Left.Contains(value);
            }
        }
        else if (value == Data)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetHeight(bool root = true)
    {
        // TODO Start Problem 4
        if (this is not null)
        {
            int leftHight = 0;
            int rightHight = 0;
            if (Left is not null)
            {
                leftHight = 1 + Left.GetHeight(false);
            }
            if (Right is not null)
            {
                rightHight = 1 + Right.GetHeight(false);
            }
            if (leftHight > rightHight)
            {
                if (root == true)
                {
                    return leftHight + 1;
                }
                else
                {
                    return leftHight;
                }
            }
            else
            {
                if (root == true)
                {
                    return rightHight + 1;
                }
                else
                {
                    return rightHight;
                }
            }
        }
        else
        {
            return 0;
        }
    }
}