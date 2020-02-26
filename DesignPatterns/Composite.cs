namespace DesignPatterns
{
    /// <summary>
    /// An example of composite that might be used in a binary tree
    /// In this case, the tree node is composed of tree nodes
    /// Any modification method of a node, would be the same as modifying the node itself
    /// </summary>
    public class TreeNode 
    {
        private int _Value;
        public int Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        private TreeNode _Parent;
        public TreeNode Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }
    
        private TreeNode _LeftNode;
        public TreeNode LeftNode
        {
            get { return _LeftNode; }
            set { _LeftNode = value; }
        }
    
        private TreeNode _RightNode;
        public TreeNode RightNode
        {
            get { return _RightNode; }
            set { _RightNode = value; }
        }

        public void Add(TreeNode node)
        {
            //stub for method to add node correctly
            //would also manage and rearrange its own nodes
        }

        public void Remove(TreeNode node)
        {
            //stub for removing node
            //also responsible for managing and rearranging nodes when removing
        }
    
        public TreeNode(int value)
        {
            _Value = value;
        }
    }
}
