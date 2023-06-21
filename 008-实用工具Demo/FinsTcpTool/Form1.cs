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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinsTcpTool
{
    public partial class Form1 : Form
    {
        EtherNetPLC _etherNetPLC;

        private string _ip;

        private ushort _port;

        private bool _isConnected = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            txt_IP.SelectionStart = 0;
            txt_IP.SelectionLength = 0;
            btn_Close.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LocalConfig.Instance.LoadConfig();
            txt_IP.Text = LocalConfig.Instance.IP;
            txt_Port.Text = LocalConfig.Instance.Port.ToString();
        }

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Connect_Click(object sender, EventArgs e)
        {
            if (!ValidateParam()) return;

            try
            {
                await Task.Run(async () => {

                    this.Invoke(new Action(() => {
                        this.btn_Connect.Text = "连接中...";
                    }));

                    await Task.Delay(5000);

                    _etherNetPLC = new EtherNetPLC();

                    if (_etherNetPLC.Link(_ip, (short)_port, 5000) == 0)
                    {
                        _isConnected = true;

                        this.Invoke(new Action(() => {
                            this.btn_Connect.Text = "已连接...";
                            this.btn_Connect.Enabled = false;
                            this.btn_Close.Enabled = true;
                        }));
                    }
                    else
                    {
                        MessageBox.Show("连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接失败! {ex}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 断开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_Close_Click(object sender, EventArgs e)
        {
            if (!_isConnected || _etherNetPLC == null) return;

            this.btn_Close.Enabled = false;
            try
            {
                await Task.Run(() => {

                    if (_etherNetPLC.Close() == 0)
                    {
                        _isConnected = false;
                        this.Invoke(new Action(() => {
                            this.btn_Connect.Text = "连接";
                            this.btn_Connect.Enabled = true;
                            this.btn_Close.Enabled = false;
                        }));
                    }
                    else
                    {
                        this.btn_Close.Enabled = true;
                        MessageBox.Show($"断开失败! ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"断开失败! {ex}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 保存参数配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!ValidateParam()) return;

            if (LocalConfig.Instance.IP == _ip && LocalConfig.Instance.Port == _port) return;

            LocalConfig.Instance.IP = _ip;

            LocalConfig.Instance.Port = _port;

            LocalConfig.Instance.SaveConfig();
        }


        /// <summary>
        /// 验证
        /// </summary>
        /// <returns></returns>
        private bool ValidateParam()
        {
            _ip = txt_IP.Text.Trim();

            if (string.IsNullOrWhiteSpace(_ip))
            {
                MessageBox.Show("请填写IP地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Regex.IsMatch(_ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$"))
            {
                MessageBox.Show("IP数据异常，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txt_Port.Text))
            {
                MessageBox.Show("请填写端口号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (ushort.TryParse(txt_Port.Text.Trim(), out ushort port))
            {
                _port = port;
            }
            else
            {
                MessageBox.Show("端口号异常，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
