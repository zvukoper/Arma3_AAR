namespace DZR_Arma3_ExtEmu
{
    partial class Form1
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
            this.ScriptInput = new System.Windows.Forms.TextBox();
            this.SEND = new System.Windows.Forms.Button();
            this.Response = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // ScriptInput
            // 
            this.ScriptInput.Location = new System.Drawing.Point(31, 22);
            this.ScriptInput.Multiline = true;
            this.ScriptInput.Name = "ScriptInput";
            this.ScriptInput.Size = new System.Drawing.Size(729, 242);
            this.ScriptInput.TabIndex = 0;
            // 
            // SEND
            // 
            this.SEND.Location = new System.Drawing.Point(685, 270);
            this.SEND.Name = "SEND";
            this.SEND.Size = new System.Drawing.Size(75, 23);
            this.SEND.TabIndex = 1;
            this.SEND.Text = "button1";
            this.SEND.UseVisualStyleBackColor = true;
            // 
            // Response
            // 
            this.Response.FormattingEnabled = true;
            this.Response.Location = new System.Drawing.Point(31, 324);
            this.Response.Name = "Response";
            this.Response.Size = new System.Drawing.Size(729, 147);
            this.Response.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 527);
            this.Controls.Add(this.Response);
            this.Controls.Add(this.SEND);
            this.Controls.Add(this.ScriptInput);
            this.Name = "Form1";
            this.Text = "DZR Arma3 Extension Emulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ScriptInput;
        private System.Windows.Forms.Button SEND;
        private System.Windows.Forms.ListBox Response;
    }
}

