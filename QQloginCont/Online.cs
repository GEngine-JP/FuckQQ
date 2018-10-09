using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace QQ
{
	/// <summary>
	/// Online 的摘要说明。
	/// </summary>
	public class Online : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Timer timer1;
		private string SysInf;
		private System.ComponentModel.IContainer components;

		public Online(string sysinf)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			this.SysInf=sysinf;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Online));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(288, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "系统消息：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(0, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(288, 72);
			this.label2.TabIndex = 1;
			this.label2.Text = "用户上线";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Online
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(288, 136);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Online";
			this.ShowInTaskbar = false;
			this.Text = "Online";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.Online_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void label2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void Online_Load(object sender, System.EventArgs e)
		{
			int screenX=System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
			int screenY=System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
			int WindX=screenX-288;
			int WindY=screenY-135;
			this.Location=new System.Drawing.Point(WindX,WindY);
			this.label2.Text=SysInf;
			this.Opacity=0;
			this.timer1.Start();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if(this.Opacity==1)
			{
				this.timer1.Stop();
			}
			else
			{
				this.Opacity=this.Opacity+0.1;
			}
		}
	}
}
