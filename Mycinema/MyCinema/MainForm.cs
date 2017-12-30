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
        Font font1 = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        Font font2 = new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.lblActor.Text = "";                                    /* �������ʱ����ʼ��3����ӳ��*/
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
            ///��ʼ����ӳ����λ
            InitSeats(7, 5, tpCinema);
            InitLargeSeats(8, 6, tabLarge);
            InitLoversSeats(3, 5, tabLovers);


            cinema.Load();

        }

        /// <summary>
        /// ��ʼ����ӳ����λ
        /// </summary>
        /// <param name="seatRow">����</param>
        /// <param name="seatLine">����</param>
        /// <param name="tb"></param>
        //��ͨ����ӳ
        private void InitSeats(int seatRow, int seatLine, TabPage tb)
        {
            Label label;
            Seat seat;
            for (int i = 0; i < seatRow; i++)                   /* ����һ�ŷ�ӳ����λ��*/
            {
                for (int j = 0; j < seatLine; j++)
                {
                    label = new Label();
                    //���ñ�����ɫ
                    label.BackColor = Color.Yellow;
                    //��������
                    label.Font = font1;                                                                                                         //new System.Drawing.Font("����", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(134)));
                    //���óߴ�
                    label.AutoSize = false;
                    label.Size = new System.Drawing.Size(50, 25);
                    //������λ��
                    label.Text = (j + 1).ToString() + "-" + (i + 1).ToString();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    //����λ��
                    label.Location = new Point(60 + (i * 90), 60 + (j * 60));
                    //���еı�ǩ���󶨵�ͬһ�¼�
                    label.Click += new System.EventHandler(lblSeat_Click);
                    tb.Controls.Add(label);
                    labels1.Add(label.Text, label);
                    //ʵ����һ����λ
                    seat = new Seat((j + 1).ToString() + "-" + (i + 1).ToString(), Color.Yellow);
                    //�������λ����
                    cinema.Seats.Add(seat.SeatNum, seat);
                }
            }
        }

        //�ӳ�����ӳ
        private void InitLargeSeats(int seatRow, int seatLine, TabPage tb)
        {
            Label label2;
            Seat seat;
            for (int i = 0; i < seatRow; i++)
            {
                for (int j = 0; j < seatLine; j++)
                {
                    label2 = new Label();
                    //���ñ�����ɫ                                /*���ض��ŷ�ӳ����λ��*/
                    label2.BackColor = Color.Yellow;
                    //��������
                    label2.Font = font2;                                                         //new System.Drawing.Font("����", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    //���óߴ�
                    label2.AutoSize = false;
                    label2.Size = new System.Drawing.Size(45, 15);
                    //������λ��
                    label2.Text = (j + 1).ToString() + "-" + (i + 1).ToString();
                    label2.TextAlign = ContentAlignment.MiddleCenter;
                    //����λ��
                    label2.Location = new Point(60 + (i * 90), 60 + (j * 60));
                    //���еı�ǩ���󶨵�ͬһ�¼�
                    label2.Click += new System.EventHandler(lblSeat_Click);
                    tb.Controls.Add(label2);
                    labels2.Add(label2.Text, label2);
                    //ʵ����һ����λ
                    seat = new Seat((j + 1).ToString() + "-" + (i + 1).ToString(), Color.Yellow);
                    //�������λ����
                    cinema.Largeseats.Add(seat.SeatNum, seat);//cinema.Seats.Add(seat.SeatNum, seat);
                }
            }
        }

        //��������ӳ
        private void InitLoversSeats(int seatRow, int seatLine, TabPage tb)
        {
            {
                Label label;
                LoverSeat seat;
                for (int i = 0; i < seatRow; i++)
                {
                    for (int j = 0; j < seatLine; j++)                          /*�������ŷ�ӳ����λ��*/
                    {
                        label = new Label();
                        //���ñ�����ɫ
                        label.BackColor = Color.Pink;
                        //��������
                        label.Font = new System.Drawing.Font("����", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                        //���óߴ�
                        label.AutoSize = false;
                        label.Size = new System.Drawing.Size(70, 35);
                        //������λ��
                        label.Text = (j + 1).ToString() + "-" + (i + 1).ToString();
                        label.TextAlign = ContentAlignment.MiddleCenter;
                        //����λ��
                        label.Location = new Point(60 + (i * 90), 60 + (j * 60));
                        //���еı�ǩ���󶨵�ͬһ�¼�
                        label.Click += new System.EventHandler(lblSeat_Click);
                        tb.Controls.Add(label);
                        labels3.Add(label.Text, label);
                        //ʵ����һ����λ
                        seat = new LoverSeat((j + 1).ToString() + "-" + (i + 1).ToString(), Color.Yellow);
                        //�������λ����
                        cinema.Loverseats.Add(seat.SeatNum, seat);
                    }
                }
            }
        }

        //ѡ�񡰼������ۡ�
        private void tsmiMovies_Click(object sender, EventArgs e)
        {
            //�жϷ�ӳ�б��Ƿ�Ϊ��
            if (cinema.Schedule.Items.Count == 0)
            {
                cinema.Schedule.LoadItems();
            }
            InitTreeView();
        }

        //ѡ�񡰻�ȡ���²����б�
        private void tsmiNew_Click(object sender, EventArgs e)
        {
            cinema.Schedule.LoadItems();
            cinema.SoldTickets.Clear();
            InitTreeView();
        }

        /// <summary>
        /// ��ʼ��TreeView�ؼ�
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
        /// ѡ��һ����Ӱ�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvMovies_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = tvMovies.SelectedNode;
            if (node == null) return;
            if (node.Level != 1) return;
            key = node.Text;
            //����ϸ��Ϣ��ʾ
            this.lblMovieName.Text = cinema.Schedule.Items[key].Movie.MovieName;
            this.lblDirector.Text = cinema.Schedule.Items[key].Movie.Director;
            this.lblActor.Text = cinema.Schedule.Items[key].Movie.Actor;
            this.lblPrice.Text = cinema.Schedule.Items[key].Movie.Price.ToString();
            this.lblTime.Text = cinema.Schedule.Items[key].Time;
            this.lblType.Text = cinema.Schedule.Items[key].Movie.MovieType.ToString();
            this.picMovie.Image = Image.FromFile(cinema.Schedule.Items[key].Movie.Poster);
            this.lblCalcPrice.Text = "";

            //�����λ
            ClearSeat();
            //�����ó���Ӱ����λ�������
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
        /// �����λ
        /// </summary>
        private void ClearSeat()
        {
            foreach (Seat seat in cinema.Seats.Values)
            {
                seat.Color = Color.Yellow;
            }
        }
        /// <summary>
        /// ������λ״̬ 
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
        /// ���һ����λ
        /// ��Ʊ�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblSeat_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.lblMovieName.Text))
            {
                MessageBox.Show("����ûѡ���Ӱ!", "��ʾ");
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
                        MessageBox.Show("�������ۿ���!", "��ʾ");
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
                        MessageBox.Show("��������Ʊ������!", "��ʾ");
                        return;
                    }
                    else
                    {
                        type = "free";
                    }
                }


                //���ù����ഴ����ͨƱ
                Ticket newTicket = TicketUtil.CreateTicket(cinema.Schedule.Items[key], cinema.Seats[seatNum],
                    discount, customerName, type);
                //Ticket LoverTicket = TicketUtil.CreateTicket(cinema.Schedule.Items[key], cinema.Loverseats[seatNum], discount, customerName,type);
                if (cinema.Seats[seatNum].Color == Color.Yellow)
                {
                    //��ӡ
                    DialogResult result;
                    result = MessageBox.Show("�Ƿ���?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
                    //��ʾ��ǰ�۳�Ʊ����Ϣ
                    foreach (Ticket ticket0 in cinema.SoldTickets)
                    {
                        //�ж��Ƿ�Ϊͬ���Ρ�ͬ��Ӱ��ͬ��λ��
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

        //����Ʊ�Ĵ���
      /* private void lblLoverseat_Click(object sender,EventArgs e)
        {
            if (String.IsNullOrEmpty(this.lblMovieName.Text))
            {
                MessageBox.Show("����ûѡ���Ӱ!", "��ʾ");
                return;
            }
            //���ù��ߴ�������Ʊ
            Ticket LoverTicket = TicketUtil.CreateTicket(cinema.Schedule.Items[key], cinema.Loverseats[seatNum], discount, customerName, type);
            if(cinema.Loverseats[])
            {

            }
        }        

        
   */     

        //ѡ����Ʊ��ʱ
        private void rdoFree_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCustomer.Enabled = true;
            this.cmbDisCount.Enabled = false;
            this.cmbDisCount.Text = "";
            //���á��Żݼۡ�
            this.lblCalcPrice.Text = "0";
        }

        //ѡ��ѧ��Ʊ��ʱ
        private void rdoStudent_CheckedChanged(object sender, EventArgs e)
        {
            this.txtCustomer.Enabled = false;
            this.txtCustomer.Text = "";
            this.cmbDisCount.Enabled = false;
            this.cmbDisCount.Text = "7";
            //���ݵ�ǰѡ�еĵ�Ӱ�����á��Żݼۡ�
            if(this.lblPrice.Text!="")
            {
                int price = int.Parse(this.lblPrice.Text);
                int discount = int.Parse(this.cmbDisCount.Text);
                this.lblCalcPrice.Text = (price * discount / 10).ToString();
            }
            
        }

        //ѡ����ͨƱ��ʱ
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
        //ѡ������Ʊ
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
            close = MessageBox.Show("�Ƿ񱣴浱ǰ����״̬?", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (close == DialogResult.Yes)
            {
                //�˳�ʱ����Cinema����
                cinema.Save();
            }
        }

        //ѡ�񡰲�ͬ�ۿۡ������б�
        private void cmbDisCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            //���ݵ�ǰѡ�еĵ�Ӱ�����á��Żݼۡ�
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