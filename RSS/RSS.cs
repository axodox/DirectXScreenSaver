using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Net;
using System.IO;

namespace RSS
{
    public class Feed
    {
        public static Feed FromStrings(string[] items)
        {
            Feed F = new Feed();
            F.Channels = new Channel[1];
            F.Channels[0] = new Channel("", "", "");
            F.Channels[0].Items = new Item[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                F.Channels[0].Items[i] = new Item() { Description = items[i] };
            }
            return F;
        }
        public static Feed FromInternet(string url)
        {
            HttpWebResponse response = null;
            StreamReader SR = null;
            XmlDocument XD = null;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 2000;
                response = (HttpWebResponse)request.GetResponse();
                SR = new StreamReader(response.GetResponseStream());
                string source = SR.ReadToEnd();
                XD = new XmlDocument();
                XD.LoadXml(source);
            }
            catch(WebException)
            {

            }
            finally
            {
                if (response != null) response.Close();
                if (SR != null) SR.Close();
            }
            if (XD == null)
            {
                return null;
            }
            else
            {
                Feed F = new Feed();
                try
                {
                    XmlNode rssNode = XD.SelectSingleNode("rss");
                    F.Channels = new Channel[rssNode.ChildNodes.Count];
                    int i = 0;
                    foreach (XmlNode channelNode in rssNode.ChildNodes)
                    {
                        F.Channels[i] = new Channel(channelNode.GetRSSChildAttr("title"), channelNode.GetRSSChildAttr("link"), channelNode.GetRSSChildAttr("description"));
                        XmlNodeList itemNodes = channelNode.SelectNodes("item");
                        F.Channels[i].Items = new Item[itemNodes.Count];
                        int j = 0;
                        foreach (XmlNode itemNode in itemNodes)
                        {
                            F.Channels[i].Items[j] = new Item();
                            F.Channels[i].Items[j].Title = itemNode.GetRSSChildAttr("title");
                            F.Channels[i].Items[j].Link = itemNode.GetRSSChildAttr("link");
                            F.Channels[i].Items[j].Description = itemNode.GetRSSChildAttr("description");
                            F.Channels[i].Items[j].Author = itemNode.GetRSSChildAttr("author");
                            F.Channels[i].Items[j].Comments = itemNode.GetRSSChildAttr("comments");
                            j++;
                        }
                        i++;
                    }
                    return F;
                }
                catch
                {
                    return null;
                }
            }
        }
        private Feed()
        {
        }
        public Channel[] Channels;
    }

    public class Channel
    {
        public Channel(string Title, string Link, string Description)
        {
            this.Title=Title;
            this.Link=Link;
            this.Description=Description;
        }
        public string Title, Link, Description;
        public Item[] Items;
    }

    public class Item
    {
        public string Title, Link, Description, Author, Comments;
    }

    public static class RSSXMLExtensions
    {
        public static string GetRSSChildAttr(this XmlNode Node, string Name)
        {
            try
            {
                return Node.SelectSingleNode(Name).InnerText;
            }
            catch
            {
                return "";
            }
        }
    }
}
