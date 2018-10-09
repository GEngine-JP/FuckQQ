using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using System.IO;
using qqServerManger;

namespace qqServer
{
    public partial class Form1 : Form
    {
        private string SerIp = "";
        private string SerPort = "";
        private Server QQserver = new Server();
        private string SysInf = "QQ2008服务已经停止！";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "")
            {
                MessageBox.Show("请选择服务器！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.toolStripStatusLabel2.Text = "服务启动中……";
                if (QQserver.IniServer(SerIp, SerPort))
                {
                    QQserver.StartServer();
                    XmlFileOp.DelThisFile("onlineinf\\onLine.xml");
                    this.pictureBox1.Image = global::qqServer.Properties.Resources.start;
                    this.button1.Enabled = false;
                    this.button2.Enabled = true;
                    SysInf = "QQ2008服务正在运行！";
                    this.notifyIcon1.Icon = ((System.Drawing.Icon)(global::qqServer.Properties.Resources.ser_start));
                    this.toolStripStatusLabel2.Text = "服务已经运行";
                }
                else
                {
                    MessageBox.Show("无法初始化服务！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 show = new Form2();
            show.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (QQserver.StopServer())
            {
                this.button1.Enabled = true;
                this.button2.Enabled = false;
                this.toolStripStatusLabel2.Text = "服务已停止！";
                SysInf = "QQ2008服务已经停止！";
                this.notifyIcon1.Icon = ((System.Drawing.Icon)(global::qqServer.Properties.Resources.ser_stop));
                this.pictureBox1.Image = global::qqServer.Properties.Resources.stop;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string SerXmlUrl="config\\ipConfig.dat";
            SerIp = qSaveConfigServer.GetValueByNode(SerXmlUrl, "//root//server//ip");
            SerPort = qSaveConfigServer.GetValueByNode(SerXmlUrl, "//root//server//port");
            if (SerIp == "-1" || SerPort == "-1")
            {
                MessageBox.Show("系统配置文件错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.button1.Enabled = false;
            }
            else
            {
                this.comboBox1.Items.Add(SerIp);
                this.pictureBox1.Image = global::qqServer.Properties.Resources.stop;
                this.toolStripStatusLabel2.Text = "服务已停止！";
                this.button2.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.checkBox1.Checked)
                {
                    RegistryKey ms_run = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    ms_run.SetValue("mistysoft", Application.ExecutablePath.ToString());
                }
                else
                {
                    RegistryKey ms_run = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                    ms_run.SetValue("mistysoft", "");
                }
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("保存设置失败！请确认本程序能够访问注册表", "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 fo = new Form3();
            fo.ShowDialog();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
            this.notifyIcon1.Text = SysInf;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}