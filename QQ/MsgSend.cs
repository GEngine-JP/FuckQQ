using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using QQloginCont;

namespace QQ
{
	/// <summary>
	/// MsgSend 的摘要说明。
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
			// Windows 窗体设计器支持所必需的
			//
			this.Myfriend=friend;
			this.Online=isOnline;
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
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
			this.groupBox1.Text = "对方状态";
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
			this.groupBox2.Text = "我的形象";
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
			this.button4.Text = "关闭";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.Transparent;
			this.button5.Location = new System.Drawing.Point(248, 432);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(72, 23);
			this.button5.TabIndex = 1;
			this.button5.Text = "发送Enter";
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
			this.groupBox3.Text = "广告";
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
			this.button2.Text = "他的空间";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Transparent;
			this.button1.Location = new System.Drawing.Point(8, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(72, 23);
			this.button1.TabIndex = 12;
			this.button1.Text = "和他游戏";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button6
			// 
			this.button6.BackColor = System.Drawing.Color.Transparent;
			this.button6.ForeColor = System.Drawing.Color.Red;
			this.button6.Location = new System.Drawing.Point(168, 16);
			this.button6.Name = "button6";
			this.button6.TabIndex = 14;
			this.button6.Text = "加为好友";
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
			this.inf.Text = "你没有加对方为好友！但是对方加你啦！";
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
				this.Text="和 "+check.QQnumber+" 聊天中";
				this.inf.Visible=true;
			}
			else
			{
				this.Text="和 "+check.QQname+" 聊天中";
			}
			if(this.Online)
			{
				this.label1.Text="对方在线";
			}
			else
			{
				this.label1.Text="对方不在线";
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
				case 500://向窗体中添加消息
					string MsgToAdd;
					MsgToAdd=ShareDate.Msg[m.WParam.ToInt32()].ToString();
					AddMsg(MsgToAdd);
					break;
				case 501://将本窗体激活
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
			MessageBox.Show("游戏接口！功能未开放！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);//留待游戏接口
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
				AddMsg("<!--你刚才发送的\""+send.Msg+"\"没有发送成功！-->");
			}
			this.timer1.Stop();
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			string Inf=Login.AddFriend(ShareDate.ThisUser,FriendNumber);
			MessageBox.Show(Inf,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			if(Inf=="恭喜！添加好友成功！请刷新")
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
					AddMsg("我说：("+UserInf.GetTime()+")\n　   "+this.textBox1.Text);
					string checkmsg=this.textBox1.Text;
					send.Msg=checkmsg.Replace(';','；');
					send.ToDistUser=Myfriend;
					send.send();
					this.textBox1.Text="";
					this.label2.Text="";
				}
				else
				{
					this.label2.Text="不能发送空消息！";
				}
			}
			else
			{
				MessageBox.Show("对不起！对方不在线！服务器不支持离线发送！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
