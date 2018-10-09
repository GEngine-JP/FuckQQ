using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using QQloginCont;

namespace QQ
{
	/// <summary>
	/// MsgSend ��ժҪ˵����
	/// </summary>
	public class MsgSend : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label2;
		private string Myfriend;
		private string FriendNumber;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label inf;
		private bool Online=false;
		private bool SendMsg=false;
		private System.Windows.Forms.Timer timer1;
		private SendMessage send=new SendMessage();

		public MsgSend(string friend,bool isOnline)
		{
			//
			// Windows ���������֧���������
			//
			this.Myfriend=friend;
			this.Online=isOnline;
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MsgSend));
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.inf = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Location = new System.Drawing.Point(0, 48);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(336, 272);
			this.richTextBox1.TabIndex = 3;
			this.richTextBox1.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(336, 152);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(176, 72);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "�Է�״̬";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(3, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 40);
			this.label1.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox2.Controls.Add(this.pictureBox2);
			this.groupBox2.Location = new System.Drawing.Point(336, 224);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(176, 240);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "�ҵ�����";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(24, 16);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(128, 216);
			this.pictureBox2.TabIndex = 0;
			this.pictureBox2.TabStop = false;
			// 
			// textBox1
			// 
			this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox1.Location = new System.Drawing.Point(0, 344);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(336, 80);
			this.textBox1.TabIndex = 6;
			this.textBox1.Text = "";
			this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.Transparent;
			this.button3.Enabled = false;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Location = new System.Drawing.Point(0, 320);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(336, 23);
			this.button3.TabIndex = 7;
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.Transparent;
			this.button4.Location = new System.Drawing.Point(160, 432);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(72, 23);
			this.button4.TabIndex = 8;
			this.button4.Text = "�ر�";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.Transparent;
			this.button5.Location = new System.Drawing.Point(248, 432);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(72, 23);
			this.button5.TabIndex = 1;
			this.button5.Text = "����Enter";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
			this.groupBox3.Controls.Add(this.pictureBox1);
			this.groupBox3.Location = new System.Drawing.Point(336, 48);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(176, 104);
			this.groupBox3.TabIndex = 10;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "���";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(4, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(168, 80);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.ForeColor = System.Drawing.Color.Red;
			this.label2.Location = new System.Drawing.Point(8, 432);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 11;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Transparent;
			this.button2.Location = new System.Drawing.Point(88, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(72, 23);
			this.button2.TabIndex = 13;
			this.button2.Text = "���Ŀռ�";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Transparent;
			this.button1.Location = new System.Drawing.Point(8, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "������Ϸ";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.Color.Transparent;
			this.button6.ForeColor = System.Drawing.Color.Red;
			this.button6.Location = new System.Drawing.Point(168, 16);
			this.button6.Name = "button6";
			this.button6.TabIndex = 14;
			this.button6.Text = "��Ϊ����";
			this.button6.Visible = false;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// inf
			// 
			this.inf.BackColor = System.Drawing.Color.Transparent;
			this.inf.ForeColor = System.Drawing.Color.Red;
			this.inf.Location = new System.Drawing.Point(248, 16);
			this.inf.Name = "inf";
			this.inf.Size = new System.Drawing.Size(256, 23);
			this.inf.TabIndex = 15;
			this.inf.Text = "��û�мӶԷ�Ϊ���ѣ����ǶԷ���������";
			this.inf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.inf.Visible = false;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// MsgSend
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(512, 464);
			this.Controls.Add(this.inf);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.richTextBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MsgSend";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MsgSend_Closing);
			this.Load += new System.EventHandler(this.MsgSend_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void MsgSend_Load(object sender, System.EventArgs e)
		{
			CheckOutNum check=new CheckOutNum(this.Myfriend);
			FriendNumber=check.QQnumber;
			if(check.QQname.Trim()=="")
			{
				this.button6.Visible=true;
				this.Text="�� "+check.QQnumber+" ������";
				this.inf.Visible=true;
			}
			else
			{
				this.Text="�� "+check.QQname+" ������";
			}
			if(this.Online)
			{
				this.label1.Text="�Է�����";
			}
			else
			{
				this.label1.Text="�Է�������";
			}
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			SendMsgToHim();
		}

		public void AddMsg(string msg)
		{
			this.richTextBox1.Text+=msg+"\n";
		}
		protected override void DefWndProc(ref System.Windows.Forms.Message m)
		{
			switch(m.Msg)
			{
				case 500://�����������Ϣ
					string MsgToAdd;
					MsgToAdd=ShareDate.Msg[m.WParam.ToInt32()].ToString();
					AddMsg(MsgToAdd);
					break;
				case 501://�������弤��
					this.Activate();
					break;
				default:
					base.DefWndProc(ref m);
					break;
			}
		}

		private void MsgSend_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			ShareDate.WinHand.Remove(this.Handle);
			ShareDate.WinName.Remove(FriendNumber);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("��Ϸ�ӿڣ�����δ���ţ�","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);//������Ϸ�ӿ�
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			string SerInfFile="SerInf\\SerInf.dat";
			string StrIp=getSerInf.ReadXmlNode(SerInfFile,"//root//server//ip");
			System.Diagnostics.Process.Start("http://"+StrIp+"/QQWebSite/Zone/Default.aspx?id="+this.FriendNumber.Trim());
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(!send.Result)
			{
				AddMsg("<!--��ղŷ��͵�\""+send.Msg+"\"û�з��ͳɹ���-->");
			}
			this.timer1.Stop();
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			string Inf=Login.AddFriend(ShareDate.ThisUser,FriendNumber);
			MessageBox.Show(Inf,"��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
			if(Inf=="��ϲ����Ӻ��ѳɹ�����ˢ��")
			{
				this.button6.Visible=false;
				this.inf.Visible=false;
			}
		}

		private void SendMsgToHim()
		{
			if(this.Online)
			{
				if(this.textBox1.Text.Trim()!="")
				{
					this.timer1.Start();
					AddMsg("��˵��("+UserInf.GetTime()+")\n��   "+this.textBox1.Text);
					string checkmsg=this.textBox1.Text;
					send.Msg=checkmsg.Replace(';','��');
					send.ToDistUser=Myfriend;
					send.send();
					this.textBox1.Text="";
					this.label2.Text="";
				}
				else
				{
					this.label2.Text="���ܷ��Ϳ���Ϣ��";
				}
			}
			else
			{
				MessageBox.Show("�Բ��𣡶Է������ߣ���������֧�����߷��ͣ�","��ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

		private void textBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyValue==13)
			{
				SendMsgToHim();
				//		SendMsg=false;
				this.textBox1.Text="";
			}	
		}
	}
}
