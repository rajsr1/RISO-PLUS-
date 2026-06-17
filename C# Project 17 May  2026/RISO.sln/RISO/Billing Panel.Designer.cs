namespace RISO
{
    partial class Billing_Panel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPatNam = new System.Windows.Forms.TextBox();
            this.txtDocFee = new System.Windows.Forms.TextBox();
            this.txtPatId = new System.Windows.Forms.TextBox();
            this.txtRoCh = new System.Windows.Forms.TextBox();
            this.txtTeCo = new System.Windows.Forms.TextBox();
            this.ComBOxBill = new System.Windows.Forms.ComboBox();
            this.btnTotalBill = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SeaShell;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(122, 136);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pateint name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SeaShell;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(122, 184);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Patient Id";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SeaShell;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(122, 252);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 32);
            this.label3.TabIndex = 10;
            this.label3.Text = "Doctor Fee";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.SeaShell;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(122, 302);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 32);
            this.label5.TabIndex = 11;
            this.label5.Text = "Test Cost";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.SeaShell;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(122, 358);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 32);
            this.label6.TabIndex = 12;
            this.label6.Text = "Room Charge";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(680, 136);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(502, 281);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SeaShell;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(122, 411);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 32);
            this.label4.TabIndex = 14;
            this.label4.Text = "Bill Status";
            // 
            // txtPatNam
            // 
            this.txtPatNam.Location = new System.Drawing.Point(352, 148);
            this.txtPatNam.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPatNam.Name = "txtPatNam";
            this.txtPatNam.Size = new System.Drawing.Size(235, 31);
            this.txtPatNam.TabIndex = 15;
            // 
            // txtDocFee
            // 
            this.txtDocFee.Location = new System.Drawing.Point(352, 242);
            this.txtDocFee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDocFee.Name = "txtDocFee";
            this.txtDocFee.Size = new System.Drawing.Size(235, 31);
            this.txtDocFee.TabIndex = 16;
            // 
            // txtPatId
            // 
            this.txtPatId.Location = new System.Drawing.Point(352, 192);
            this.txtPatId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPatId.Name = "txtPatId";
            this.txtPatId.Size = new System.Drawing.Size(235, 31);
            this.txtPatId.TabIndex = 17;
            // 
            // txtRoCh
            // 
            this.txtRoCh.Location = new System.Drawing.Point(352, 358);
            this.txtRoCh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRoCh.Name = "txtRoCh";
            this.txtRoCh.Size = new System.Drawing.Size(235, 31);
            this.txtRoCh.TabIndex = 18;
            // 
            // txtTeCo
            // 
            this.txtTeCo.Location = new System.Drawing.Point(352, 286);
            this.txtTeCo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTeCo.Name = "txtTeCo";
            this.txtTeCo.Size = new System.Drawing.Size(235, 31);
            this.txtTeCo.TabIndex = 20;
            // 
            // ComBOxBill
            // 
            this.ComBOxBill.FormattingEnabled = true;
            this.ComBOxBill.Location = new System.Drawing.Point(352, 411);
            this.ComBOxBill.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ComBOxBill.Name = "ComBOxBill";
            this.ComBOxBill.Size = new System.Drawing.Size(180, 33);
            this.ComBOxBill.TabIndex = 21;
            // 
            // btnTotalBill
            // 
            this.btnTotalBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTotalBill.ForeColor = System.Drawing.Color.Red;
            this.btnTotalBill.Location = new System.Drawing.Point(766, 489);
            this.btnTotalBill.Margin = new System.Windows.Forms.Padding(6);
            this.btnTotalBill.Name = "btnTotalBill";
            this.btnTotalBill.Size = new System.Drawing.Size(294, 114);
            this.btnTotalBill.TabIndex = 26;
            this.btnTotalBill.Text = "Total Bill";
            this.btnTotalBill.UseVisualStyleBackColor = true;
            this.btnTotalBill.Click += new System.EventHandler(this.btnTotalBill_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.Red;
            this.btnBack.Location = new System.Drawing.Point(255, 489);
            this.btnBack.Margin = new System.Windows.Forms.Padding(6);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(294, 114);
            this.btnBack.TabIndex = 30;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Billing_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(1320, 759);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnTotalBill);
            this.Controls.Add(this.ComBOxBill);
            this.Controls.Add(this.txtTeCo);
            this.Controls.Add(this.txtRoCh);
            this.Controls.Add(this.txtPatId);
            this.Controls.Add(this.txtDocFee);
            this.Controls.Add(this.txtPatNam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Red;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Billing_Panel";
            this.Text = "Billing_Panel";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPatNam;
        private System.Windows.Forms.TextBox txtDocFee;
        private System.Windows.Forms.TextBox txtPatId;
        private System.Windows.Forms.TextBox txtRoCh;
        private System.Windows.Forms.TextBox txtTeCo;
        private System.Windows.Forms.ComboBox ComBOxBill;
        private System.Windows.Forms.Button btnTotalBill;
        private System.Windows.Forms.Button btnBack;
    }
}