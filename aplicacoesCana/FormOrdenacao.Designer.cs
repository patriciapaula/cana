namespace aplicacoesCana
{
    partial class FormOrdenacao
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
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(46, 148);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(136, 30);
            this.button12.TabIndex = 24;
            this.button12.Text = "Counting sort";
            this.button12.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(46, 94);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(136, 30);
            this.button11.TabIndex = 23;
            this.button11.Text = "Heapsort";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(46, 41);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(136, 30);
            this.button10.TabIndex = 22;
            this.button10.Text = "Insertionsort";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(214, 41);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(136, 30);
            this.button9.TabIndex = 21;
            this.button9.Text = "Mergesort";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(214, 94);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(136, 30);
            this.button4.TabIndex = 20;
            this.button4.Text = "Quicksort";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // FormOrdenacao
            // 
            this.ClientSize = new System.Drawing.Size(388, 222);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Name = "FormOrdenacao";
            this.Text = "Divisão e Conquista - Ordenação";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button4;
    }
}
