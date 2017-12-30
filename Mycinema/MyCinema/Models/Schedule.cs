using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyCinema.Models
{
    /// <summary>
    /// 描述当天的放映计划
    /// </summary>
    [Serializable]
    public class Schedule
    {
        public Schedule()
        {
            items = new Dictionary<string, ScheduleItem>();
        }
        /// <summary>
        /// 放映计划中的放映列表
        /// </summary>
        private Dictionary<string, ScheduleItem> items;
        /// <summary>
        /// 放映计划中的放映列表
        /// </summary>
        public Dictionary<string, ScheduleItem> Items
        {
            get { return items; }
            set { items = value; }
        }
        /// <summary>
        /// 从XML文件读取放映列表数据
        /// </summary>
        public void LoadItems()
        {
            if (items == null)
                items = new Dictionary<string, ScheduleItem>();
            items.Clear();

            XmlDocument myXml = new XmlDocument();
            myXml.Load("ShowList.xml");
            XmlNode feednode = myXml.DocumentElement;
            //中间变量
            string movieName = null;
            string playBill = null;
            string director = null;
            string actor = null;
            string movieType = null;
            string price = null;

            foreach (XmlNode node in feednode.ChildNodes)
            {
                if (node.Name == "Movie")
                {
                    foreach (XmlNode subNode in node.ChildNodes)
                    {
                        switch (subNode.Name)
                        {
                            case "Name":
                                movieName = subNode.InnerText;
                                break;
                            case "Poster":
                                playBill = subNode.InnerText;
                                break;
                            case "Director":
                                director = subNode.InnerText;
                                break;
                            case "Actor":
                                actor = subNode.InnerText;
                                break;
                            case "Type":
                                movieType = subNode.InnerText;
                                break;
                            case "Price":
                                price = subNode.InnerText;
                                break;
                            case "Schedule":
                                foreach (XmlNode scheduleNode in subNode.ChildNodes)
                                {
                                    ScheduleItem item = new ScheduleItem();
                                    item.Time = scheduleNode.InnerText;
                                    item.Movie.MovieName = movieName;
                                    item.Movie.Poster = playBill;
                                    item.Movie.Director = director;
                                    item.Movie.Actor = actor;
                                    item.Movie.MovieType = (MovieType)Enum.Parse(typeof(MovieType), movieType);
                                    item.Movie.Price = int.Parse(price);
                                    items.Add(item.Time,item);
                                }
                                break;
                        }
                    }

                }
            }
        }
    }
}
