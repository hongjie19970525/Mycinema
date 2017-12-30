using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace MyCinema.Models
{
    /// <summary>
    /// ��Ʊϵͳ��ӰƱ�Ļ��� ����ʵ������ͨƱ
    /// </summary>
    [Serializable]
    public  class Ticket
    {
        public Ticket() { }
        public Ticket(ScheduleItem scheduleItem, Seat seat)
        {
            this.ScheduleItem = scheduleItem;
            this.Seat = seat;
        }

        /// <summary>
        /// ��λ����
        /// </summary>
        private Seat seat;
        public Seat Seat
        {
            get { return seat; }
            set { seat = value; }
        }
        
        

        /// <summary>
        /// Ʊ��
        /// </summary>
        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// �����ķ�ӳ����
        /// </summary>
        private ScheduleItem scheduleItem;
        public ScheduleItem ScheduleItem
        {
            get { return scheduleItem; }
            set { scheduleItem = value; }
        }

        /// <summary>
        /// ����Ʊ�۵ķ���
        /// ����д
        /// </summary>
        public virtual void CalcPrice()
        {
            this.Price = this.ScheduleItem.Movie.Price;
        }
      
        /// <summary>
        /// ��ӡƱʵ��
        /// </summary>
        public virtual void Print()
        {
            string fileName = this.ScheduleItem.Time.Replace(":","-") + " " + this.Seat.SeatNum + ".txt";
            FileStream fs = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("***************************");
            sw.WriteLine("        ����ӰԺ");
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
        public virtual void Show()
        {
            MessageBox.Show("���۳�");
        }

       
    }
}
