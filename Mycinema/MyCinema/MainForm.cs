using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using MyCinema.Models;

namespace MyCinema
{
    public partial class MainForm : Form
    {
        Font font1 = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        Font font2 = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        Cinema cinema;
        Dictionary<string, Label> labels1 = new Dictionary<string, Label>();
        Dictionary<string, Label> labels2 = new Dictionary<string, Label>();
        Dictionary<string, Label> labels3 = new Dictionary<string, Label>();
        int ticket = 0;
        string key = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.lblActor.Text = "";                                    /* 程序加载时，初始化3个放映厅*/
            this.lblDirector.Text = "";
            this.lblMovieName.Text = "";
            this.lblPrice.Text = "";
            this.lblTime.Text = "";
            this.lblType.Text = "";
            this.lblCalcPrice.Text = "";
            this.txtCustomer.Enabled = false;
            this.cmbDisCount.Enabled = false;
            this.rdoNormal.Checked = true;

            cinema = new Cinema();
            ///初始化放映厅座位
            InitSeats(7, 5, tpCinema);
            InitLargeSeats(8, 6, tabLarge);
            InitLoversSeats(3, 5, tabLovers);


            cinema.Load();

        }

        /// <summary>
        /// 初始化放映厅座位
        /// </summary>
        /// <param name="seatRow">行数</param>
        /// <param name="seatLine">列数</param>
        /// <param name="tb"></param>
        //普通厅放映
        private void InitSeats(int seatRow, int seatLine, TabPage tb)
        {
            Label label;
            Seat seat;
            for (int i = 0; i < seatRow; i++)                   /* 加载一号放映厅的位置*/
            {
                for (int j = 0; j < seatLine; j++)
                {
                    label = new Label();
                    //设置背景颜色
                    label.BackColor = Color.Yellow;
                    //设置字体
                    label.Font = font1;                                                                                                         //new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(134)));
                    //设置尺寸
                    label.AutoSize = false;
                    label.Size = new System.Drawing.Size(50, 25);
                    //设置座位号
                    label.Text = (j + 1).ToString() + "-" + (i + 1).ToString();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    //设置位置
                    label.Location = new Point(60 + (i * 90), 60 + (j * 60));
                    //所有的标签都绑定到同一事件
                    label.Click += new System.EventHandler(lblSeat_Click);
                    tb.Controls.Add(label);
                    labels1.Add(label.Text, label);
                    //实例化一个座位
                    seat = new Seat((j + 1).ToString() + "-" + (i + 1).ToString(), Color.Yellow);
                    //保存的座位集合
                    cinema.Seats.Add(seat.SeatNum, seat);
                }
            }
        }

        //加长厅放映
        private void InitLargeSeats(int seatRow, int seatLine, TabPage tb)
        {
            Label label2;
            Seat seat;
            for (int i = 0; i < seatRow; i++)
            {
                for (int j = 0; j < seatLine; j++)
                {
                    label2 = new Label();
                    //设置背景颜色                                /*加载二号放映厅的位子*/
                    label2.BackColor = Color.Yellow;
                    //设置字体
                    label2.Font = font2;                                                         //new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    //设置尺寸
                    label2.AutoSize = false;
                    label2.Size = new System.Drawing.Size(45, 15);
                    //设置座位号
                    label2.Text = (j + 1).ToString() + "-" + (i + 1).ToString();
                    label2.TextAlign = ContentAlignment.MiddleCenter;
                    //设置位置
                    label2.Location = new Point(60 + (i * 90), 60 + (j * 60));
                    //所有的标签都绑定到同一事件
                    label2.Click += new System.EventHandler(lblSeat_Click);
                    tb.Controls.Add(label2);
                    labels2.Add(label2.Text, label2);
                    //实例化一个座位
                    seat = new Seat((j + 1).ToString() + "-" + (i + 1).ToString(), Color.Yellow);
                    //保存的座位集合
                    cinema.Largeseats.Add(seat.SeatNum, seat);//cinema.Seats.Add(seat.SeatNum, seat);
                }
            }
        }

