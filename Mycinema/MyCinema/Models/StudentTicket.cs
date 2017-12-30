using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MyCinema.Models
{
    /// <summary>
    /// 学生票子类
    /// </summary>
    [Serializable]
    public class StudentTicket:Ticket
    {
        public StudentTicket() { }
        public StudentTicket(ScheduleItem scheduleItem, Seat seat, int discount)
            : base(scheduleItem, seat)
        {
            this.Discount = discount;
        }
        
        //折扣数
        private int discount;
        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        /// <summary>
        /// 重写价格
        /// </summary>
        public override void CalcPrice()
        {
            this.Price = this.ScheduleItem.Movie.Price * Discount / 10;
        }

     
        /// <summary>
        /// 打印数据
        /// </summary>
        public override void Print()
        {
            string fileName = this.ScheduleItem.Time.Replace(":", "-") + " " + this.Seat.SeatNum + ".txt";
            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("***************************");
            sw.WriteLine("     青鸟影院 (学生)");
            sw.WriteLine("---------------------------");
            sw.WriteLine(" 电影名：\t{0}", this.ScheduleItem.Movie.MovieName);
            sw.WriteLine(" 时间：  \t{0}", this.ScheduleItem.Time);
            sw.WriteLine(" 座位号：\t{0}", this.Seat.SeatNum);
            sw.WriteLine(" 价格：  \t{0}", this.Price.ToString());
            sw.WriteLine("***************************");
            sw.Close();
            fs.Close();
            
        }

        /// <summary>
        /// 显示售出票信息
        /// </summary>
        public override void Show()
        {
            MessageBox.Show("已售出!\n\n " + this.discount + "折学生票!");
        }
        
    }
}
