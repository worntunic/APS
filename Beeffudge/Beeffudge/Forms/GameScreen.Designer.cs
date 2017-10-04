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
            this.btnChatSend = new System.Windows.Forms.Button();
            this.txtChatSend = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.btnEnterAnswer = new System.Windows.Forms.Button();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnAnswer1 = new System.Windows.Forms.Button();
            this.btnAnswer2 = new System.Windows.Forms.Button();
            this.btnAnswer3 = new System.Windows.Forms.Button();
            this.btnAnswer4 = new System.Windows.Forms.Button();
            this.btnAnswer5 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtChat
            // 
            this.txtChat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChat.Location = new System.Drawing.Point(12, 12);
            this.txtChat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(160, 512);
            this.txtChat.TabIndex = 1;
            this.txtChat.TextChanged += new System.EventHandler(this.txtChat_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.txtChatSend);
            this.panel1.Controls.Add(this.btnChatSend);
            this.panel1.Controls.Add(this.txtChat);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.MinimumSize = new System.Drawing.Size(0, 1080);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 1080);
            this.panel1.TabIndex = 2;
            // 
            // btnChatSend
            // 
            this.btnChatSend.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChatSend.Location = new System.Drawing.Point(96, 555);
            this.btnChatSend.Name = "btnChatSend";
            this.btnChatSend.Size = new System.Drawing.Size(75, 23);
            this.btnChatSend.TabIndex = 2;
            this.btnChatSend.Text = "Send";
            this.btnChatSend.UseVisualStyleBackColor = true;
            this.btnChatSend.Click += new System.EventHandler(this.btnChatSend_Click);
            // 
            // txtChatSend
            // 
            this.txtChatSend.Location = new System.Drawing.Point(12, 529);
            this.txtChatSend.Name = "txtChatSend";
            this.txtChatSend.Size = new System.Drawing.Size(159, 20);
            this.txtChatSend.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnEnterAnswer);
            this.panel2.Controls.Add(this.txtAnswer);
            this.panel2.Location = new System.Drawing.Point(192, 529);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(829, 61);
            this.panel2.TabIndex = 3;
            // 
            // txtAnswer
            // 
            this.txtAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnswer.Location = new System.Drawing.Point(16, 16);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(688, 20);
            this.txtAnswer.TabIndex = 3;
            // 
            // btnEnterAnswer
            // 
            this.btnEnterAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnterAnswer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEnterAnswer.Location = new System.Drawing.Point(710, 14);
            this.btnEnterAnswer.Name = "btnEnterAnswer";
            this.btnEnterAnswer.Size = new System.Drawing.Size(99, 23);
            this.btnEnterAnswer.TabIndex = 4;
            this.btnEnterAnswer.Text = "Send Answer";
            this.btnEnterAnswer.UseVisualStyleBackColor = true;
            this.btnEnterAnswer.Click += new System.EventHandler(this.btnEnterAnswer_Click_1);
            // 
            // lblQuestion
            // 
            this.lblQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(218, 50);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(347, 41);
            this.lblQuestion.TabIndex = 5;
            this.lblQuestion.Text = "Pitanje pitanje pitanje";
            // 
            // btnAnswer1
            // 
            this.btnAnswer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnswer1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnswer1.Location = new System.Drawing.Point(102, 164);
            this.btnAnswer1.MaximumSize = new System.Drawing.Size(154, 64);
            this.btnAnswer1.MinimumSize = new System.Drawing.Size(154, 64);
            this.btnAnswer1.Name = "btnAnswer1";
            this.btnAnswer1.Size = new System.Drawing.Size(154, 64);
            this.btnAnswer1.TabIndex = 6;
            this.btnAnswer1.Text = "answer1";
            this.btnAnswer1.UseVisualStyleBackColor = true;
            this.btnAnswer1.Visible = false;
            this.btnAnswer1.Click += new System.EventHandler(this.btnAnswer1_Click);
            // 
            // btnAnswer2
            // 
            this.btnAnswer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnswer2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnswer2.Location = new System.Drawing.Point(520, 164);
            this.btnAnswer2.MaximumSize = new System.Drawing.Size(154, 64);
            this.btnAnswer2.MinimumSize = new System.Drawing.Size(154, 64);
            this.btnAnswer2.Name = "btnAnswer2";
            this.btnAnswer2.Size = new System.Drawing.Size(154, 64);
            this.btnAnswer2.TabIndex = 7;
            this.btnAnswer2.Text = "answer2";
            this.btnAnswer2.UseVisualStyleBackColor = true;
            this.btnAnswer2.Visible = false;
            this.btnAnswer2.Click += new System.EventHandler(this.btnAnswer2_Click);
            // 
            // btnAnswer3
            // 
            this.btnAnswer3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnswer3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnswer3.Location = new System.Drawing.Point(315, 265);
            this.btnAnswer3.MaximumSize = new System.Drawing.Size(154, 64);
            this.btnAnswer3.MinimumSize = new System.Drawing.Size(154, 64);
            this.btnAnswer3.Name = "btnAnswer3";
            this.btnAnswer3.Size = new System.Drawing.Size(154, 64);
            this.btnAnswer3.TabIndex = 8;
            this.btnAnswer3.Text = "answer3";
            this.btnAnswer3.UseVisualStyleBackColor = true;
            this.btnAnswer3.Visible = false;
            this.btnAnswer3.Click += new System.EventHandler(this.btnAnswer3_Click);
            // 
            // btnAnswer4
            // 
            this.btnAnswer4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnswer4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnswer4.Location = new System.Drawing.Point(102, 360);
            this.btnAnswer4.MaximumSize = new System.Drawing.Size(154, 64);
            this.btnAnswer4.MinimumSize = new System.Drawing.Size(154, 64);
            this.btnAnswer4.Name = "btnAnswer4";
            this.btnAnswer4.Size = new System.Drawing.Size(154, 64);
            this.btnAnswer4.TabIndex = 9;
            this.btnAnswer4.Text = "answer4";
            this.btnAnswer4.UseVisualStyleBackColor = true;
            this.btnAnswer4.Visible = false;
            this.btnAnswer4.Click += new System.EventHandler(this.btnAnswer4_Click);
            // 
            // btnAnswer5
            // 
            this.btnAnswer5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnswer5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAnswer5.Location = new System.Drawing.Point(520, 360);
            this.btnAnswer5.MaximumSize = new System.Drawing.Size(154, 64);
            this.btnAnswer5.MinimumSize = new System.Drawing.Size(154, 64);
            this.btnAnswer5.Name = "btnAnswer5";
            this.btnAnswer5.Size = new System.Drawing.Size(154, 64);
            this.btnAnswer5.TabIndex = 10;
            this.btnAnswer5.Text = "answer5";
            this.btnAnswer5.UseVisualStyleBackColor = true;
            this.btnAnswer5.Visible = false;
            this.btnAnswer5.Click += new System.EventHandler(this.btnAnswer5_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.lblQuestion);
            this.panel3.Controls.Add(this.btnAnswer3);
            this.panel3.Controls.Add(this.btnAnswer1);
            this.panel3.Controls.Add(this.btnAnswer4);
            this.panel3.Controls.Add(this.btnAnswer2);
            this.panel3.Controls.Add(this.btnAnswer5);
            this.panel3.Location = new System.Drawing.Point(192, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(826, 500);
            this.panel3.TabIndex = 11;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1090, 589);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.panel3.PerformLayout();
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
    }
}

