using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using qqServerManger;

namespace qqServer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (regx.isNull(this.tIpQQ.Text) || regx.isNull(this.tPortQQ.Text))
            {
                MessageBox.Show("请输入qq服务器ip地址或端口号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (regx.isIpaddres(this.tIpQQ.Text))
                {
                    if (qSaveConfigServer.SaveConfigServer(this.tIpQQ.Text, this.tPortQQ.Text))
                    {
                        MessageBox.Show("信息保存成功！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("你输入ip地址错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string DataIp = this.tDataIp.Text;
            string DataBase = this.tDataName.Text;
            string DataUid = this.tDataUid.Text;
            string DataPwd = this.tDataPwd.Text;
            if (regx.isNull(DataIp) || regx.isNull(DataBase) || regx.isNull(DataUid) || regx.isNull(DataPwd))
            {
                MessageBox.Show("请你输入服务器信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (regx.isIpaddres(DataIp))
                {
                    if (qSaveConfigServer.SaveConfigDate(DataIp, DataBase, DataUid, DataPwd))
                    {
                        MessageBox.Show("信息保存成功！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("保存失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("你输入ip地址错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string DataIp = this.tDataIp.Text;
            string DataBase = this.tDataName.Text;
            string DataUid = this.tDataUid.Text;
            string DataPwd = this.tDataPwd.Text;
            if (regx.isNull(DataIp) || regx.isNull(DataBase) || regx.isNull(DataUid) || regx.isNull(DataPwd))
            {
                MessageBox.Show("请你输入服务器信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (SqlConnectionTest.ConnectionTest(DataIp, DataBase, DataUid, DataPwd))
                {
                    MessageBox.Show("链接测试成功！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("链接测试失败！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}