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
                MessageBox.Show("������qq������ip��ַ��˿ں�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (regx.isIpaddres(this.tIpQQ.Text))
                {
                    if (qSaveConfigServer.SaveConfigServer(this.tIpQQ.Text, this.tPortQQ.Text))
                    {
                        MessageBox.Show("��Ϣ����ɹ���", "��ϲ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("����ʧ�ܣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("������ip��ַ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("���������������Ϣ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (regx.isIpaddres(DataIp))
                {
                    if (qSaveConfigServer.SaveConfigDate(DataIp, DataBase, DataUid, DataPwd))
                    {
                        MessageBox.Show("��Ϣ����ɹ���", "��ϲ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("����ʧ�ܣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("������ip��ַ����", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("���������������Ϣ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (SqlConnectionTest.ConnectionTest(DataIp, DataBase, DataUid, DataPwd))
                {
                    MessageBox.Show("���Ӳ��Գɹ���", "��ϲ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("���Ӳ���ʧ�ܣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}