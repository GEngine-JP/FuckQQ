using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using QQloginCont;
using System.Threading;
using System.Xml;
using System.Resources;

namespace QQ
{
	/// <summary>
	/// main 的摘要说明。
	/// </summary>
	public class main : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel pLogin;
		private System.Windows.Forms.Panel pGroup;
		private System.Windows.Forms.Panel pFriend;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button menu;
		private System.Windows.Forms.Button search;
		private System.Windows.Forms.TreeView tGroup;
		private System.Windows.Forms.TreeView tFriend;
		private string uid="";
		private string pwd="";
		private int Now;
		private bool IsLogin=false;
		private bool ShowIcon=true;
		private bool go=true;
		/// <summary>
		/// 表示图标状态，具体值为：1表示正常状态，2表示闪烁状态，3表示登陆状态
		/// </summary>
		private int IconModel;//1表示正常状态，2表示闪烁状态，3表示登陆状态
		private ArrayList WinName=new ArrayList();
		private ArrayList MsgId=new ArrayList();
		private MessageServer Server;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.Timer timer2;
		private System.Windows.Forms.NotifyIcon notifyIcon2;
		private System.Windows.Forms.NotifyIcon notifyIcon3;
		private System.Windows.Forms.NotifyIcon notifyIcon4;
		private System.ComponentModel.IContainer components;

