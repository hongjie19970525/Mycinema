using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MyCinema.Models
{
    /// <summary>
    /// ѧ��Ʊ����
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
        
        //�ۿ���
        private int discount;
        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        /// <summary>
        /// ��д�۸�
        /// </summary>
        public override void CalcPrice()
        {
            this.Price = this.ScheduleItem.Movie.Price * Discount / 10;
        }

     
        /// <summary>
        /// ��ӡ����
        /// </summary>
        public override void Print()
        {
            string fileName = this.ScheduleItem.Time.Replace(":", "-") + " " + this.Seat.SeatNum + ".txt";
            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("***************************");
            sw.WriteLine("     ����ӰԺ (ѧ��)");
            sw.WriteLine("---------------------------");
            sw.WriteLine(" ��Ӱ����\t{0}", this.ScheduleItem.Movie.MovieName);
            sw.WriteLine(" ʱ�䣺  \t{0}", this.ScheduleItem.Time);
            sw.WriteLine(" ��λ�ţ�\t{0}", this.Seat.SeatNum);
            sw.WriteLine(" �۸�  \t{0}", this.Price.ToString());
            sw.WriteLine("***************************");
            sw.Close();
            fs.Close();
            
        }

        /// <summary>
        /// ��ʾ�۳�Ʊ��Ϣ
        /// </summary>
        public override void Show()
        {
            MessageBox.Show("���۳�!\n\n " + this.discount + "��ѧ��Ʊ!");
        }
        
    }
}
