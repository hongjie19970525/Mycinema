using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing;

namespace MyCinema.Models
{
    public class Cinema
    {
        public Cinema()
        {
            seats = new Dictionary<string, Seat>();
            LargeSeats = new Dictionary<string, Seat>();
            LoverSeats = new Dictionary<string, LoverSeat>();
            soldTickets = new List<Ticket>();
            schedule = new Schedule();
        }
        /// <summary>
        /// 放映厅座位集合
        /// </summary>
        private Dictionary<string, Seat> seats;
        public Dictionary<string, Seat> Seats
        {
            get { return seats; }
            set { seats = value; }
        }

        private Dictionary<string, Seat> LargeSeats;
        public Dictionary<string,Seat>Largeseats
        {
            get { return LargeSeats; }
            set { LargeSeats = value; }
        }

        private Dictionary<string, LoverSeat> LoverSeats;
        public Dictionary<string, LoverSeat>Loverseats
        {
            get { return LoverSeats; }
            set { LoverSeats = value; }
        }


        private Schedule schedule;
        /// <summary>
        /// 当天的放映计划
        /// </summary>
        public Schedule Schedule
        {
            get { return schedule; }
            set { schedule = value; }
        }

        private List<Ticket> soldTickets;
        public List<Ticket> SoldTickets
        {
            get { return soldTickets; }
            set { soldTickets = value; }
        }

        //保存售票信息到文件中
        public void Save()
        {
            FileStream fs = new FileStream("soldTickets.txt", FileMode.OpenOrCreate);
            StreamWriter writer = new StreamWriter(fs, Encoding.Default);
            for (int index = 0; index < SoldTickets.Count; index++)
            {
                Ticket ticket = SoldTickets[index];
                string info = "|" + ticket.ScheduleItem.Movie.MovieName + "|" + ticket.ScheduleItem.Movie.Poster + "|" +
                    ticket.ScheduleItem.Movie.Director + "|" + ticket.ScheduleItem.Movie.Actor + "|" + ticket.ScheduleItem.Movie.MovieType.ToString() + "|" +
                    ticket.ScheduleItem.Movie.Price + "|" + ticket.ScheduleItem.Time + "|" + ticket.Seat.SeatNum + "|" + ticket.Seat.Color + "|" + ticket.Price + "|";
                if (ticket is FreeTicket)
                {
                    string customerName=((FreeTicket)ticket).CustomerName;
                    writer.WriteLine("free" + info + customerName);
                }
                else if (ticket is StudentTicket)
                {
                    
                    writer.WriteLine("student" + info + "");
                }
                else
                {
                    writer.WriteLine("" + info + "");
                }
            }
            writer.WriteLine("The End");
            writer.Close();
            fs.Close();
        }

        //从文件中读取售票信息
        public void Load()
        {
            try
            {
                StreamReader reader = new StreamReader("soldTickets.txt", Encoding.GetEncoding("GB2312"));
                string line = reader.ReadLine();
                string[] propertyValues;
                Ticket ticket = null;

                while (line.Trim() != "The End")
                {
                    propertyValues = line.Split('|');
                    string type = propertyValues[0];

                    Movie movie = new Movie(propertyValues[1], propertyValues[2], propertyValues[3], propertyValues[4], (MovieType)Enum.Parse(typeof(MovieType), propertyValues[5]), int.Parse(propertyValues[6]));
                    ScheduleItem scheduleItem = new ScheduleItem();
                    scheduleItem.Time = propertyValues[7];
                    scheduleItem.Movie = movie;
                    string color = propertyValues[9];
                    string endColor = color.Substring(color.IndexOf("[") + 1, color.Length - 1 - color.IndexOf("[") - 1);
                    Seat seat = new Seat(propertyValues[8], Color.FromName(endColor));

                    int discount = 10;
                    switch (type)
                    {
                        case "student":
                            discount = 7;
                            ticket = TicketUtil.CreateTicket(scheduleItem, seat, discount, "", type);
                            break;
                        case "free":
                            discount = 0;
                            ticket = TicketUtil.CreateTicket(scheduleItem, seat, discount, propertyValues[11], type);
                            break;
                        default:
                            discount = 10;
                            ticket = TicketUtil.CreateTicket(scheduleItem, seat, discount, "", "");
                            break;
                    }


                    this.SoldTickets.Add(ticket);
                    line = reader.ReadLine();
                }
                reader.Close();

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("出错了:"+ex.Message);
                soldTickets = new List<Ticket>();
            }
        }
    }
}
