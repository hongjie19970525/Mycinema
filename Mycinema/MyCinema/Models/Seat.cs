using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace MyCinema.Models
{
    /// <summary>
    /// 座位类
    /// </summary>
    [Serializable]
    public class Seat
    {
        public Seat(string seatNum, Color color)
        {
            this.SeatNum = seatNum;
            this.Color = color;
        }

        /// <summary>
        /// 座位号
        /// </summary>
        private string seatNum;
        public string SeatNum
        {
            get { return seatNum; }
            set { seatNum = value; }
        }

        /// <summary>
        /// 显示售出与否的颜色属性
        /// </summary>
        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
    }
}
