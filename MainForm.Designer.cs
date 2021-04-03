/*
 * Created by SharpDevelop.
 * User: Костя
 * Date: 03.02.2016
 * Time: 17:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace FanController
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label labelTextGPU;
		private System.Windows.Forms.Label labelTextMode;
		private System.Windows.Forms.Label labelTempGPU;
		private System.Windows.Forms.Label labelMode;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label labelTextCPU;
		private System.Windows.Forms.Label labelTempCPU;
		private System.Windows.Forms.TextBox textStartTemp;
		private System.Windows.Forms.Label labelTextTempOn;
		private System.Windows.Forms.Label labelStartTemp;
		private System.Windows.Forms.Button buttonSaveStartTemp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox AutorunCheckBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label labelNotebook;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.RadioButton radioCPU;
		private System.Windows.Forms.RadioButton radioGPU;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textTime;
		private System.Windows.Forms.Button buttonSaveTimer;
		private System.Windows.Forms.Label labelTime;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.labelTextGPU = new System.Windows.Forms.Label();
			this.labelTextMode = new System.Windows.Forms.Label();
			this.labelTempGPU = new System.Windows.Forms.Label();
			this.labelMode = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.labelTextCPU = new System.Windows.Forms.Label();
			this.labelTempCPU = new System.Windows.Forms.Label();
			this.textStartTemp = new System.Windows.Forms.TextBox();
			this.labelTextTempOn = new System.Windows.Forms.Label();
			this.labelStartTemp = new System.Windows.Forms.Label();
			this.buttonSaveStartTemp = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.AutorunCheckBox = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.labelNotebook = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.radioCPU = new System.Windows.Forms.RadioButton();
			this.radioGPU = new System.Windows.Forms.RadioButton();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label9 = new System.Windows.Forms.Label();
			this.textTime = new System.Windows.Forms.TextBox();
			this.buttonSaveTimer = new System.Windows.Forms.Button();
			this.labelTime = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelTextGPU
			// 
			this.labelTextGPU.Location = new System.Drawing.Point(12, 13);
			this.labelTextGPU.Name = "labelTextGPU";
			this.labelTextGPU.Size = new System.Drawing.Size(111, 18);
			this.labelTextGPU.TabIndex = 4;
			this.labelTextGPU.Text = "Температура GPU:";
			this.labelTextGPU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTextMode
			// 
			this.labelTextMode.Location = new System.Drawing.Point(12, 49);
			this.labelTextMode.Name = "labelTextMode";
			this.labelTextMode.Size = new System.Drawing.Size(111, 18);
			this.labelTextMode.TabIndex = 5;
			this.labelTextMode.Text = "Режим работы:";
			this.labelTextMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTempGPU
			// 
			this.labelTempGPU.Location = new System.Drawing.Point(273, 13);
			this.labelTempGPU.Name = "labelTempGPU";
			this.labelTempGPU.Size = new System.Drawing.Size(37, 18);
			this.labelTempGPU.TabIndex = 6;
			this.labelTempGPU.Text = "N / A";
			this.labelTempGPU.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// labelMode
			// 
			this.labelMode.Location = new System.Drawing.Point(204, 49);
			this.labelMode.Name = "labelMode";
			this.labelMode.Size = new System.Drawing.Size(106, 18);
			this.labelMode.TabIndex = 7;
			this.labelMode.Text = "Обычный";
			this.labelMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(195, 244);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(124, 15);
			this.label5.TabIndex = 8;
			this.label5.Text = "nestle.csf@gmail.com";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon1.BalloonTipText = "Программа свёрнута в трей";
			this.notifyIcon1.BalloonTipTitle = "Информация";
			this.notifyIcon1.Text = "Acer Aspire 5750G Fan Controller by Nestle_";
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
			this.label6.Location = new System.Drawing.Point(24, 85);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(274, 45);
			this.label6.TabIndex = 9;
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(12, 67);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(246, 18);
			this.label7.TabIndex = 10;
			this.label7.Text = "Ноутбук:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTextCPU
			// 
			this.labelTextCPU.Location = new System.Drawing.Point(12, 31);
			this.labelTextCPU.Name = "labelTextCPU";
			this.labelTextCPU.Size = new System.Drawing.Size(111, 18);
			this.labelTextCPU.TabIndex = 11;
			this.labelTextCPU.Text = "Температура CPU";
			this.labelTextCPU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelTempCPU
			// 
			this.labelTempCPU.Location = new System.Drawing.Point(273, 31);
			this.labelTempCPU.Name = "labelTempCPU";
			this.labelTempCPU.Size = new System.Drawing.Size(37, 18);
			this.labelTempCPU.TabIndex = 12;
			this.labelTempCPU.Text = "N / A";
			this.labelTempCPU.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textStartTemp
			// 
			this.textStartTemp.BackColor = System.Drawing.SystemColors.Menu;
			this.textStartTemp.Location = new System.Drawing.Point(171, 169);
			this.textStartTemp.MaxLength = 2;
			this.textStartTemp.Name = "textStartTemp";
			this.textStartTemp.Size = new System.Drawing.Size(56, 20);
			this.textStartTemp.TabIndex = 13;
			this.textStartTemp.Text = "50";
			this.textStartTemp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textStartTemp.TextChanged += new System.EventHandler(this.textStartTemp_TextChange);
			this.textStartTemp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textStartTemp_KeyPress);
			// 
			// labelTextTempOn
			// 
			this.labelTextTempOn.Location = new System.Drawing.Point(12, 169);
			this.labelTextTempOn.Name = "labelTextTempOn";
			this.labelTextTempOn.Size = new System.Drawing.Size(123, 18);
			this.labelTextTempOn.TabIndex = 14;
			this.labelTextTempOn.Text = "Температура запуска";
			this.labelTextTempOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStartTemp
			// 
			this.labelStartTemp.BackColor = System.Drawing.Color.Transparent;
			this.labelStartTemp.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.labelStartTemp.Location = new System.Drawing.Point(130, 169);
			this.labelStartTemp.Name = "labelStartTemp";
			this.labelStartTemp.Size = new System.Drawing.Size(35, 18);
			this.labelStartTemp.TabIndex = 16;
			this.labelStartTemp.Text = "N/A";
			this.labelStartTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// buttonSaveStartTemp
			// 
			this.buttonSaveStartTemp.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.buttonSaveStartTemp.Location = new System.Drawing.Point(233, 168);
			this.buttonSaveStartTemp.Name = "buttonSaveStartTemp";
			this.buttonSaveStartTemp.Size = new System.Drawing.Size(77, 22);
			this.buttonSaveStartTemp.TabIndex = 17;
			this.buttonSaveStartTemp.Text = "Сохранить";
			this.buttonSaveStartTemp.UseVisualStyleBackColor = true;
			this.buttonSaveStartTemp.Click += new System.EventHandler(this.change_StartTemp);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 220);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(225, 18);
			this.label1.TabIndex = 18;
			this.label1.Text = "Принудительные макс. обороты кулера";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 202);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(131, 18);
			this.label2.TabIndex = 20;
			this.label2.Text = "Автозапуск с Windows";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// AutorunCheckBox
			// 
			this.AutorunCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.AutorunCheckBox.Location = new System.Drawing.Point(292, 202);
			this.AutorunCheckBox.Name = "AutorunCheckBox";
			this.AutorunCheckBox.Size = new System.Drawing.Size(16, 16);
			this.AutorunCheckBox.TabIndex = 21;
			this.AutorunCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.AutorunCheckBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.change_Autorun);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(114, 2);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 15);
			this.label3.TabIndex = 22;
			this.label3.Text = "Информация";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(292, 224);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(16, 16);
			this.checkBox1.TabIndex = 23;
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.change_KeyPress);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(114, 125);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 15);
			this.label4.TabIndex = 24;
			this.label4.Text = "Настройки";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// labelNotebook
			// 
			this.labelNotebook.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
			this.labelNotebook.ForeColor = System.Drawing.Color.Black;
			this.labelNotebook.Location = new System.Drawing.Point(204, 67);
			this.labelNotebook.Name = "labelNotebook";
			this.labelNotebook.Size = new System.Drawing.Size(106, 18);
			this.labelNotebook.TabIndex = 25;
			this.labelNotebook.Text = "N / A";
			this.labelNotebook.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label8
			// 
			this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label8.Location = new System.Drawing.Point(244, 2);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(42, 15);
			this.label8.TabIndex = 28;
			this.label8.Text = "Трей";
			this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// radioCPU
			// 
			this.radioCPU.Location = new System.Drawing.Point(259, 33);
			this.radioCPU.Name = "radioCPU";
			this.radioCPU.Size = new System.Drawing.Size(15, 15);
			this.radioCPU.TabIndex = 29;
			this.radioCPU.TabStop = true;
			this.radioCPU.UseVisualStyleBackColor = true;
			this.radioCPU.Click += new System.EventHandler(this.click_RadioCPU);
			// 
			// radioGPU
			// 
			this.radioGPU.Location = new System.Drawing.Point(259, 15);
			this.radioGPU.Name = "radioGPU";
			this.radioGPU.Size = new System.Drawing.Size(15, 15);
			this.radioGPU.TabIndex = 30;
			this.radioGPU.TabStop = true;
			this.radioGPU.UseVisualStyleBackColor = true;
			this.radioGPU.Click += new System.EventHandler(this.click_RadioGPU);
			// 
			// linkLabel1
			// 
			this.linkLabel1.AccessibleDescription = "";
			this.linkLabel1.AccessibleName = "";
			this.linkLabel1.Location = new System.Drawing.Point(12, 244);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(157, 13);
			this.linkLabel1.TabIndex = 31;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Fan Controller v1.5 by Nestle";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			this.linkLabel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.go_to_forum);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(12, 143);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(123, 18);
			this.label9.TabIndex = 32;
			this.label9.Text = "Время обновления";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textTime
			// 
			this.textTime.BackColor = System.Drawing.SystemColors.Menu;
			this.textTime.Location = new System.Drawing.Point(171, 143);
			this.textTime.MaxLength = 2;
			this.textTime.Name = "textTime";
			this.textTime.Size = new System.Drawing.Size(56, 20);
			this.textTime.TabIndex = 33;
			this.textTime.Text = "5";
			this.textTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// buttonSaveTimer
			// 
			this.buttonSaveTimer.FlatAppearance.BorderColor = System.Drawing.Color.White;
			this.buttonSaveTimer.Location = new System.Drawing.Point(233, 142);
			this.buttonSaveTimer.Name = "buttonSaveTimer";
			this.buttonSaveTimer.Size = new System.Drawing.Size(77, 22);
			this.buttonSaveTimer.TabIndex = 34;
			this.buttonSaveTimer.Text = "Сохранить";
			this.buttonSaveTimer.UseVisualStyleBackColor = true;
			this.buttonSaveTimer.Click += new System.EventHandler(this.change_Time);
			// 
			// labelTime
			// 
			this.labelTime.BackColor = System.Drawing.Color.Transparent;
			this.labelTime.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.labelTime.Location = new System.Drawing.Point(112, 143);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(51, 18);
			this.labelTime.TabIndex = 35;
			this.labelTime.Text = "N/A";
			this.labelTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// MainForm
			// 
			this.AccessibleName = "";
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(322, 266);
			this.Controls.Add(this.labelTime);
			this.Controls.Add(this.buttonSaveTimer);
			this.Controls.Add(this.textTime);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.radioGPU);
			this.Controls.Add(this.radioCPU);
			this.Controls.Add(this.labelNotebook);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.AutorunCheckBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonSaveStartTemp);
			this.Controls.Add(this.labelStartTemp);
			this.Controls.Add(this.labelTextTempOn);
			this.Controls.Add(this.textStartTemp);
			this.Controls.Add(this.labelTempCPU);
			this.Controls.Add(this.labelTextCPU);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.labelMode);
			this.Controls.Add(this.labelTempGPU);
			this.Controls.Add(this.labelTextMode);
			this.Controls.Add(this.labelTextGPU);
			this.Controls.Add(this.label8);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Fan Controller by Nestle_";
			this.Deactivate += new System.EventHandler(this.Form1_Resize);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		}
}
