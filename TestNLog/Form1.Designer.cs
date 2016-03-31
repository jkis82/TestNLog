namespace TestNLog
{
   partial class Form1
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
         this.btnStart = new System.Windows.Forms.Button();
         this.btnBurst = new System.Windows.Forms.Button();
         this.btnStop = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // btnStart
         // 
         this.btnStart.Location = new System.Drawing.Point(93, 38);
         this.btnStart.Name = "btnStart";
         this.btnStart.Size = new System.Drawing.Size(142, 23);
         this.btnStart.TabIndex = 0;
         this.btnStart.Text = "Start";
         this.btnStart.UseVisualStyleBackColor = true;
         this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
         // 
         // btnBurst
         // 
         this.btnBurst.Location = new System.Drawing.Point(93, 67);
         this.btnBurst.Name = "btnBurst";
         this.btnBurst.Size = new System.Drawing.Size(142, 23);
         this.btnBurst.TabIndex = 0;
         this.btnBurst.Text = "Burst";
         this.btnBurst.UseVisualStyleBackColor = true;
         this.btnBurst.Click += new System.EventHandler(this.btnBurst_Click);
         // 
         // btnStop
         // 
         this.btnStop.Location = new System.Drawing.Point(93, 96);
         this.btnStop.Name = "btnStop";
         this.btnStop.Size = new System.Drawing.Size(142, 23);
         this.btnStop.TabIndex = 0;
         this.btnStop.Text = "Stop";
         this.btnStop.UseVisualStyleBackColor = true;
         this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
         // 
         // Form1
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(558, 199);
         this.Controls.Add(this.btnStop);
         this.Controls.Add(this.btnBurst);
         this.Controls.Add(this.btnStart);
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button btnStart;
      private System.Windows.Forms.Button btnBurst;
      private System.Windows.Forms.Button btnStop;
   }
}

