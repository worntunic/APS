namespace Beeffudge.Forms {
    partial class GameScreen {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && ( components != null )) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.txtChat = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtChatSend = new System.Windows.Forms.TextBox();
            this.btnChatSend = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnEnterAnswer = new System.Windows.Forms.Button();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnAnswer1 = new System.Windows.Forms.Button();
            this.btnAnswer2 = new System.Windows.Forms.Button();
            this.btnAnswer3 = new System.Windows.Forms.Button();
            this.btnAnswer4 = new System.Windows.Forms.Button();
            this.btnAnswer5 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtChat
            // 
            this.txtChat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChat.Location = new System.Drawing.Point(18, 15);
            this.txtChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(232, 627);
            this.txtChat.TabIndex = 1;
            this.txtChat.TextChanged += new System.EventHandler(this.txtChat_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtChatSend);
            this.panel1.Controls.Add(this.btnChatSend);
            this.panel1.Controls.Add(this.txtChat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 700);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(273, 722);
            this.panel1.TabIndex = 2;
            // 
            // txtChatSend
            // 
            this.txtChatSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtChatSend.Location = new System.Drawing.Point(18, 648);
            this.txtChatSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChatSend.Name = "txtChatSend";
            this.txtChatSend.Size = new System.Drawing.Size(232, 22);
            this.txtChatSend.TabIndex = 3;
            // 
            // btnChatSend
            // 
            this.btnChatSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChatSend.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChatSend.Location = new System.Drawing.Point(150, 678);
            this.btnChatSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChatSend.Name = "btnChatSend";
            this.btnChatSend.Size = new System.Drawing.Size(100, 28);
            this.btnChatSend.TabIndex = 2;
            this.btnChatSend.Text = "Send";
            this.btnChatSend.UseVisualStyleBackColor = true;
            this.btnChatSend.Click += new System.EventHandler(this.btnChatSend_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnEnterAnswer);
            this.panel2.Controls.Add(this.txtAnswer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(273, 660);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1099, 62);
            this.panel2.TabIndex = 3;
            // 
            // btnEnterAnswer
            // 
            this.btnEnterAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnterAnswer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEnterAnswer.Location = new System.Drawing.Point(947, 15);
            this.btnEnterAnswer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEnterAnswer.Name = "btnEnterAnswer";
            this.btnEnterAnswer.Size = new System.Drawing.Size(131, 28);
            this.btnEnterAnswer.TabIndex = 4;
            this.btnEnterAnswer.Text = "Send Answer";
            this.btnEnterAnswer.UseVisualStyleBackColor = true;
            this.btnEnterAnswer.Click += new System.EventHandler(this.btnEnterAnswer_Click_1);
            // 
            // txtAnswer
            // 
            this.txtAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnswer.Location = new System.Drawing.Point(21, 18);
            this.txtAnswer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(918, 22);
            this.txtAnswer.TabIndex = 3;
            // 
            // lblQuestion
            // 
            this.lblQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(4, 0);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(1049, 144);
            this.lblQuestion.TabIndex = 5;
            this.lblQuestion.Text = "Pitanje pitanje pitanje";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAnswer1
            // 
            this.btnAnswer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnswer1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnswer1.Location = new System.Drawing.Point(215, 99);
            this.btnAnswer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnswer1.MinimumSize = new System.Drawing.Size(205, 79);
            this.btnAnswer1.Name = "btnAnswer1";
            this.btnAnswer1.Size = new System.Drawing.Size(205, 87);
            this.btnAnswer1.TabIndex = 6;
            this.btnAnswer1.Text = "answer1";
            this.btnAnswer1.UseVisualStyleBackColor = true;
            this.btnAnswer1.Visible = false;
            this.btnAnswer1.Click += new System.EventHandler(this.btnAnswer1_Click);
            // 
            // btnAnswer2
            // 
            this.btnAnswer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnswer2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnswer2.Location = new System.Drawing.Point(637, 99);
            this.btnAnswer2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnswer2.MinimumSize = new System.Drawing.Size(205, 79);
            this.btnAnswer2.Name = "btnAnswer2";
            this.btnAnswer2.Size = new System.Drawing.Size(205, 87);
            this.btnAnswer2.TabIndex = 7;
            this.btnAnswer2.Text = "answer2";
            this.btnAnswer2.UseVisualStyleBackColor = true;
            this.btnAnswer2.Visible = false;
            this.btnAnswer2.Click += new System.EventHandler(this.btnAnswer2_Click);
            // 
            // btnAnswer3
            // 
            this.btnAnswer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnswer3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnswer3.Location = new System.Drawing.Point(426, 194);
            this.btnAnswer3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnswer3.MinimumSize = new System.Drawing.Size(205, 79);
            this.btnAnswer3.Name = "btnAnswer3";
            this.btnAnswer3.Size = new System.Drawing.Size(205, 87);
            this.btnAnswer3.TabIndex = 8;
            this.btnAnswer3.Text = "answer3";
            this.btnAnswer3.UseVisualStyleBackColor = true;
            this.btnAnswer3.Visible = false;
            this.btnAnswer3.Click += new System.EventHandler(this.btnAnswer3_Click);
            // 
            // btnAnswer4
            // 
            this.btnAnswer4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnswer4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnswer4.Location = new System.Drawing.Point(215, 289);
            this.btnAnswer4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnswer4.MinimumSize = new System.Drawing.Size(205, 79);
            this.btnAnswer4.Name = "btnAnswer4";
            this.btnAnswer4.Size = new System.Drawing.Size(205, 87);
            this.btnAnswer4.TabIndex = 9;
            this.btnAnswer4.Text = "answer4";
            this.btnAnswer4.UseVisualStyleBackColor = true;
            this.btnAnswer4.Visible = false;
            this.btnAnswer4.Click += new System.EventHandler(this.btnAnswer4_Click);
            // 
            // btnAnswer5
            // 
            this.btnAnswer5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnswer5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnswer5.Location = new System.Drawing.Point(637, 289);
            this.btnAnswer5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnswer5.MinimumSize = new System.Drawing.Size(205, 79);
            this.btnAnswer5.Name = "btnAnswer5";
            this.btnAnswer5.Size = new System.Drawing.Size(205, 87);
            this.btnAnswer5.TabIndex = 10;
            this.btnAnswer5.Text = "answer5";
            this.btnAnswer5.UseVisualStyleBackColor = true;
            this.btnAnswer5.Visible = false;
            this.btnAnswer5.Click += new System.EventHandler(this.btnAnswer5_Click);
            // 
            // panel3
            // 
            this.panel3.AutoSize = true;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tableLayoutPanel2);
            this.panel3.Controls.Add(this.tableLayoutPanel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1372, 722);
            this.panel3.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btnAnswer2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAnswer1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAnswer4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAnswer5, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAnswer3, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(294, 165);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1057, 477);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblQuestion, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(294, 15);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1057, 144);
            this.tableLayoutPanel2.TabIndex = 12;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1372, 722);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GameScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lobby";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtChatSend;
        private System.Windows.Forms.Button btnChatSend;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Button btnEnterAnswer;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnAnswer1;
        private System.Windows.Forms.Button btnAnswer2;
        private System.Windows.Forms.Button btnAnswer3;
        private System.Windows.Forms.Button btnAnswer4;
        private System.Windows.Forms.Button btnAnswer5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

