using HslCommunication;
using HslCommunication.Profinet.Omron;
using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinsTcpTool
{
    public partial class Form2 : Form
    {
        OmronFinsNet _omronFinsNet;

        private string _ip;

        private ushort _port;

        private bool _isConnected = false;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_Close.Enabled = false;
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
                await Task.Run(async () =>
                {

                    this.Invoke(new Action(() =>
                    {
                        this.btn_Connect.Text = "连接中...";
                    }));

                    await Task.Delay(1000);

                    _omronFinsNet = new OmronFinsNet(_ip, _port);

                    var result = _omronFinsNet.ConnectServer();

                    if (result.IsSuccess)
                    {
                        _isConnected = true;

                        this.Invoke(new Action(() =>
                        {
                            this.btn_Connect.Text = "已连接...";
                            this.btn_Connect.Enabled = false;
                            this.btn_Close.Enabled = true;
                        }));
                    }
                    else
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.btn_Connect.Text = "连接";
                        }));

                        MessageBox.Show($"连接失败! {result.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                });
            }
            catch (Exception ex)
            {
                this.btn_Connect.Text = "连接";
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
            if (!_isConnected || _omronFinsNet == null) return;

            this.btn_Close.Enabled = false;
            try
            {
                await Task.Run(() =>
                {

                    var result = _omronFinsNet.ConnectClose();
                    if (result.IsSuccess)
                    {
                        _isConnected = false;
                        _omronFinsNet = null;
                        this.Invoke(new Action(() =>
                        {
                            this.btn_Connect.Text = "连接";
                            this.btn_Connect.Enabled = true;
                            this.btn_Close.Enabled = false;
                        }));
                    }
                    else
                    {
                        this.btn_Close.Enabled = true;
                        MessageBox.Show($"断开失败! {result.Message} ", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            MessageBox.Show($"保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        /// <summary>
        /// bool写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_WriteBool_Click(object sender, EventArgs e)
        {
            if (_omronFinsNet == null)
            {
                MessageBox.Show("请先连接通讯地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_InAddr.Text))
            {
                MessageBox.Show("请填写地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_InValue.Text))
            {
                MessageBox.Show("请填写值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string writeValue = txt_InValue.Text.Trim();

            bool flag = false;

            if (writeValue == "1")
            {
                flag = true;
            }
            else if (writeValue == "0")
            {
                flag = false;
            }
            else
            {
                try
                {
                    flag = bool.Parse(txt_InValue.Text.Trim());
                }
                catch (Exception)
                {
                    MessageBox.Show("写入值有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            string writeAddr = txt_InAddr.Text.Trim();

            var result = _omronFinsNet.Write(writeAddr, flag);

            if (!result.IsSuccess)
            {
                MessageBox.Show($"写入发生错误 {result.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// bool读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_ReadBool_Click(object sender, EventArgs e)
        {
            if (_omronFinsNet == null)
            {
                MessageBox.Show("请先连接通讯地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_OutAddr.Text))
            {
                MessageBox.Show("请填写地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string readAddr = txt_OutAddr.Text.Trim();

            try
            {
                this.btn_ReadBool.Text = "读取中...";
                this.btn_ReadBool.Enabled = false;
                await Task.Run(() =>
                {
                    OperateResult<bool> result = _omronFinsNet.ReadBool(readAddr);

                    if (!result.IsSuccess)
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.btn_ReadBool.Text = "bool读取";
                            this.btn_ReadBool.Enabled = true;
                        }));
                        MessageBox.Show($"读取失败 {result.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.Invoke(new Action(() =>
                    {
                        this.btn_ReadBool.Text = "bool读取";
                        this.btn_ReadBool.Enabled = true;
                        SetListBoxData($"[{DateTime.Now.ToString("HH:mm:ss fff")}]  {result.Content}");
                    }));
                });
            }
            catch (Exception ex)
            {
                this.btn_ReadBool.Text = "bool读取";
                this.btn_ReadBool.Enabled = true;
                MessageBox.Show($"读取失败 {ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// bool数组写入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_WriteBools_Click(object sender, EventArgs e)
        {
            if (_omronFinsNet == null)
            {
                MessageBox.Show("请先连接通讯地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_InAddr.Text))
            {
                MessageBox.Show("请填写地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_InValue.Text))
            {
                MessageBox.Show("请填写值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool[] boolsArray;

            try
            {
                boolsArray = JsonConvert.DeserializeObject<bool[]>(txt_InValue.Text.Trim().ToLower());

                if (boolsArray.Length == 0)
                {
                    MessageBox.Show("数组不能为空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("值有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                throw;
            }

            string writeAddr = txt_InAddr.Text.Trim();

            var result = _omronFinsNet.Write(writeAddr, boolsArray);

            if (!result.IsSuccess)
            {
                MessageBox.Show($"写入失败 {result.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        /// <summary>
        /// bool数组读取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_ReadBools_Click(object sender, EventArgs e)
        {
            if (_omronFinsNet == null)
            {
                MessageBox.Show("请先连接通讯地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_OutAddr.Text))
            {
                MessageBox.Show("请填写地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string readAddr = txt_OutAddr.Text.Trim();


            try
            {
                this.btn_ReadBools.Text = "读取中...";
                this.btn_ReadBools.Enabled = false;
                await Task.Run(() =>
                {

                    OperateResult<bool[]> result = _omronFinsNet.ReadBool(readAddr, 160);

                    if (!result.IsSuccess)
                    {
                        this.Invoke(new Action(() =>
                        {
                            this.btn_ReadBools.Text = "bool数组读取";
                            this.btn_ReadBools.Enabled = true;
                        }));
                        MessageBox.Show($"读取失败 {result.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    this.Invoke(new Action(() =>
                    {
                        this.btn_ReadBools.Text = "bool数组读取";
                        this.btn_ReadBools.Enabled = true;
                        SetListBoxData($"[{DateTime.Now.ToString("HH:mm:ss fff")}]  {JsonConvert.SerializeObject(result.Content)}");
                    }));
                });
            }
            catch (Exception ex)
            {
                this.btn_ReadBools.Text = "bool数组读取";
                this.btn_ReadBools.Enabled = true;
                MessageBox.Show($"读取失败 {ex.Message}", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void SetListBoxData(string str)
        {
            if (lstBox.InvokeRequired)
            {
                Action<string> actionDelegate = (x) =>
                {

                    lstBox.Items.Add(str);

                    lstBox.TopIndex = lstBox.Items.Count - (int)(lstBox.Height / lstBox.ItemHeight);

                };

                lstBox.Invoke(actionDelegate, str);
            }
            else
            {
                lstBox.Items.Add(str);

                lstBox.TopIndex = lstBox.Items.Count - (int)(lstBox.Height / lstBox.ItemHeight);
            }
        }
    }
}