		public main(string id,string pass)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			uid=id;
			pwd=pass;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(main));
			this.pLogin = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pGroup = new System.Windows.Forms.Panel();
			this.tGroup = new System.Windows.Forms.TreeView();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.pFriend = new System.Windows.Forms.Panel();
			this.button4 = new System.Windows.Forms.Button();
			this.tFriend = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.search = new System.Windows.Forms.Button();
			this.menu = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.contextMenu1 = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon2 = new System.Windows.Forms.NotifyIcon(this.components);
			this.notifyIcon3 = new System.Windows.Forms.NotifyIcon(this.components);
			this.notifyIcon4 = new System.Windows.Forms.NotifyIcon(this.components);
			this.pLogin.SuspendLayout();
			this.pGroup.SuspendLayout();
			this.pFriend.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pLogin
			// 
			this.pLogin.BackColor = System.Drawing.Color.Transparent;
			this.pLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pLogin.BackgroundImage")));
			this.pLogin.Controls.Add(this.label1);
			this.pLogin.Controls.Add(this.pictureBox1);
			this.pLogin.Location = new System.Drawing.Point(0, 0);
			this.pLogin.Name = "pLogin";
			this.pLogin.Size = new System.Drawing.Size(176, 520);
			this.pLogin.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label1.Location = new System.Drawing.Point(56, 176);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "登陆中…";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(24, 120);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(136, 136);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// pGroup
			// 
			this.pGroup.Controls.Add(this.tGroup);
			this.pGroup.Controls.Add(this.button2);
			this.pGroup.Controls.Add(this.button1);
			this.pGroup.Location = new System.Drawing.Point(0, 56);
			this.pGroup.Name = "pGroup";
			this.pGroup.Size = new System.Drawing.Size(176, 400);
			this.pGroup.TabIndex = 1;
			this.pGroup.Visible = false;
			// 
			// tGroup
			// 
			this.tGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tGroup.ImageIndex = -1;
			this.tGroup.Location = new System.Drawing.Point(0, 48);
			this.tGroup.Name = "tGroup";
			this.tGroup.SelectedImageIndex = -1;
			this.tGroup.Size = new System.Drawing.Size(176, 352);
			this.tGroup.TabIndex = 4;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(0, 24);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(176, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "QQ群";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(0, 0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(176, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "QQ好友";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pFriend
			// 
			this.pFriend.Controls.Add(this.button4);
			this.pFriend.Controls.Add(this.tFriend);
			this.pFriend.Controls.Add(this.button3);
			this.pFriend.Location = new System.Drawing.Point(0, 56);
			this.pFriend.Name = "pFriend";
			this.pFriend.Size = new System.Drawing.Size(176, 400);
			this.pFriend.TabIndex = 2;
			this.pFriend.Visible = false;
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(0, 0);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(176, 23);
			this.button4.TabIndex = 7;
			this.button4.Text = "QQ好友";
			// 
			// tFriend
			// 
			this.tFriend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tFriend.ImageList = this.imageList1;
			this.tFriend.Indent = 14;
			this.tFriend.Location = new System.Drawing.Point(0, 24);
			this.tFriend.Name = "tFriend";
			this.tFriend.ShowLines = false;
			this.tFriend.Size = new System.Drawing.Size(176, 352);
			this.tFriend.TabIndex = 9;
			this.tFriend.MouseHover += new System.EventHandler(this.tFriend_MouseHover);
			this.tFriend.DoubleClick += new System.EventHandler(this.tFriend_DoubleClick);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(0, 376);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(176, 23);
			this.button3.TabIndex = 8;
			this.button3.Text = "QQ群";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.search);
			this.groupBox1.Controls.Add(this.menu);
			this.groupBox1.Location = new System.Drawing.Point(0, 456);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(176, 72);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// search
			// 
			this.search.Location = new System.Drawing.Point(88, 24);
			this.search.Name = "search";
			this.search.Size = new System.Drawing.Size(64, 23);
			this.search.TabIndex = 1;
			this.search.Text = "搜索";
			// 
			// menu
			// 
			this.menu.Location = new System.Drawing.Point(16, 24);
			this.menu.Name = "menu";
			this.menu.Size = new System.Drawing.Size(64, 23);
			this.menu.TabIndex = 0;
			this.menu.Text = "菜单";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(72, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 24);
			this.label3.TabIndex = 8;
			this.label3.Text = "隐身";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(16, 8);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(40, 40);
			this.pictureBox3.TabIndex = 7;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
			// 
			// contextMenu1
			// 
			this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItem1,
																						 this.menuItem2,
																						 this.menuItem7,
																						 this.menuItem8});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem9});
			this.menuItem1.Text = "好友资料";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "下载好友分组";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "上传好友分组";
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 2;
			this.menuItem9.Text = "刷新在线资料";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem5,
																					  this.menuItem6});
			this.menuItem2.Text = "群组资料";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 0;
			this.menuItem5.Text = "下载群组资料";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "上传群组资料";
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.Text = "关于…";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 3;
			this.menuItem8.Text = "退出";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenu = this.contextMenu1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "QQ:0";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
			// 
			// timer2
			// 
			this.timer2.Interval = 300;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// notifyIcon2
			// 
			this.notifyIcon2.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon2.Icon")));
			this.notifyIcon2.Text = "notifyIcon2";
			// 
			// notifyIcon3
			// 
			this.notifyIcon3.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon3.Icon")));
			this.notifyIcon3.Text = "notifyIcon3";
			// 
			// notifyIcon4
			// 
			this.notifyIcon4.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon4.Icon")));
			this.notifyIcon4.Text = "notifyIcon4";
			// 
			// main
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(175, 512);
			this.ContextMenu = this.contextMenu1;
			this.ControlBox = false;
			this.Controls.Add(this.pLogin);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pFriend);
			this.Controls.Add(this.pGroup);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "main";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "QQ";
			this.Load += new System.EventHandler(this.main_Load);
			this.pLogin.ResumeLayout(false);
			this.pGroup.ResumeLayout(false);
			this.pFriend.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			PlaySound.play(3);
			this.pFriend.Visible=true;
			this.pGroup.Visible=false;
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			PlaySound.play(3);
		//	MessageBox.Show("群功能尚未开放！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			this.pGroup.Visible=true;
			this.pFriend.Visible=false;
		}

		private void main_Load(object sender, System.EventArgs e)
		{
			this.pLogin.Visible=true;
			this.IconModel=3;
	//		LoginNow();
			if(DateTime.Now.Second<54)
			{
				Now=DateTime.Now.Second+5;
			}
			Now=0;
			this.timer2.Start();
			this.timer1.Start();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(DateTime.Now.Second==Now)
			{
				try
				{
					LoginNow();
				}
				catch(Exception ex)
				{
					MessageBox.Show("登陆失败！失败原因："+ex.Message,"登陆失败",MessageBoxButtons.OK,MessageBoxIcon.Information);
					this.Visible=false;
					Form1 show=new Form1();
					show.ShowDialog();
				}
				this.IconModel=1;
				this.timer1.Stop();
			}
		}

		private void LoginNow()
		{
			if(go)
			{
				go=false;
				if(Login.QLogin(uid,pwd))
				{
					ShareDate.ThisUser=uid;
					this.Text="QQ:"+uid;
					this.notifyIcon1.Text="QQ:"+uid;
					this.pLogin.Visible=false;
					this.pFriend.Visible=true;
					this.pGroup.Visible=false;
					UserInf check=new UserInf();
					check.UserNumber=uid;
					check.isHaveFriendInf();
					if(!check.CheckResult)
					{
						check.CreateUserDir(Application.StartupPath);
						check.CreateFile(Application.StartupPath);
						check.CreateOnlineFile(Application.StartupPath);
						Login.SendMsgToGetFriendInf(uid);
					}
					while(!Login.SendMsgToGetOnlineInf())
					{}
					Server=new MessageServer();
					Server.Co=this;
					if(!Server.IniServer(uid))
					{
						MessageBox.Show("服务启动错误！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
						Application.Exit();
					}
					FillTreefriend();
					UserInf.TellMyFriendIOnLine(uid);
				}
				else
				{
					MessageBox.Show("登陆失败！失败原因：用户名或密码错误","登陆失败",MessageBoxButtons.OK,MessageBoxIcon.Information);
					this.Visible=false;
					Form1 show=new Form1();
					show.ShowDialog();
				}
				this.timer2.Stop();
				this.ShowIconModel(1);
			}
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			try
			{
				Server.DisposeServer();
				Application.Exit();
			}
			catch
			{}
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			try
			{
				about show=new about();
				show.ShowDialog();
			}
			catch
			{}
		}
		private void FillTreefriend()
		{
			this.tFriend.Nodes.Clear();
			XmlDataDocument Xmldate=new XmlDataDocument();
			Xmldate.Load(uid+"\\FriendInf.dat");
			XmlNode root=Xmldate.DocumentElement;
			for(int i=0;i<root.ChildNodes.Count;i++)
			{	
				XmlNode group=root.ChildNodes[i];
				System.Windows.Forms.TreeNode father=new System.Windows.Forms.TreeNode();
				father.Text=group.Attributes["GroupName"].Value;
				father.ImageIndex=2;
				father.SelectedImageIndex=2;
				this.tFriend.Nodes.Add(father);
				FillFriendSon(i,group);
			}
		}
		private void FillFriendSon(int fatherId,XmlNode father)
		{
			for(int i=0;i<father.ChildNodes.Count;i++)
			{
				System.Windows.Forms.TreeNode son = new System.Windows.Forms.TreeNode();
				son.Text=father.ChildNodes[i].ChildNodes[1].InnerText+"("+father.ChildNodes[i].ChildNodes[0].InnerText+")";
				ShareDate.QQName.Add(father.ChildNodes[i].ChildNodes[1].InnerText);
				ShareDate.QQNumber.Add(father.ChildNodes[i].ChildNodes[0].InnerText);
				if(isThisUserOnline(father.ChildNodes[i].ChildNodes[0].InnerText))
				{
					son.ImageIndex=1;
					son.SelectedImageIndex=1;
				}
				else
				{
					son.ImageIndex=0;
					son.SelectedImageIndex=0;
				}
				this.tFriend.Nodes[fatherId].Nodes.Add(son);
			}
		}
		private bool isThisUserOnline(string uid)
		{
			bool online=false;
			XmlDataDocument onlineInf=new XmlDataDocument();
			onlineInf.Load("online.dat");
			XmlNode root=onlineInf.SelectSingleNode("root");
			for(int i=0;i<root.ChildNodes.Count;i++)
			{
				if(uid.Trim()==root.ChildNodes[i].ChildNodes[0].InnerText.Trim())
				{
					online=true;
					break;
				}
			}
			return(online);
		}

		private void tFriend_MouseHover(object sender, System.EventArgs e)
		{
//			int nodeX=main.MousePosition.X-this.tFriend.Location.X;
//			int nodeY=main.MousePosition.Y-this.tFriend.Location.Y;
//			MessageBox.Show(nodeX+"   "+nodeY);
			//MessageBox.Show("到时间显示用户信息拉！");
		}

		private void tFriend_DoubleClick(object sender, System.EventArgs e)
		{
			string ShowInf;
			bool online=false;
			bool IsHaveThisWin=false;
			int TempWinHand=0;
			ShowInf=this.tFriend.SelectedNode.FullPath;
			if(ShowInf.IndexOf("\\",0)!=-1)
			{
				if(this.tFriend.SelectedNode.SelectedImageIndex==0)
				{
					online=false;
				}
				else
				{
					online=true;
				}
				CheckOutNum check=new CheckOutNum(this.tFriend.SelectedNode.Text);
				for(int i=0;i<ShareDate.WinName.Count;i++)
				{
					if(check.QQnumber.Trim()==ShareDate.WinName[i].ToString().Trim())
					{
						TempWinHand=int.Parse(ShareDate.WinHand[i].ToString());
						IsHaveThisWin=true;
						break;
					}
				}
				if(!IsHaveThisWin)
				{
					MsgSend msg=new MsgSend(this.tFriend.SelectedNode.Text,online);
					IntPtr hand=new IntPtr();
					hand=msg.Handle;
					ShareDate.WinHand.Add(hand);
					ShareDate.WinName.Add(check.QQnumber);
					msg.Show();
				}
				else
				{
					TrafficMsg.PostMessage(TempWinHand,501,0,0);
				}
			}
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			while(!Login.SendMsgToGetOnlineInf())
			{}
			FillTreefriend();
		}

		private void pictureBox3_Click(object sender, System.EventArgs e)
		{
			this.Visible=false;
		}

		private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.IconModel==1)
			{
				this.Visible=true;
			}
			else
			{
				this.IconModel=1;
				for(int i=0;i<WinName.Count;i++)
				{
					string ShowName=UserInf.GetUserNameByUserNumber(this.WinName[i].ToString())+"("+this.WinName[i].ToString()+")";
					MsgSend temp=new MsgSend(ShowName,true);
					ShareDate.WinName.Add(this.WinName[i].ToString());
					ShareDate.WinHand.Add(temp.Handle);
					temp.Show();
					TrafficMsg.PostMessage(temp.Handle.ToInt32(),500,int.Parse(this.MsgId[i].ToString()),0);
					WinName.RemoveAt(i);
					MsgId.RemoveAt(i);
				}
				ResourceManager resources = new ResourceManager(typeof(main));
				this.ShowIconModel(1);
				this.timer2.Stop();
			}
		}
		protected override void DefWndProc(ref System.Windows.Forms.Message m)
		{
			switch(m.Msg)
			{
				case 500://播放声音
					PlaySound.play(m.WParam.ToInt32());
					break;
				case 501://闪烁图标
					this.WinName.Add(Regx.CheckUserNumber(m.WParam.ToString()));
					this.MsgId.Add(m.LParam.ToInt32());
					this.IconModel=2;
					this.timer2.Start();
					break;
				default:
					base.DefWndProc(ref m);
					break;
			}
		}

		private void timer2_Tick(object sender, System.EventArgs e)
		{
			if(this.IconModel==2)
			{
				if(ShowIcon)
				{
					ShowIcon=false;
					this.ShowIconModel(1);
				}
				else
				{
					ShowIcon=true;
					this.ShowIconModel(2);
				}
			}
			if(this.IconModel==3)
			{
				if(ShowIcon)
				{
					ShowIcon=false;
					this.ShowIconModel(3);
				}
				else
				{
					ShowIcon=true;
					this.ShowIconModel(4);
				}
			}
		}
		private void ShowIconModel(int ShowMode)
		{
			ResourceManager resources = new ResourceManager(typeof(main));
			switch(ShowMode)
			{
				case 1://登陆后显示正常图标
					this.notifyIcon1.Icon=((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
					break;
				case 2://登陆后显示空白图标
					this.notifyIcon1.Icon=((System.Drawing.Icon)(resources.GetObject("notifyIcon2.Icon")));
					break;
				case 3://登陆前显示向左图标
					this.notifyIcon1.Icon=((System.Drawing.Icon)(resources.GetObject("notifyIcon3.Icon")));
					break;
				case 4://登陆前显示向右图标
					this.notifyIcon1.Icon=((System.Drawing.Icon)(resources.GetObject("notifyIcon4.Icon")));
					break;
				default://显示默认图标
					this.notifyIcon1.Icon=((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
					break;
			}
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			while(!Login.SendMsgToGetFriendInf(uid))
			{}
			FillTreefriend();
		}
	}
}
