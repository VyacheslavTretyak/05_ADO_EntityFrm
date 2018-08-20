namespace SearchingByAuthor
{
	partial class SearchingByAuthor
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
			this.tbFind = new System.Windows.Forms.TextBox();
			this.btFind = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// tbFind
			// 
			this.tbFind.Location = new System.Drawing.Point(13, 13);
			this.tbFind.Name = "tbFind";
			this.tbFind.Size = new System.Drawing.Size(601, 20);
			this.tbFind.TabIndex = 0;
			// 
			// btFind
			// 
			this.btFind.Location = new System.Drawing.Point(620, 11);
			this.btFind.Name = "btFind";
			this.btFind.Size = new System.Drawing.Size(75, 23);
			this.btFind.TabIndex = 1;
			this.btFind.Text = "Find";
			this.btFind.UseVisualStyleBackColor = true;
			this.btFind.Click += new System.EventHandler(this.btFind_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(13, 40);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(682, 398);
			this.dataGridView1.TabIndex = 2;
			// 
			// SearchingByAuthor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(707, 450);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.btFind);
			this.Controls.Add(this.tbFind);
			this.Name = "SearchingByAuthor";
			this.Text = "SearchingByAuthor";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tbFind;
		private System.Windows.Forms.Button btFind;
		private System.Windows.Forms.DataGridView dataGridView1;
	}
}

