using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace GenericModel.File
{
    public class XmlFileHelper
    {
        public string FilePath => _FilePath;
        private string _FilePath { get; set; }

        public XmlFileHelper(string filePath)
        {
            _FilePath = filePath;
        }

        public string Read(string startElementName, string descendantName)
        {
            return Read(startElementName, new List<string>() { descendantName });
        }
        public string Read(string startElementName, List<string> descendantNames)
        {
            return StaticRead(_FilePath, startElementName, descendantNames);
        }
        public List<string> MultiRead(params string[] descendants)
        {
            return StaticMutilRead(_FilePath, descendants);
        }

        public int ReadInt(string startElementName, string descendantName, int defaultNum)
        {
            string valueString = Read(startElementName, descendantName);

            int result = defaultNum;

            bool parsed = int.TryParse(valueString, out result);
            if (parsed)
            {
                return result;
            }
            else
            {
                return defaultNum;
            }
        }



        public static XmlNode FindNode(XmlNode xmlNode, string findNodeName)
        {
            if (xmlNode == null)
            {
                return null;
            }

            XmlNode findNode = null;
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                XmlNode node = xmlNode.ChildNodes[i];
                if (node.Name == findNodeName)
                {
                    findNode = node;
                    break;
                }
            }

            return findNode;
        }
        public static List<XmlNode> FindNodes(XmlNode xmlNode, string findNodeName)
        {
            if (xmlNode == null)
            {
                return null;
            }

            List<XmlNode> findNodes = new List<XmlNode>();
            for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
            {
                XmlNode node = xmlNode.ChildNodes[i];
                if (node.Name == findNodeName)
                {
                    findNodes.Add(node);
                }
            }

            return findNodes;
        }
        public static XmlNode FindNodeOrCreate(XmlDocument xmlDoc, XmlNode parentNode, string findNodeName)
        {
            XmlNode findNode = FindNode(parentNode, findNodeName);

            if (findNode == null)
            {
                findNode = xmlDoc.CreateElement(findNodeName);
                parentNode.AppendChild(findNode);
            }

            return findNode;
        }

        public static void AddAttributes(XmlDocument xmlDoc, XmlNode node, string attrName, string attrValue)
        {
            XmlAttribute attribute = xmlDoc.CreateAttribute(attrName);
            attribute.Value = attrValue;
            node.Attributes.Append(attribute);
        }

        public static void CreateSample(string filePath, string rootName)
        {
            TextReader tr = new StringReader(string.Format("<{0}></{0}>", rootName));
            XDocument xmlFile = XDocument.Load(tr);

            xmlFile.Save(filePath);
        }

        public static void Rewrite(string filePath, string startElementName, List<string> descendantNames, string value)
        {
            try
            {
                if (!System.IO.File.Exists(filePath))
                {
                    CreateSample(filePath, startElementName);
                }

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                XmlNode node = FindNodeOrCreate(xmlDoc, xmlDoc, startElementName);

                foreach (string name in descendantNames)
                {
                    node = FindNodeOrCreate(xmlDoc, node, name);
                }
                node.InnerText = value;

                xmlDoc.Save(filePath);
            }
            catch
            {
                throw new Exception("Some error happend when rewrite xml value.");
            }
        }

        public static string StaticRead(string filePath, string startElementName, List<string> descendantNames)
        {
            // This text is added only once to the file.
            if (!System.IO.File.Exists(filePath) || descendantNames == null || descendantNames.Count == 0)
            {
                return null;
            }

            string rtn = null;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                XmlNode findNode = FindNode(xmlDoc, startElementName);

                foreach (string name in descendantNames)
                {
                    if (findNode == null)
                    {
                        break;
                    }
                    findNode = FindNode(findNode, name);
                }

                if (findNode != null)
                {
                    rtn = findNode.InnerText;
                }
            }
            catch { }

            return rtn;
        }
        public static List<string> StaticMutilRead(string filePath, params string[] descendants)
        {
            // This text is added only once to the file.
            if (!System.IO.File.Exists(filePath) || descendants == null || descendants.Length <= 0)
            {
                return new List<string>();
            }

            List<string> rtnList = new List<string>();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                XmlNode findNode = FindNode(xmlDoc, descendants[0]);

                for (int i = 1; i < descendants.Length; i++)
                {
                    if (findNode == null)
                    {
                        break;
                    }

                    string name = descendants[i];
                    if (i == descendants.Length - 1)
                    {
                        List<XmlNode> nodes = FindNodes(findNode, name);
                        foreach (var node in nodes)
                        {
                            rtnList.Add(node.InnerText);
                        }
                    }
                    else
                    {
                        findNode = FindNode(findNode, name);
                    }
                }
            }
            catch { }

            return rtnList;
        }
    }
}
