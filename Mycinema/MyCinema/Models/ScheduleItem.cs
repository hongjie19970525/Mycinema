using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyCinema.Models
{
    /// <summary>
    /// ���ų���
    /// </summary>
    [Serializable]
    public class ScheduleItem
    {
        public ScheduleItem()
        {
            movie = new Movie();
        }
        /// <summary>
        /// ��ӳʱ��
        /// </summary>
        private string time;
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        /// <summary>
        /// Ҫ��ӳ�ĵ�Ӱ����
        /// </summary>
        private Movie movie;
        public Movie Movie
        {
            get { return movie; }
            set { movie = value; }
        }
    }
}
