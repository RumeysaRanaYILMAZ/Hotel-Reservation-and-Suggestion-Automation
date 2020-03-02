namespace WindowsFormsApp4
{
	partial class Form11
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listView1 = new System.Windows.Forms.ListView();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.panel3.Controls.Add(this.panel2);
			this.panel3.Controls.Add(this.label2);
			this.panel3.Controls.Add(this.label1);
			this.panel3.Location = new System.Drawing.Point(2, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1090, 92);
			this.panel3.TabIndex = 10;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.Black;
			this.panel2.ImeMode = System.Windows.Forms.ImeMode.On;
			this.panel2.Location = new System.Drawing.Point(0, 53);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1106, 39);
			this.panel2.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.label2.Location = new System.Drawing.Point(105, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(125, 31);
			this.label2.TabIndex = 1;
			this.label2.Text = "RAKEAH";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(89, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(0, 17);
			this.label1.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.textBox1.Font = new System.Drawing.Font("Sitka Small", 15.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.textBox1.ForeColor = System.Drawing.SystemColors.WindowFrame;
			this.textBox1.Location = new System.Drawing.Point(38, 25);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(674, 39);
			this.textBox1.TabIndex = 13;
			this.textBox1.Text = "Otel,konum veya tema giriniz...\r\n";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.LimeGreen;
			this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.button1.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.button1.Font = new System.Drawing.Font("Sitka Small", 5.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.button1.Location = new System.Drawing.Point(718, 25);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 42);
			this.button1.TabIndex = 14;
			this.button1.Text = "ARA";
			this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.panel1.Controls.Add(this.textBox1);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Location = new System.Drawing.Point(236, 98);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(845, 92);
			this.panel1.TabIndex = 15;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.panel4.Location = new System.Drawing.Point(12, 98);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(218, 581);
			this.panel4.TabIndex = 17;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Otel Adı";
			this.columnHeader1.Width = 276;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Yakın Turistik Yer";
			this.columnHeader2.Width = 180;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Bilgiler";
			this.columnHeader3.Width = 384;
			// 
			// listView1
			// 
			this.listView1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.listView1.Location = new System.Drawing.Point(236, 196);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(845, 483);
			this.listView1.TabIndex = 16;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// Form11
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1093, 691);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel3);
			this.Name = "Form11";
			this.Text = "Form11";
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ListView listView1;
	}
}