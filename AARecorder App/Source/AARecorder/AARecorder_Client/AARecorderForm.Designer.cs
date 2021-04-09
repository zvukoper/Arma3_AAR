namespace AARecorder_Server
{
    partial class AARecorder
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConsoleOutput = new System.Windows.Forms.ListBox();
            this.Activate = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.button19 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConsoleOutput
            // 
            this.ConsoleOutput.FormattingEnabled = true;
            this.ConsoleOutput.Location = new System.Drawing.Point(0, 367);
            this.ConsoleOutput.Name = "ConsoleOutput";
            this.ConsoleOutput.Size = new System.Drawing.Size(776, 160);
            this.ConsoleOutput.TabIndex = 0;
            // 
            // Activate
            // 
            this.Activate.AutoSize = true;
            this.Activate.Location = new System.Drawing.Point(617, 22);
            this.Activate.Name = "Activate";
            this.Activate.Size = new System.Drawing.Size(65, 17);
            this.Activate.TabIndex = 1;
            this.Activate.Text = "Activate";
            this.Activate.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(295, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Replay filename";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(301, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Auto";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.label4);
            this.MainPanel.Controls.Add(this.label3);
            this.MainPanel.Controls.Add(this.button19);
            this.MainPanel.Controls.Add(this.button18);
            this.MainPanel.Controls.Add(this.button17);
            this.MainPanel.Controls.Add(this.button16);
            this.MainPanel.Controls.Add(this.button15);
            this.MainPanel.Controls.Add(this.button14);
            this.MainPanel.Controls.Add(this.button13);
            this.MainPanel.Controls.Add(this.button12);
            this.MainPanel.Controls.Add(this.button11);
            this.MainPanel.Controls.Add(this.button10);
            this.MainPanel.Controls.Add(this.button9);
            this.MainPanel.Controls.Add(this.button8);
            this.MainPanel.Controls.Add(this.button7);
            this.MainPanel.Controls.Add(this.button6);
            this.MainPanel.Controls.Add(this.button5);
            this.MainPanel.Controls.Add(this.button4);
            this.MainPanel.Controls.Add(this.button3);
            this.MainPanel.Controls.Add(this.button2);
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.textBox1);
            this.MainPanel.Controls.Add(this.checkBox1);
            this.MainPanel.Controls.Add(this.ConsoleOutput);
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Location = new System.Drawing.Point(12, 54);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(776, 527);
            this.MainPanel.TabIndex = 5;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(203, 68);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(191, 23);
            this.button19.TabIndex = 23;
            this.button19.Text = "Connect to Pipes";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(203, 274);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(191, 23);
            this.button18.TabIndex = 22;
            this.button18.Text = "Send EOF@aDat";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(6, 274);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(191, 23);
            this.button17.TabIndex = 21;
            this.button17.Text = "Wait for EOF@aDat";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(203, 332);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(191, 23);
            this.button16.TabIndex = 20;
            this.button16.Text = "Wait for AAR READY@dCom";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(203, 303);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(191, 23);
            this.button15.TabIndex = 19;
            this.button15.Text = "Read Filename@dCom";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(6, 303);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(191, 23);
            this.button14.TabIndex = 18;
            this.button14.Text = "Send Filename@dCom";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(203, 245);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(191, 23);
            this.button13.TabIndex = 17;
            this.button13.Text = "Send Data@aDat";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(203, 97);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(191, 23);
            this.button12.TabIndex = 16;
            this.button12.Text = "Send ARMA READY@aCom";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(6, 245);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(191, 23);
            this.button11.TabIndex = 15;
            this.button11.Text = "Read Data@aDat";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(203, 214);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(191, 23);
            this.button10.TabIndex = 14;
            this.button10.Text = "Wait for READY FOR DATA@dCom";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(6, 214);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(191, 23);
            this.button9.TabIndex = 13;
            this.button9.Text = "Send READY FOR DATA@dCom";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(6, 184);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(191, 23);
            this.button8.TabIndex = 12;
            this.button8.Text = "Received RECORD@aCom";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(203, 155);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(191, 23);
            this.button7.TabIndex = 11;
            this.button7.Text = "Send RECORD@aCom";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(6, 155);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(191, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "Wait for Command@aCom";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(203, 126);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(191, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Wait for AAR READY@ dCom";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 126);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(191, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Send AAR READY@dCom";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 97);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Wait for ARMA READY@aCom";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 68);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(191, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Launch all Pipes";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 351);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Activate";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "AARecorder App";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Arma + armalib.dll";
            // 
            // AARecorder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 593);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.Activate);
            this.Name = "AARecorder";
            this.Text = "AARecorder";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ConsoleOutput;
        private System.Windows.Forms.CheckBox Activate;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

