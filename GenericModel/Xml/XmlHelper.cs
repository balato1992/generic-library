using GenericModel.Structures;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace GenericModel.Xml
{
    public class XmlHelper
    {
        protected const string _NAMESPACE_URI = "http://www.w3schools.com";
        protected const string _XSI = "http://www.w3.org/2001/XMLSchema-instance";
        protected const string _PREFIX = "xsi";

        protected XmlDocument _xDoc { get; set; }
        protected XmlElement _XmlElement { get { return _xDoc.DocumentElement; } }
        protected XmlNamespaceManager _nsmgr { get; set; }

        public XmlHelper(IXmlNode rootInfo)
        {
            _xDoc = new XmlDocument();
            _xDoc.AppendChild(_xDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            _xDoc.AppendChild(_xDoc.CreateNode(XmlNodeType.Element, rootInfo.TagName, _NAMESPACE_URI));
            mXmlWriter.SetAttr(_xDoc.DocumentElement, "xmlns", _NAMESPACE_URI);
            mXmlWriter.SetAttr(_xDoc.DocumentElement, "xmlns:xsi", _XSI);

            foreach (var item in rootInfo.Attributes)
            {
                string attrName = item.Key;
                string attrValue = item.Value;

                string[] splitStrs = attrName.Split(':');
                // something like 'xsi:schemaLocation' need this method to save in file
                if (splitStrs != null && splitStrs.Length > 0 && splitStrs[0].Equals("xsi"))
                {
                    XmlAttribute schemaLoc = _xDoc.CreateAttribute(splitStrs[0], splitStrs[1], _XSI);
                    schemaLoc.Value = attrValue;
                    _xDoc.DocumentElement.Attributes.Append(schemaLoc);
                }
                else
                {
                    mXmlWriter.SetAttr(_xDoc.DocumentElement, item.Key, item.Value);
                }
            }

            _nsmgr = new XmlNamespaceManager(_xDoc.NameTable);
            _nsmgr.AddNamespace(_PREFIX, _NAMESPACE_URI);
        }

        /// <summary>
        /// Make difference with (string strInput, bool isPath = true)
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="useless"></param>
        public XmlHelper(string tagName)
        {
            _xDoc = new XmlDocument();
            _xDoc.AppendChild(_xDoc.CreateXmlDeclaration("1.0", "utf-8", null));
            _xDoc.AppendChild(_xDoc.CreateNode(XmlNodeType.Element, tagName, _NAMESPACE_URI));
            mXmlWriter.SetAttr(_xDoc.DocumentElement, "xmlns", _NAMESPACE_URI);
            mXmlWriter.SetAttr(_xDoc.DocumentElement, "xmlns:xsi", _XSI);

            _nsmgr = new XmlNamespaceManager(_xDoc.NameTable);
            _nsmgr.AddNamespace(_PREFIX, _NAMESPACE_URI);
        }

        /// <summary>
        /// 'strInput': Path or xml, 
        /// <para>When 'isPath' is 'true': strInput is path.</para>
        /// <para>When 'isPath' is 'false': strInput is xml.</para>
        /// <para>Default: path</para>
        /// </summary>
        /// <param name="strInput">Path or xml</param>
        /// <param name="isPath">true: strInput is path, false: strInput is xml. Default: path</param>
        public XmlHelper(string strInput, bool isPath)
        {
            _xDoc = new XmlDocument();

            if (isPath)
            {
                _xDoc.Load(strInput);
            }
            else
            {
                _xDoc.LoadXml(strInput);
            }
            _nsmgr = new XmlNamespaceManager(_xDoc.NameTable);
            _nsmgr.AddNamespace(_PREFIX, _NAMESPACE_URI);
        }

        public void Save(string filename)
        {
            _xDoc.Save(filename);
        }

        public override string ToString()
        {
            return (_xDoc != null ? _xDoc.OuterXml : "");
        }

        // get nodes by nodeInfos
        protected XmlNodeList _GetNodes(List<IXmlNodeWithChildren> nodeInfos)
        {
            return mXmlReader.GetNodes(_XmlElement, _nsmgr, _PREFIX, nodeInfos);
        }
        protected XmlNodeList _GetNodes(IXmlNodeWithChildren nodeInfo)
        {
            if (nodeInfo != null)
            {
                List<IXmlNodeWithChildren> nodeInfos = new List<IXmlNodeWithChildren>() { nodeInfo };

                return this._GetNodes(nodeInfos);
            }
            return null;
        }

        public XmlNodeList GetNodes(List<IXmlNode> rootPathInfos, XmlRootNodeHelper root = null)
        {
            IXmlNodeWithChildren pathNodes = null;

            if (root != null)
            {
                pathNodes = root.CreateTreeNodesWithRoot(rootPathInfos);
            }
            else
            {
                pathNodes = XmlRootNodeHelper.CreateTreeNodes(rootPathInfos);
            }

            return _GetNodes(pathNodes);
        }

        // <tagname, attrNameValue>
        public XmlNodeList GetNodes(Dictionary<string, string> rootPathInfos, XmlRootNodeHelper root = null)
        {
            IXmlNodeWithChildren pathNodes = null;

            if (root != null)
            {
                pathNodes = root.CreateTreeNodesWithRoot(rootPathInfos);
            }
            else
            {
                pathNodes = XmlRootNodeHelper.CreateTreeNodes(rootPathInfos);
            }

            return _GetNodes(pathNodes);
        }

        public void AddNode(IXmlNodeWithChildren node, XmlNode parent = null)
        {
            if (parent == null)
            {
                parent = _xDoc.DocumentElement;
            }

            XmlNode newElem = _xDoc.CreateNode(XmlNodeType.Element, node.TagName, _NAMESPACE_URI);

            foreach (var item in node.Attributes)
            {
                mXmlWriter.SetAttr(newElem, item.Key, item.Value);
            }

            if (node.InnerText != null)
            {
                mXmlWriter.SetInnertext(newElem, node.InnerText);
            }

            parent.AppendChild(newElem);

            foreach (var child in node.Children)
            {
                AddNode(child, newElem);
            }
        }
    }

    public class mXmlWriter
    {
        public static void RemoveNode(XmlNode xn)
        {
            var parentNode = xn.ParentNode;

            parentNode.RemoveChild(xn);
        }

        public static void RemoveNode(List<XmlNode> listXN)
        {
            for (int i = 0; i < listXN.Count; i++)
            {
                RemoveNode(listXN[i]);
            }
        }

        public static void SetAttr(XmlNode xn, string strAttrKey, string strAttrValue)
        {
            XmlAttribute typeAttr = xn.OwnerDocument.CreateAttribute(strAttrKey);
            typeAttr.Value = strAttrValue;

            xn.Attributes.Append(typeAttr);
        }

        public static void SetAttr(XmlNode xn, string strAttrKey, string strAttrValue, string namespaceURI, string prefix)
        {
            XmlAttribute typeAttr = xn.OwnerDocument.CreateAttribute(prefix, strAttrKey, namespaceURI);
            typeAttr.Value = strAttrValue;

            xn.Attributes.Append(typeAttr);
        }

        public static void SetInnertext(XmlNode xn, string strText)
        {
            xn.InnerText = strText;
        }
    }

    public class mXmlReader
    {
        public static string Beautify(XmlDocument doc)
        {
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };
            using (XmlWriter writer = XmlWriter.Create(sb, settings))
            {
                doc.Save(writer);
            }
            return sb.ToString();
        }

        public static XmlNode GetFirstNode(XmlNodeList xnl)
        {
            if (xnl.Count > 0)
            {
                return xnl.Item(0);
            }

            return null;
        }

        public static string GetAttr(XmlNode xn, string strValueAttrib)
        {
            XmlAttribute attribute = (xn != null && xn.Attributes != null) ? xn.Attributes[strValueAttrib] : null;

            if (attribute != null)
            {
                return attribute.Value.Trim();
            }

            throw new System.Exception("GetAttr(): strValueAttrib not found.");
        }
        public static List<string> GetAttr(XmlNodeList xnl, string strValueAttrib)
        {
            List<string> values = new List<string>();

            foreach (XmlNode xn in xnl)
            {
                string tmp = string.Empty;

                if (xn != null)
                {
                    tmp = GetAttr(xn, strValueAttrib);
                }
                values.Add(tmp);
            }

            return values;
        }

        public static Dictionary<string, string> GetAttrs(XmlNode xn)
        {
            if (xn == null || xn.Attributes == null)
            {
                return null;
            }

            Dictionary<string, string> dictAttrWithValue = new Dictionary<string, string>();

            foreach (var objAttr in xn.Attributes)
            {
                XmlAttribute attr = objAttr as XmlAttribute;
                dictAttrWithValue.Add(attr.Name.Trim(), attr.Value.Trim());
            }

            return dictAttrWithValue;
        }

        public static string GetInnertext(XmlNode xn)
        {
            return xn.InnerText.Trim();
        }
        public static List<string> GetInnertext(XmlNodeList xnl)
        {
            List<string> values = new List<string>();

            foreach (XmlNode xn in xnl)
            {
                string tmp = string.Empty;

                if (xn != null)
                {
                    tmp = GetInnertext(xn);
                }
                values.Add(tmp);
            }

            return values;
        }

        /// <summary>
        /// Get all nodes correspond with 'nsmgr', 'prefix', and'nodeInfos' in 'xn'
        /// </summary>
        /// <param name="xn"></param>
        /// <param name="nsmgr"></param>
        /// <param name="prefix"></param>
        /// <param name="nodeInfos"></param>
        /// <returns></returns>
        public static XmlNodeList GetNodes(XmlNode xn, XmlNamespaceManager nsmgr, string prefix, List<IXmlNodeWithChildren> nodeInfos)
        {
            if (nodeInfos != null && nodeInfos.Count > 0)
            {
                List<string> xpaths = new List<string>();


                foreach (IXmlNodeWithChildren xni in nodeInfos)
                {
                    List<string> nodeXpaths = _GetXpaths_AllDescendantNode(prefix, xni);

                    // add descendant to apply all nodes except itself
                    nodeXpaths.ForEach(x => xpaths.Add("descendant-or-self::" + x));
                }

                string strXpaths = string.Join("|", xpaths.ToArray());

                XmlNodeList list = xn.SelectNodes(strXpaths, nsmgr);
                return list;
            }
            return null;
        }


        private static List<string> _GetXpaths_AllDescendantNode(string prefix, IXmlNodeWithChildren xni)
        {
            string xpath = _GetXpath_SingleNode(prefix, xni);

            if (xni.Children != null && xni.Children.Count > 0)
            {
                List<string> childXpaths = new List<string>();
                foreach (var nodeInfo in xni.Children)
                {
                    childXpaths.AddRange(_GetXpaths_AllDescendantNode(prefix, nodeInfo));
                }

                childXpaths = childXpaths.Select(c => { return xpath + @"/" + c; }).ToList();

                return childXpaths;
            }
            else
            {
                return new List<string>() { xpath };
            }
        }

        // merge all attribute to xpath
        private static string _GetXpath_SingleNode(string prefix, IXmlNodeWithChildren xni)
        {
            string attributeSelector = _GetXpathAttr(xni.Attributes);

            return string.Format("{0}:{1}{2}", prefix, xni.TagName, attributeSelector);
        }

        // merge all attribute to xpath
        private static string _GetXpathAttr(Dictionary<string, string> attributes)
        {
            string attributeSelector = string.Empty;

            if (attributes != null)
            {
                foreach (var item in attributes)
                {
                    string attrName = item.Key;
                    string attrValue = item.Value;


                    if (!StringHelper.IsNullOrWhiteSpace(attrName))
                    {
                        if (attributeSelector != string.Empty)
                        {
                            attributeSelector += " and ";
                        }
                        attributeSelector += string.Format("[@{0}='{1}']", attrName, attrValue);
                    }
                }
            }

            return attributeSelector;
        }
    }
}
