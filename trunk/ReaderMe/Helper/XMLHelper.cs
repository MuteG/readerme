using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;

namespace GP.Tools.ReaderMe.Helper
{
    /// <summary>
    /// XML文档操作类
    /// </summary>
    public class XMLHelper
    {
        #region 变量声明

        // XML文档
        private XmlDocument xmlFile = new XmlDocument();
        // XML文档根节点
        private XmlElement xmlRoot = null;
        // XML文档路径（完整路径）
        private string filePath;
        private const string NAME_SPACE = "NS";
        private XmlNamespaceManager xmlNameMgr; 

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数（默认的目标XML文档是与程序同名）
        /// </summary>
        public XMLHelper()
        {
            // 默认是与程序同名的xml文件
            filePath = AppDomain.CurrentDomain.BaseDirectory +
                Process.GetCurrentProcess().ProcessName + ".xml";
            xmlFile.Load(filePath);
            xmlRoot = GetRoot();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="xmlFilePath">XML文档完整路径</param>
        public XMLHelper(string xmlFilePath)
        {
            filePath = xmlFilePath;
            CreateXmlFile();
            xmlFile.Load(filePath);
            xmlRoot = GetRoot();
        }

        /// <summary>
        /// 新建一个XML文档
        /// </summary>
        private void CreateXmlFile()
        {
            if (!File.Exists(filePath))
            {
                XmlTextWriter xmlWriter = new XmlTextWriter(filePath, System.Text.Encoding.UTF8);
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Root");
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Close();
                //StreamWriter writer = File.CreateText(filePath);
                //writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                //writer.WriteLine("<Root>");
                //writer.WriteLine("</Root>");
                //writer.Close();
            }
        }

        /// <summary>
        /// 获得根节点
        /// </summary>
        /// <returns>根节点</returns>
        private XmlElement GetRoot()
        {
            XmlElement result = xmlFile.DocumentElement;
            xmlNameMgr = new XmlNamespaceManager(xmlFile.NameTable);
            xmlNameMgr.AddNamespace(NAME_SPACE, result.NamespaceURI);
            return result;
        }

        #endregion

        #region 简单的对于根节点下的一级子节点进行操作

        /// <summary>
        /// 获得指定一级子节点的值
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="nodeIndex">节点索引值</param>
        /// <returns>节点值</returns>
        public string GetNodeValue(string nodeName, int nodeIndex)
        {
            XmlNodeList list;
            string result = "";
            if (xmlRoot.HasChildNodes)
            {
                if (nodeIndex < 0)
                {
                    nodeIndex = 0;
                }
                list = xmlRoot.GetElementsByTagName(nodeName);
                if (list.Count > nodeIndex)
                {
                    result = list.Item(nodeIndex).InnerText;
                    if (null == result)
                    {
                        result = "";
                    }
                    result = result.Trim();
                }
            }
            return result;
        }

        /// <summary>
        /// 设置一级节点值
        /// 2008-10-23 高云鹏 修改 如果是插入新节点，新节点插入到最后一个同名节点之后
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="nodeIndex">节点索引值</param>
        /// <param name="nodeValue">节点值</param>
        /// <returns>返回当前节点的index</returns>
        public int SetNodeValue(string nodeName, int nodeIndex, string nodeValue)
        {
            int result = 0;
            XmlNodeList nodeList;
            if (nodeIndex < 0)
            {
                nodeIndex = 0;
            }
            nodeList = xmlRoot.SelectNodes(nodeName, xmlNameMgr); // GetElementsByTagName(nodeName);
            if (nodeList.Count > nodeIndex)
            {
                nodeList.Item(nodeIndex).InnerText = nodeValue;
                result = nodeIndex;
            }
            else
            {
                XmlNode newNode = xmlFile.CreateNode(XmlNodeType.Element, nodeName, xmlFile.NamespaceURI);
                newNode.InnerText = nodeValue;
                if (0 == nodeList.Count)
                {
                    xmlRoot.AppendChild(newNode);
                    result = 0;
                }
                else
                {
                    result = nodeList.Count;
                    xmlRoot.InsertAfter(newNode, nodeList.Item(result - 1));
                }
            }
            xmlFile.Save(filePath);
            return result;
        }

        /// <summary>
        /// 设置指定一级子节点的属性
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="nodeIndex">如果有多个同名节点，指定节点Index</param>
        /// <param name="attrName">属性名</param>
        /// <param name="attrValue">属性值 </param>
        public void SetAttrValue(string nodeName, int nodeIndex, string attrName, string attrValue)
        {
            XmlNodeList list;
            if (xmlRoot.HasChildNodes)
            {
                if (nodeIndex < 0)
                {
                    nodeIndex = 0;
                }
                list = xmlRoot.GetElementsByTagName(nodeName);
                XmlAttribute attr;
                if (list.Count > nodeIndex)
                {
                    attr = list.Item(nodeIndex).Attributes[attrName];
                    if (null != attr)
                    {
                        attr.Value = attrValue;
                    }
                    else
                    {
                        attr = xmlFile.CreateAttribute(attrName);
                        attr.Value = attrValue;
                        list.Item(nodeIndex).Attributes.Append(attr);
                    }
                }
                else
                {
                    XmlNode newNode = xmlFile.CreateNode("element", nodeName, xmlFile.NamespaceURI);
                    attr = xmlFile.CreateAttribute(attrName, xmlFile.NamespaceURI);
                    attr.Value = attrValue;
                    try
                    {
                        newNode.Attributes.Append(attr);
                        xmlRoot.InsertAfter(newNode, xmlRoot.LastChild);
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message;
                    }
                    xmlRoot.InsertAfter(newNode, xmlRoot.LastChild);
                    //XMLRoot.InnerXml += "<" + nodeName + " " + attrName + "=\"" + attrValue + "\"/>";
                }
                xmlFile.Save(filePath);
            }
        }

        /// <summary>
        /// 统计根节点下子节点数量
        /// </summary>
        /// <returns>子节点数量</returns>
        public int GetNodeCount()
        {
            return xmlRoot.ChildNodes.Count;
        }

        /// <summary>
        /// 统计根节点下子节点数量
        /// </summary>
        /// <param name="nodeName">子节点名</param>
        /// <returns>子节点数量</returns>
        public int GetNodeCount(string nodeName)
        {
            return xmlRoot.GetElementsByTagName(nodeName).Count;
        }

        #endregion

        #region 通过XPath定位和操作XML文档

        /// <summary>
        /// 将指定XPath的节点，包装成指定Type的对象列表
        /// 节点内子节点的值，将赋值给对象的对应属性，因此对象的属性名与子节点的名称应该一致
        /// </summary>
        /// <typeparam name="T">对象类型（要封装的类）</typeparam>
        /// <param name="nodeXPath">节点的XPath</param>
        /// <param name="objType">要封装的对象的Type</param>
        /// <returns>封装好的对象列表</returns>
        /// <example>
        /// 对象中存在属性Name, Age，则XML对应结构应为
        /// <![CDATA[
        /// <Nodes>
        ///     <Node>
        ///         <Name>GYP</Name>
        ///         <Age>26</Age>
        ///     </Node>
        /// </Nodes>
        /// ]]>
        /// XPath为//Nodes/Node
        /// </example>
        public List<T> GetAllNodeValues<T>(string nodeXPath)
        {
            List<T> result = new List<T>();
            Type objType = typeof(T);
            string xpath = CheckXPathNameSpace(nodeXPath);
            XmlNodeList nodeList = xmlRoot.SelectNodes(xpath, xmlNameMgr);
            PropertyInfo[] properties = objType.GetProperties();
            for (int i = 0; i < nodeList.Count; i++)
            {
                T o = Activator.CreateInstance<T>();
                XmlNode node = nodeList[i];
                o = GetAllNodeValues<T>(node, properties);
                result.Add(o);
            }
            return result;
        }

        /// <summary>
        /// 将指定的节点封装成指定的对象
        /// </summary>
        /// <param name="node">要封装的节点</param>
        /// <param name="properties">封装成对象的属性列表</param>
        /// <param name="obj">被封装成的对象</param>
        private T GetAllNodeValues<T>(XmlNode node, PropertyInfo[] properties)
        {
            T result = Activator.CreateInstance<T>();
            string namespacea = xmlFile.NamespaceURI;
            for (int j = 0; j < properties.Length; j++)
            {
                XmlNode cNode = SelectSingleNodeWithXPath(node, NAME_SPACE + ":" + properties[j].Name);

                if (cNode != null)
                {
                    switch (properties[j].PropertyType.Name)
                    {
                        case "Int32":
                            {
                                properties[j].SetValue(result, int.Parse(cNode.InnerText), null);
                                break;
                            }
                        case "String":
                            {
                                properties[j].SetValue(result, cNode.InnerText, null);
                                break;
                            }
                        case "Boolean":
                            {
                                properties[j].SetValue(result, bool.Parse(cNode.InnerText), null);
                                break;
                            }
                        default:
                            {
                                break;
                            }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 将指定的节点封装成指定的对象
        /// </summary>
        /// <param name="node">要封装的节点</param>
        /// <param name="obj">被封装成的对象</param>
        private T GetSingleNodeValues<T>(XmlNode node)
        {
            return GetAllNodeValues<T>(node, typeof(T).GetProperties());
        }

        /// <summary>
        /// 将指定的节点封装成指定的对象
        /// </summary>
        /// <param name="nodeXPath">节点的XPath路径</param>
        public T GetSingleNodeValues<T>(string nodeXPath)
        {
            string xpath = CheckXPathNameSpace(nodeXPath);
            XmlNode node = SelectSingleNodeWithXPath(xmlRoot, xpath);
            if (null != node)
            {
                return GetSingleNodeValues<T>(node);
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// 查询符合XPath的第一个节点
        /// </summary>
        /// <param name="searchRootNode">查询的起始节点</param>
        /// <param name="nodeXPath">XPath</param>
        /// <returns>符合XPath的第一个节点（如果没有找到，则返回null）</returns>
        private XmlNode SelectSingleNodeWithXPath(XmlNode searchRootNode, string nodeXPath)
        {
            XmlNode result = null;
            string xpath = CheckXPathNameSpace(nodeXPath);
            result = searchRootNode.SelectSingleNode(xpath, xmlNameMgr);
            return result;
        }

        /// <summary>
        /// 检查XPath的NameSpace设置，将XPath以正确的形式输出
        /// </summary>
        /// <param name="XPath">XPath</param>
        /// <returns>检查并修正后的XPath</returns>
        private string CheckXPathNameSpace(string XPath)
        {
            string result = XPath;
            // 如果已经设定了namespace，需要替换成本功能类默认的命名空间
            MatchCollection matches = Regex.Matches(result, @"[^/]+[:]{1}");
            foreach (Match match in matches)
            {
                result = result.Replace(match.Value, "");
            }
            // 将/开头并且没有设置命名空间的xpath设置上命名空间
            matches = Regex.Matches(result, @"[/]{1}[^/:]+");
            foreach (Match match in matches)
            {
                result = result.Replace(match.Value, match.Value.Replace("/", "/" + NAME_SPACE + ":"));
            }
            // 检查XPath的开头
            if (!"/".Equals(result.Substring(0, 1)))
            {
                result = NAME_SPACE + ":" + result;
            }
            return result;
        }

        /// <summary>
        /// 自动将列表中存储的对象赋值到指定的XPath下的对应子节点
        /// </summary>
        /// <typeparam name="T">列表对象的类</typeparam>
        /// <param name="nodeXPath">XPath</param>
        /// <param name="objList">对象列表</param>
        /// <param name="key">作为对象唯一标识的属性名</param>
        public void SetAllNodeValues<T>(string nodeXPath, List<T> objList, string key)
        {
            for (int i = 0; i < objList.Count; i++)
            {
                SetNodeValue(nodeXPath, objList[i], key);
            }
        }

        /// <summary>
        /// 根据指定的XPATH查找节点，并赋值给obj指定的类的属性
        /// </summary>
        /// <param name="nodeXPath">XPATH</param>
        /// <param name="obj">要赋值的模板类</param>
        /// <param name="key">作为唯一标识的属性名</param>
        public void SetNodeValue(string nodeXPath, object obj, string key)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            PropertyInfo keyProperty = objType.GetProperty(key);
            string keyStr = string.Empty;
            if (!string.IsNullOrEmpty(key))
            {
                keyStr = "[" + key + "=\"" + keyProperty.GetValue(obj, null) + "\"]";
            }
            XmlNode editNode = xmlRoot.SelectSingleNode(nodeXPath + keyStr);
            XmlNode parentNode = xmlRoot;
            if (null == editNode)
            {
                string[] nodeNameArray = nodeXPath.Split("/".ToCharArray());
                for (int i = 0; i < nodeNameArray.Length; i++)
                {
                    editNode = xmlRoot.SelectSingleNode(string.Join("/", nodeNameArray, 0, i + 1));
                    if ((null == editNode) || (i == nodeNameArray.Length - 1))
                    {
                        editNode = xmlFile.CreateNode(XmlNodeType.Element, nodeNameArray[i], xmlFile.NamespaceURI);
                        parentNode.AppendChild(editNode);
                    }
                    parentNode = editNode;
                }
            }

            parentNode = editNode;
            for (int j = 0; j < properties.Length; j++)
            {
                editNode = parentNode.SelectSingleNode(properties[j].Name);
                if (null != editNode)
                {
                    editNode.InnerText = properties[j].GetValue(obj, null).ToString();
                }
                else
                {
                    editNode = xmlFile.CreateNode(XmlNodeType.Element, properties[j].Name, xmlFile.NamespaceURI);
                    editNode.InnerText = properties[j].GetValue(obj, null).ToString();
                    parentNode.AppendChild(editNode);
                }
            }

            xmlFile.Save(filePath);
        }

        /// <summary>
        /// 根据指定的XPATH查找节点，并删除该节点
        /// </summary>
        /// <param name="nodeXPath">XPATH</param>
        /// <param name="obj">要赋值的模板类</param>
        /// <param name="key">作为唯一标识的属性名</param>
        public void RemoveNode(string nodeXPath, object obj, string key)
        {
            Type objType = obj.GetType();
            PropertyInfo[] properties = objType.GetProperties();
            PropertyInfo keyProperty = objType.GetProperty(key);
            XmlNode editNode = xmlRoot.SelectSingleNode(nodeXPath + "[" + key + "=\"" + keyProperty.GetValue(obj, null) + "\"]");
            if (editNode != null)
            {
                string[] xpath = nodeXPath.Split("/".ToCharArray());
                XmlNode parentNode = xmlRoot.SelectSingleNode(string.Join("/", xpath, 0, xpath.Length - 1));
                if (null != parentNode)
                {
                    parentNode.RemoveChild(editNode);
                }
            }
            xmlFile.Save(filePath);
        }
        
        #endregion

        #region 获得指定一级子节点的指定属性值
        /// <summary>
        /// 获得指定一级子节点的指定属性值
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="attrName">属性名</param>
        /// <param name="nodeIndex">节点索引值</param>
        /// <returns>返回属性値</returns>
        public string GetAttrbuteValue(string nodeName, string attrName, int nodeIndex)
        {
            XmlNodeList nlist;
            XmlAttributeCollection aList;
            string result = "";
            if (xmlRoot.HasChildNodes)
            {
                if (nodeIndex < 0)
                {
                    nodeIndex = 0;
                }
                nlist = xmlRoot.GetElementsByTagName(nodeName);
                if (nlist.Count > nodeIndex)
                {
                    aList = nlist.Item(nodeIndex).Attributes;
                    if (aList.GetNamedItem(attrName) != null)
                    {
                        result = aList.GetNamedItem(attrName).Value;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获得指定一级子节点的指定属性值（默认第一个节点）
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="attrName">属性名</param>
        /// <returns>返回属性値</returns>
        public string GetAttrbuteValue(string nodeName, string attrName)
        {
            return GetAttrbuteValue(nodeName, attrName, 0);
        }
        #endregion

        #region 对外简便接口

        /// <summary>
        /// 读取指定节点的值，并以string形式返回（如果存在多个同名子节点，只操作第一个）
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="defaultValue">数值</param>
        /// <returns>节点值</returns>
        public string ReadString(string nodeName, string defaultValue)
        {
            string result = string.Empty;
            result = GetNodeValue(nodeName, 0);
            if (result.Equals(""))
            {
                result = defaultValue;
            }
            return result;
        }

        /// <summary>
        /// 读取指定节点的值，并以int形式返回（如果存在多个同名子节点，只操作第一个）
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="defaultValue">数值</param>
        /// <returns>节点值</returns>
        public int ReadInteger(string nodeName, int defaultValue)
        {
            int result = 0;
            try
            {
                string tmp = GetNodeValue(nodeName, 0);
                if (string.IsNullOrEmpty(tmp))
                {
                    result = defaultValue;
                }
                else
                {
                    result = int.Parse(tmp);
                }
            }
            catch
            {
                result = defaultValue;
            }
            return result;
        }

        /// <summary>
        /// 将string类型数值保存到指定一级子节点中（如果存在多个同名子节点，只操作第一个）
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="nodeValue">数值</param>
        /// <returns>返回当前节点的Index</returns>
        public int WriteString(string nodeName, string nodeValue)
        {
            return SetNodeValue(nodeName, 0, nodeValue);
        }

        /// <summary>
        /// 将int类型数值保存到指定一级子节点中（如果存在多个同名子节点，只操作第一个）
        /// </summary>
        /// <param name="nodeName">节点名</param>
        /// <param name="nodeValue">数值</param>
        /// <returns>返回当前节点的Index</returns>
        public int WriteInteger(string nodeName, int nodeValue)
        {
            return SetNodeValue(nodeName, 0, nodeValue.ToString());
        }

        #endregion
    }
}
