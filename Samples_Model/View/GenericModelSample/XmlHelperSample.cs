using GenericModel.Xml;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyModelSample.View
{
    public partial class XmlHelperSample : Form
    {
        public XmlHelperSample()
        {
            InitializeComponent();

            TestCode3();
            TestCode4();
            TestCode5();
        }

        private void TestCode3()
        {
            XmlHelper mxr3 = new XmlHelper(@"testdata/Step 1.1. Combination.xml", true);
            XmlRootNodeHelper rnh3 = new XmlRootNodeHelper(new List<IXmlNode>() { new XmlNodeWC("message") });

            List<IXmlNode> listNodes4 = new List<IXmlNode>();
            listNodes4.Add(new XmlNodeWC("parameters", new Dictionary<string, string>() { { "name", "ElementType" } }));
            listNodes4.Add(new XmlNodeWC("parameter", new Dictionary<string, string>() { { "name", "ElementTypeSummary" } }));
            listNodes4.Add(new XmlNodeWC("value"));

            var etsValue = mxr3.GetNodes(listNodes4, rnh3);
            var etsAttr = mXmlReader.GetAttr(etsValue, "ordernumber");
            var etsText = mXmlReader.GetInnertext(etsValue);
        }

        private void TestCode4()
        {
            XmlHelper mxr3 = new XmlHelper(@"testdata/Step 1.1. Combination.xml", true);
            XmlRootNodeHelper rnh3 = new XmlRootNodeHelper(new List<IXmlNode>() { new XmlNodeWC("message") });

            List<IXmlNode> commandNodeInfo = new List<IXmlNode>();
            commandNodeInfo.Add(new XmlNodeWC("command"));

            Dictionary<String, String> pathInfos = new Dictionary<String, String>();
            pathInfos.Add("parameters", "ElementType");
            pathInfos.Add("parameter", "ElementTypeSummary");
            pathInfos.Add("value", null);

            var cmd = mxr3.GetNodes(commandNodeInfo, rnh3);
            var cmdName = mXmlReader.GetAttr(mXmlReader.GetFirstNode(cmd), "name");
            var listCmdName = mXmlReader.GetAttr(cmd, "name");

            var etsValue2 = mxr3.GetNodes(pathInfos, rnh3);
            var etsAttr2 = mXmlReader.GetAttr(etsValue2, "ordernumber");
            var etsText2 = mXmlReader.GetInnertext(etsValue2);
            var etsValue2FirstNode = mXmlReader.GetFirstNode(etsValue2);

            mXmlWriter.SetAttr(etsValue2FirstNode, "testT1", "testV1");
            mXmlWriter.SetAttr(etsValue2FirstNode, "testT1", "testV11");
            mXmlWriter.SetAttr(etsValue2FirstNode, "testT2", "testV2");
            mXmlWriter.SetInnertext(etsValue2FirstNode, "testT1");
            mXmlWriter.SetInnertext(etsValue2FirstNode, "testT1");
            mXmlWriter.SetInnertext(etsValue2FirstNode, "testT2");

            var etsAttr22 = mXmlReader.GetAttr(etsValue2, "ordernumber");
            var etsAttr22test = mXmlReader.GetAttr(etsValue2, "testT1");
            var etsText22 = mXmlReader.GetInnertext(etsValue2);

            mXmlWriter.RemoveNode(etsValue2FirstNode);

            mxr3.Save("TestCode4.xml");
        }

        private void TestCode5()
        {
            XmlNodeWC nodes2 = new XmlNodeWC("testTag2");
            nodes2.Children.Add(new XmlNodeWC("testTag2_2"));
            nodes2.Children.Add(new XmlNodeWC("testTag2_3"));
            nodes2.InnerText = "text2";
            XmlNodeWC nodes3 = new XmlNodeWC("testTag3");
            nodes3.InnerText = "text3";
            XmlNodeWC nodes4 = new XmlNodeWC("testTag4");
            nodes4.InnerText = "text4";

            XmlNodeWC nodes = new XmlNodeWC("testTag1");
            nodes.InnerText = "text";
            nodes.Children.Add(new XmlNodeWC("testTag1_2"));
            nodes.Children.Add(new XmlNodeWC("testTag1_3"));
            nodes.Children.Add(new XmlNodeWC("testTag1_4"));
            nodes.Children.Add(nodes2);
            nodes.Children.Add(nodes3);
            nodes.Children.Add(nodes4);

            IXmlNode rootInfo = new XmlNodeWC("message");
            rootInfo.Attributes.Add("xsi:schemaLocation", @"..\XSD_Format\BuildKSVSModel.xsd");
            rootInfo.Attributes.Add("name", @"BuildKSVSModel");
            rootInfo.Attributes.Add("id", @"1");
            rootInfo.Attributes.Add("src", @"MCC");
            rootInfo.Attributes.Add("dir", @"MCC2MCS");
            rootInfo.Attributes.Add("wait", @"0");
            rootInfo.Attributes.Add("time", @"");

            IXmlNodeWithChildren commandNode = new XmlNodeWC("command");
            commandNode.Attributes.Add("name", @"TriggerKSVS");

            XmlHelper testXH = new XmlHelper(rootInfo);
            testXH.AddNode(commandNode);
            testXH.AddNode(nodes);
            testXH.Save("TestCode5.xml");
        }
    }
}