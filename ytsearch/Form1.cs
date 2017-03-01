using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeSearch;

namespace ytsearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        int pageNumers = 3;
        int pageNumber = 0;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pageNumber = pageNumber + 3;
            Search();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (pageNumber > 1)
            {
                pageNumber = pageNumber - 3;
                Search();
            }
        }

        public void Search()
        {
            VideoSearch items = new VideoSearch();
            List<Video> list = new List<Video>();
            for (int i = 1; i < pageNumers; i++)
            {
                foreach (var item in items.SearchQuery(txtSearch.Text, pageNumber + i))
                {
                    Video video = new Video();
                    video.Title = item.Title;
                    video.Author = item.Author;
                    video.Url = item.Url;
                    //byte[] imageBytes = new WebClient().DownloadData(item.Thumbnail);
                    /*using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        video.Thumbnail = Image.FromStream(ms);
                    }*/
                    list.Add(video);
                }
            }
            videoBindingSource.DataSource = list;
        }
    }
}
