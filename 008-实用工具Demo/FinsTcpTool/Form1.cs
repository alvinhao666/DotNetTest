using OmronFinsTCP.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinsTcpTool
{
    public partial class Form1 : Form
    {
        EtherNetPLC _etherNetPLC = new EtherNetPLC();

        private string _ip;

        private ushort _port;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Connect_Click(object sender, EventArgs e)
        {
            _ip = txt_IP.Text.Trim();

            if (string.IsNullOrWhiteSpace(_ip))
            {
                MessageBox.Show("请填写IP地址");
                return;
            }

            if (!Regex.IsMatch(_ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"))
            {
                MessageBox.Show("IP数据异常，请检查");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_IP.Text))
            {
                MessageBox.Show("请填写端口号");
                return;
            }

            if (ushort.TryParse(txt_Port.Text.Trim(), out ushort port))
            {
                _port = port;
            }
            else
            {
                MessageBox.Show("端口号异常，请检查");
                return;
            }

            if (_etherNetPLC.Link(_ip, (short)_port, 1000) < 0)
            {
                MessageBox.Show("连接失败",);
            }
        }

        /// <summary>
        /// 断开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {

        }
    }
}