        //情侣厅放映
        private void InitLoversSeats(int seatRow, int seatLine, TabPage tb)
        {
            {
                Label label;
                LoverSeat seat;
                for (int i = 0; i < seatRow; i++)
                {
                    for (int j = 0; j < seatLine; j++)                          /*加载三号放映厅的位子*/
                    {
                        label = new Label();
                        //设置背景颜色
                        label.BackColor = Color.Pink;
                        //设置字体
                        label.Font = new System.Drawing.Font("宋体", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        //设置尺寸
                        label.AutoSize = false;
                        label.Size = new System.Drawing.Size(70, 35);
                        //设置座位号
                        label.Text = (j + 1).ToString() + "-" + (i + 1).ToString();
                        label.TextAlign = ContentAlignment.MiddleCenter;
                        //设置位置
                        label.Location = new Point(60 + (i * 90), 60 + (j * 60));
                        //所有的标签都绑定到同一事件
                        label.Click += new System.EventHandler(lblSeat_Click);
                        tb.Controls.Add(label);
                        labels3.Add(label.Text, label);
                        //实例化一个座位
                        seat = new LoverSeat((j + 1).ToString() + "-" + (i + 1).ToString(), Color.Yellow);
                        //保存的座位集合
                        cinema.Loverseats.Add(seat.SeatNum, seat);
                    }
                }
            }
        }

        //选择“继续销售”
        private void tsmiMovies_Click(object sender, EventArgs e)
        {
            //判断放映列表是否为空
            if (cinema.Schedule.Items.Count == 0)
            {
                cinema.Schedule.LoadItems();
            }
            InitTreeView();
        }

        //选择“获取最新播放列表”
        private void tsmiNew_Click(object sender, EventArgs e)
        {
            cinema.Schedule.LoadItems();
            cinema.SoldTickets.Clear();
            InitTreeView();
        }

        /// <summary>
        /// 初始化TreeView控件
        /// </summary>
        private void InitTreeView()
        {
            tvMovies.BeginUpdate();
            tvMovies.Nodes.Clear();

            string movieName = null;
            TreeNode movieNode = null;
            foreach (ScheduleItem item in cinema.Schedule.Items.Values)
            {
                if (movieName != item.Movie.MovieName)
                {
                    movieNode = new TreeNode(item.Movie.MovieName);
                    tvMovies.Nodes.Add(movieNode);
                }
                TreeNode timeNode = new TreeNode(item.Time);
                movieNode.Nodes.Add(timeNode);
                movieName = item.Movie.MovieName;

            }
            tvMovies.EndUpdate();
        }

        /// <summary>
        /// 选择一场电影事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvMovies_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = tvMovies.SelectedNode;
            if (node == null) return;
            if (node.Level != 1) return;
            key = node.Text;
            //将详细信息显示
            this.lblMovieName.Text = cinema.Schedule.Items[key].Movie.MovieName;
            this.lblDirector.Text = cinema.Schedule.Items[key].Movie.Director;
            this.lblActor.Text = cinema.Schedule.Items[key].Movie.Actor;
            this.lblPrice.Text = cinema.Schedule.Items[key].Movie.Price.ToString();
            this.lblTime.Text = cinema.Schedule.Items[key].Time;
            this.lblType.Text = cinema.Schedule.Items[key].Movie.MovieType.ToString();
            this.picMovie.Image = Image.FromFile(cinema.Schedule.Items[key].Movie.Poster);
            this.lblCalcPrice.Text = "";

            //清空座位
            ClearSeat();
            //遍历该场电影的座位销售情况
            foreach (Ticket ticket in cinema.SoldTickets)
            {
                foreach (Seat seat in cinema.Seats.Values)
                {
                    if ((ticket.ScheduleItem.Time == key)
                        && (ticket.Seat.SeatNum == seat.SeatNum))
                    {
                        seat.Color = Color.Red;
                    }
                }
            }
            UpdateSeat();
        }

        /// <summary>
        /// 清空座位
        /// </summary>
        private void ClearSeat()
        {
            foreach (Seat seat in cinema.Seats.Values)
            {
                seat.Color = Color.Yellow;
            }
        }
        /// <summary>
        /// 更新座位状态 
        /// </summary>
        private void UpdateSeat()
        {
            foreach (string key in cinema.Seats.Keys)
            {
                labels1[key].BackColor = cinema.Seats[key].Color;
                //labels2[key].BackColor = cinema.Seats[key].Color;
                //labels2[key].BackColor = cinema.Largeseats[key].Color;
                //labels3[key].BackColor = cinema.Loverseats[key].Color;
            }
        }

        private void UpdateLargeSeat()
        {
            foreach (string key in cinema.Largeseats.Keys)
            {
                labels2[key].BackColor = cinema.Largeseats[key].Color;
            }
        }

