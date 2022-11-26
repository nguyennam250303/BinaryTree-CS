public class Program
{
    class Node
    {
        public Node left, right;
        public int val;
        public Node(int val)
        {
            this.val = val;
            left = right = null;
        }
    }
    class BinaryTree
    {
        public Node root;
        public BinaryTree()
        {
            root = null;
        }

        public void insert(int val)
        {
            Node temp = root;
            Node newnode = new Node(val);
            if(temp == null)
            {
                root = newnode;
                return;
            }
            Queue<Node> mq = new Queue<Node> { };
            mq.Enqueue(temp);
            while(mq.Count() != 0)
            {
                temp = mq.Peek();
                mq.Dequeue();
                if(temp.left == null)
                {
                    temp.left = newnode;
                    break;
                }
                else
                {
                    mq.Enqueue(temp.left);
                }

                if(temp.right == null)
                {
                    temp.right = newnode;
                    break;
                }
                else
                {
                    mq.Enqueue(temp.right);
                }

            }
        }
        public void deletedeepest(Node nodedeleted)
        {
            Node cur = root;
            Queue<Node> mq = new Queue<Node> { };
            mq.Enqueue(cur);
            while(mq.Count() != 0)
            {
                cur = mq.Peek();
                mq.Dequeue();
                if (cur == nodedeleted)
                {
                    cur = null;
                }
                if (cur.left == nodedeleted)
                {
                    cur.left = null;
                    break;
                }
                else
                {
                    mq.Enqueue(cur.left);
                }
                if(cur.right == nodedeleted)
                {
                    cur.right = null;
                    break;
                }
                else
                {
                    mq.Enqueue(cur.right);
                }    
            }
        }
        public void remove(int val)
        {
            Node cur = null;
            Node nodeval = null;
            Queue<Node> mq = new Queue<Node> { };
            mq.Enqueue(root);

            while (mq.Count() != 0)
            {
                cur = mq.Peek();
                mq.Dequeue();
                if (cur.val == val)
                {
                    nodeval = cur;
                }
                if (cur.left != null)
                {
                    mq.Enqueue(cur.left);
                }
                if (cur.right != null)
                {
                    mq.Enqueue(cur.right);
                }
            }


            if (nodeval != null)
            {
                if (cur != root)
                {
                    nodeval.val = cur.val;
                    deletedeepest(cur);
                    return;
                }
                root = null;
            }
        }
        public void traverseInOrder(Node node)
        {
            if (node == null)
                return;
            traverseInOrder(node.left);
            Console.Write(node.val + " ");
            traverseInOrder(node.right);
        }
        public void traversePreOrder(Node node)
        {
            if (node == null)
                return;
            Console.Write(node.val + " ");
            traversePreOrder(node.left);
            traversePreOrder(node.right);
        }
        public void traversePostOrder(Node node)
        {
            if (node == null)
                return;
            traversePostOrder(node.left);
            traversePostOrder(node.right);
            Console.Write(node.val + " ");
        }
       


    }
    static void Main()
    {
        Console.Clear();
        BinaryTree bt = new BinaryTree();
        bt.root = new Node(1);
        bt.root.left = new Node(2);
        bt.root.right = new Node(3);
        bt.root.left.left = new Node(4);
        bt.root.left.right = new Node(5);
      
        bt.remove(12);

        bt.traverseInOrder(bt.root);
        Console.WriteLine();
        bt.traversePreOrder(bt.root);
        Console.WriteLine();
        bt.traversePostOrder(bt.root);
        Console.WriteLine();







        Console.ReadLine();
    }
}
