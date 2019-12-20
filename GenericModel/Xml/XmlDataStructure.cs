using GenericModel.Structures;
using System;
using System.Collections.Generic;

namespace GenericModel.Xml
{
    public class XmlRootNodeHelper
    {
        // <tagname, attrNameValue>
        private List<IXmlNode> _rootPathNodes { get; set; }

        /// <summary>
        /// Create a one-line tree
        /// </summary>
        /// <param name="rootPathNodes"></param>
        public XmlRootNodeHelper(List<IXmlNode> rootPathNodes)
        {
            if (rootPathNodes == null)
            {
                throw new Exception("RootPathNodes should not be null!");
            }

            _rootPathNodes = rootPathNodes;
        }

        public List<IXmlNode> ConcatWithRoot(List<IXmlNode> pathNodes)
        {
            List<IXmlNode> listXmlNodeInfo = new List<IXmlNode>();
            listXmlNodeInfo.AddRange(_rootPathNodes);

            if (pathNodes != null && pathNodes.Count > 0)
            {
                listXmlNodeInfo.AddRange(pathNodes);
            }

            return listXmlNodeInfo;
        }
        public List<IXmlNode> ConcatWithRoot(Dictionary<String, String> pathNodeInfo)
        {
            var pathNodes = XmlRootNodeHelper.ConvertToListIXmlNode(pathNodeInfo);

            return ConcatWithRoot(pathNodes);
        }

        /// <summary>
        /// Binding pathNodes as child to this rootPathNodes, if pathNodes is null or count &lt;= 0, it will return rootPathNodes
        /// </summary>
        /// <param name="pathNodes"></param>
        /// <returns></returns>
        public IXmlNodeWithChildren CreateTreeNodesWithRoot(List<IXmlNode> pathNodes = null)
        {
            var withRoot = ConcatWithRoot(pathNodes);

            return XmlRootNodeHelper.CreateTreeNodes(withRoot);
        }

        /// <summary>
        /// Binding pathNodes as child to this rootPathNodes, if pathNodes is null or count &lt;= 0, it will return rootPathNodes
        /// </summary>
        /// <param name="pathNodeInfo"><see cref="ConvertToListIXmlNode"/> for information about output statements.</param>
        /// <returns></returns>
        public IXmlNodeWithChildren CreateTreeNodesWithRoot(Dictionary<String, String> pathNodeInfo)
        {
            var pathNodes = XmlRootNodeHelper.ConvertToListIXmlNode(pathNodeInfo);

            return CreateTreeNodesWithRoot(pathNodes);
        }

        /// <summary>
        /// Create tree by List<IXmlNode>, this will clone all node without child in list to create new tree
        /// </summary>
        /// <param name="rootPathNodes"></param>
        /// <returns></returns>
        public static IXmlNodeWithChildren CreateTreeNodes(List<IXmlNode> rootPathNodes)
        {
            IXmlNodeWithChildren mRoot = null;

            if (rootPathNodes != null && rootPathNodes.Count > 0)
            {
                mRoot = XmlNodeWC.CloneWithoutChildren(rootPathNodes[0]);

                IXmlNodeWithChildren tmpXni = mRoot;
                for (int i = 1; i < rootPathNodes.Count; i++)
                {
                    IXmlNodeWithChildren cloneChild = XmlNodeWC.CloneWithoutChildren(rootPathNodes[i]);

                    tmpXni.Children.Add(cloneChild);
                    tmpXni = cloneChild;
                }
            }

            return mRoot;
        }

        /// <summary>
        /// Create tree by Dictionary(tagname, attrNameValue)
        /// </summary>
        /// <param name="someNodeInfo"><see cref="ConvertToListIXmlNode"/> for information about output statements.</param>
        /// <returns></returns>
        public static IXmlNodeWithChildren CreateTreeNodes(Dictionary<String, String> someNodeInfo)
        {
            var rootPathNodes = XmlRootNodeHelper.ConvertToListIXmlNode(someNodeInfo);
            return CreateTreeNodes(rootPathNodes);
        }

        /// <summary>
        /// Convert NodeInfo Dictionary(tagname, attrNameValue) to ListI XmlNode
        /// </summary>
        /// <param name="someNodeInfo">Template: (Tagname, AttrNameValue)
        ///     <para>'Tagname' can't be null, empty, or space.</para>
        ///     <para>If 'AttrNameValue' is null, empty, or space, it will not set in 'name' attribute.</para>
        /// </param>
        /// <returns></returns>
        public static List<IXmlNode> ConvertToListIXmlNode(Dictionary<String, String> someNodeInfo)
        {
            List<IXmlNode> rootPathNodes = new List<IXmlNode>();

            if (someNodeInfo != null && someNodeInfo.Count > 0)
            {
                foreach (var item in someNodeInfo)
                {
                    String tagname = item.Key;
                    String attrNameValue = item.Value;

                    if (StringHelper.IsNullOrWhiteSpace(tagname))
                    {
                        throw new Exception("SomeNodeInfo's tagname should not be null, empty, or space!");
                    }

                    Dictionary<string, string> attrs = null;
                    if (!StringHelper.IsNullOrWhiteSpace(attrNameValue))
                    {
                        attrs = new Dictionary<string, string>() { { "name", attrNameValue } };
                    }

                    rootPathNodes.Add(new XmlNodeWC(tagname, attrs));
                }
            }

            return rootPathNodes;
        }
    }

    public interface IXmlNode
    {
        String TagName { get; set; }
        String InnerText { get; set; }
        Dictionary<String, String> Attributes { get; set; }
    }

    public interface IXmlNodeWithChildren : IXmlNode
    {
        List<IXmlNodeWithChildren> Children { get; }
    }

    public class XmlNodeWC : IXmlNodeWithChildren
    {
        public String TagName { get; set; }
        public String InnerText { get; set; }
        public Dictionary<String, String> Attributes { get; set; }
        public List<IXmlNodeWithChildren> Children { get; set; }


        public XmlNodeWC(String tagName)
        {
            TagName = tagName;
            InnerText = String.Empty;
            Attributes = new Dictionary<string, string>();
            Children = new List<IXmlNodeWithChildren>();
        }
        public XmlNodeWC(String tagName, Dictionary<string, string> attributes) : this(tagName)
        {
            if (attributes == null)
            {
                attributes = new Dictionary<string, string>();
            }
            Attributes = new Dictionary<string, string>(attributes);
        }
        public XmlNodeWC(String tagName, String innerText, Dictionary<string, string> attributes) : this(tagName, attributes)
        {
            InnerText = innerText;
        }


        public IXmlNodeWithChildren Clone()
        {
            IXmlNodeWithChildren newOne = XmlNodeWC.CloneWithoutChildren(this);

            if (this.Children != null && this.Children.Count > 0)
            {
                foreach (XmlNodeWC child in this.Children)
                {
                    newOne.Children.Add(child.Clone());
                }
            }

            return newOne;
        }
        public static IXmlNodeWithChildren CloneWithoutChildren(IXmlNode xn)
        {
            IXmlNodeWithChildren newOne = new XmlNodeWC(xn.TagName, xn.InnerText, xn.Attributes);

            return newOne;
        }
    }
}