        private void UpdateLoverSeat()
        {
            foreach (string key in cinema.Loverseats.Keys)
            {
                labels3[key].BackColor = cinema.Loverseats[key].Color;
            }
        }
        /// <summary>
        /// 点击一个座位
        /// 买票事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblSeat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.lblMovieName.Text))
            {
                MessageBox.Show("您还没选择电影!", "提示");
                return;
            }
            ticket++;
            try
            {
                string seatNum = ((Label)sender).Text.ToString();
                string customerName = this.txtCustomer.Text.ToString();
                int discount = 0;
                string type = "";
                if (this.rdoStudent.Checked)
                {
                    type = "student";
                    if (this.cmbDisCount.Text == null)
                    {
                        MessageBox.Show("请输入折扣数!", "提示");
                        return;
                    }
                    else
                    {
                        discount = int.Parse(this.cmbDisCount.Text);
                    }
                }
                else if (this.rdoFree.Checked)
                {
                    if (String.IsNullOrEmpty(this.txtCustomer.Text))
                    {
                        MessageBox.Show("请输入赠票者姓名!", "提示");
                        return;
                    }
                    else
                    {
                        type = "free";
                    }
                }


                //调用工具类创建普通票
                Ticket newTicket = TicketUtil.CreateTicket(cinema.Schedule.Items[key], cinema.Seats[seatNum],
                    discount, customerName, type);
                //Ticket LoverTicket = TicketUtil.CreateTicket(cinema.Schedule.Items[key], cinema.Loverseats[seatNum], discount, customerName,type);
                if (cinema.Seats[seatNum].Color == Color.Yellow)
                {
                    //打印
                    DialogResult result;
                    result = MessageBox.Show("是否购买?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        cinema.Seats[seatNum].Color = Color.Red;
                        UpdateSeat();
                        /*cinema.Largeseats[seatNum].Color = Color.Red;
                        UpdateLargeSeat();
                        cinema.Loverseats[seatNum].Color = Color.Red;
                        UpdateLoverSeat();*/
                        newTicket.CalcPrice();
                        cinema.SoldTickets.Add(newTicket);
                        lblCalcPrice.Text = newTicket.Price.ToString();
                        newTicket.Print();
                    }
                    else if (result == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    //显示当前售出票的信息
                    foreach (Ticket ticket0 in cinema.SoldTickets)
                    {
                        //判断是否为同场次、同电影、同座位号
                        if (ticket0.Seat.SeatNum == seatNum && ticket0.ScheduleItem.Time == tvMovies.SelectedNode.Text && ticket0.ScheduleItem.Movie.MovieName == tvMovies.SelectedNode.Parent.Text)
                        {
                            ticket0.Show();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //情侣票的创建
      /* private void lblLoverseat_Click(object sender,EventArgs e)
        {
            if (String.IsNullOrEmpty(this.lblMovieName.Text))
            {
                MessageBox.Show("您还没选择电影!", "提示");
                return;
            }
            //调用工具创建情侣票
            Ticket LoverTicket = TicketUtil.CreateTicket(cinema.Schedule.Items[key], cinema.Loverseats[seatNum], discount, customerName, type);
            if(cinema.Loverseats[])
            {

            }
        }        

        
   */     

        //选择“赠票”时
        private void rdoFree_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCustomer.Enabled = true;
            this.cmbDisCount.Enabled = false;
            this.cmbDisCount.Text = "";
            //设置“优惠价”
            this.lblCalcPrice.Text = "0";
        }

        //选择“学生票”时
        private void rdoStudent_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Text = "";
            this.cmbDisCount.Enabled = false;
            this.cmbDisCount.Text = "7";
            //根据当前选中的电影，设置“优惠价”
            if(this.lblPrice.Text!="")
            {
                int price = int.Parse(this.lblPrice.Text);
                int discount = int.Parse(this.cmbDisCount.Text);
                this.lblCalcPrice.Text = (price * discount / 10).ToString();
            }
            
        }

        //选择“普通票”时
        private void rdoNormal_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbDisCount.Enabled = false;
            this.txtCustomer.Text = "";
            this.txtCustomer.Enabled = false;
            this.cmbDisCount.Enabled = false;
            this.lblCalcPrice.Text = "";
            //int price = int.Parse(this.lblPrice.Text);        
            //this.lblCalcPrice.Text = (price-10).ToString();
        }
        //选择情侣票
        private void rdoLovers_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Text = "";
            this.cmbDisCount.Enabled = false;
            this.cmbDisCount.Text = "8";
            //this.cmbDisCount.Enabled = false;
            if(this.lblPrice.Text!="")
            {
                int price = int.Parse(this.lblPrice.Text);
                int discount = int.Parse(this.cmbDisCount.Text);
                this.lblCalcPrice.Text = (price * discount / 10).ToString();
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            cinema.Save();
            this.Dispose();
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            cinema.Save();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult close;
            close = MessageBox.Show("是否保存当前销售状态?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (close == DialogResult.Yes)
            {
                //退出时保存Cinema对象
                cinema.Save();
            }
        }

        //选择“不同折扣”下拉列表
        private void cmbDisCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //根据当前选中的电影，设置“优惠价”
            if (this.lblPrice.Text != "")
            {
                int price = int.Parse(this.lblPrice.Text);
                int discount = int.Parse(this.cmbDisCount.Text);
                this.lblCalcPrice.Text = (price * discount / 10).ToString();
            }
        }

        private void tpCinema_Click(object sender, EventArgs e)
        {

        }

       
    }
}