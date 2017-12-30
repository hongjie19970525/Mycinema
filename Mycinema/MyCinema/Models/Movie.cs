using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyCinema.Models
{
    public enum MovieType
    {
        //ϲ��
        Comedy,
        //ս��
        War,
        //����
        Romance,
        //����
        Action,
        //��ͨ
        Cartoon,
        //�ֲ�
        Thriller,
        //ð��
        Adventure
    }

    [Serializable]
    public class Movie
    {
        public Movie() { }
        public Movie(string movieName, string poster, string director,string actor,MovieType movieType,int price)
        {
            this.MovieName = movieName;
            this.Poster = poster;
            this.Director = director;
            this.Actor = actor;
            this.MovieType = movieType;
            this.Price = price;
        }

        /// <summary>
        /// ��Ӱ����
        /// </summary>
        private string movieName;
        public string MovieName
        {
            get { return movieName; }
            set { movieName = value; }
        }

        /// <summary>
        /// ����ͼƬ��
        /// </summary>
        private string poster;
        public string Poster
        {
            get { return poster; }
            set { poster = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        private string director;
        public string Director
        {
            get { return director; }
            set { director = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        private string actor;
        public string Actor
        {
            get { return actor; }
            set { actor = value; }
        }

        /// <summary>
        /// ��Ӱ����
        /// </summary>
        private MovieType movieType;
        public MovieType MovieType
        {
            get { return movieType; }
            set { movieType = value; }
        }

        /// <summary>
        /// ��Ӱ����
        /// </summary>
        private int price;
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
