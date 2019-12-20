using System.Collections.Generic;

namespace TestSamples.Rpn
{
    public class CusTreeNode
    {
        public string Key { get; set; }
        public List<CusTreeNode> Children { get; set; }
        public CusTreeNode Parent { get; set; }
        public List<CusTreeNode> Sibling { get; set; }

        public CusTreeNode(string key)
        {
            Key = key;
            Children = new List<CusTreeNode>();
            Parent = null;
            Sibling = new List<CusTreeNode>();
        }
        public CusTreeNode(string key, CusTreeNode child) : this(key)
        {
            LinkParent(this, child);
        }

        public static void LinkParent(CusTreeNode parent, CusTreeNode child)
        {
            List<CusTreeNode> allSibling = new List<CusTreeNode>(child.Sibling);
            allSibling.Add(child);

            foreach (CusTreeNode sibling in allSibling)
            {
                parent.Children.Add(sibling);
                sibling.Parent = parent;
            }
        }
        public static void LinkSibling(CusTreeNode s1, CusTreeNode s2)
        {
            s1.Sibling.Add(s2);
            s2.Sibling.Add(s1);
        }
    }
}
