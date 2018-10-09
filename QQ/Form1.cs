using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using QQloginCont;
using System.IO;
using System.Threading;

namespace QQ
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button reg;
		private System.Windows.Forms.Button login;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
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
				if (components != null) 
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.reg = new System.Windows.Forms.Button();
			this.login = new System.Windows.Forms.Button();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(376, 112);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(40, 136);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "账号";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(40, 176);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "密码";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(96, 176);
			this.textBox2.Name = "textBox2";
			this.textBox2.PasswordChar = '*';
			this.textBox2.Size = new System.Drawing.Size(152, 21);
			this.textBox2.TabIndex = 4;
			this.textBox2.Text = "";
			// 
			// reg
			// 
			this.reg.BackColor = System.Drawing.Color.Transparent;
			this.reg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.reg.Location = new System.Drawing.Point(264, 136);
			this.reg.Name = "reg";
			this.reg.TabIndex = 5;
			this.reg.Text = "注册";
			this.reg.Click += new System.EventHandler(this.reg_Click);
			// 
			// login
			// 
			this.login.BackColor = System.Drawing.Color.Transparent;
			this.login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.login.Location = new System.Drawing.Point(264, 176);
			this.login.Name = "login";
			this.login.TabIndex = 6;
			this.login.Text = "登陆";
			this.login.Click += new System.EventHandler(this.login_Click);
			// 
			// checkBox1
			// 
			this.checkBox1.BackColor = System.Drawing.Color.Transparent;
			this.checkBox1.Location = new System.Drawing.Point(80, 208);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(80, 24);
			this.checkBox1.TabIndex = 7;
			this.checkBox1.Text = "记住密码";
			// 
			// checkBox2
			// 
			this.checkBox2.BackColor = System.Drawing.Color.Transparent;
			this.checkBox2.Location = new System.Drawing.Point(176, 208);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(80, 24);
			this.checkBox2.TabIndex = 8;
			this.checkBox2.Text = "隐身登陆";
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(96, 136);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(152, 20);
			this.comboBox1.TabIndex = 10;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.Highlight;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(376, 248);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.login);
			this.Controls.Add(this.reg);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "QQ2008登陆窗口";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void login_Click(object sender, System.EventArgs e)
		{
			string uid;
			bool RememberMe=this.checkBox1.Checked;
			if(this.comboBox1.SelectedText=="")
			{
				uid=this.comboBox1.Text;
			}
			else
			{
				uid=this.comboBox1.SelectedText;
			}
			string pwd=this.textBox2.Text;
			if(!Regx.isNull(uid)||!Regx.isNull(pwd))
			{
				MessageBox.Show("请输入用户名或密码！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				if(Regx.isNumber(uid))
				{
					UserInf.AddUser(uid,pwd,RememberMe);
					this.Visible=false;
					main Q_main=new main(uid,pwd);
					ShareDate.MainFormHand=Q_main.Handle.ToInt32();
					Q_main.Show();
				}
				else
				{
					MessageBox.Show("请输入合法的QQ号码！","错误",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			PlaySound.play(1);
		}
		private void Form1_Load(object sender, System.EventArgs e)
		{
			QQloginCont.UserInf.DelFile(Application.StartupPath+"\\SerInf\\OnlineInf.dat");
			DataTable dt=UserInf.GetUserInf();
			if(dt!=null)
			{
				this.comboBox1.DataSource=dt;
				this.comboBox1.DisplayMember="user";
				this.comboBox1.ValueMember="pwd";
			}
			this.textBox2.Text="";
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.textBox2.Text=this.comboBox1.SelectedValue.ToString().Trim();
		}

		private void reg_Click(object sender, System.EventArgs e)
		{
			if(MessageBox.Show("客户端现在未开放注册接口！若需要注册，请到官网！\n点击是访问官网","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information)==DialogResult.Yes)
			{
				string SerInfFile="SerInf\\SerInf.dat";
				string StrIp=getSerInf.ReadXmlNode(SerInfFile,"//root//server//ip");
				System.Diagnostics.Process.Start("http://"+StrIp+"/QQWebSite/Default.aspx");
			}
		}

		private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			MessageBox.Show("功能未开放！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
		}
	}
}
