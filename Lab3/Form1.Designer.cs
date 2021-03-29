namespace Lab3
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
            this.buttonPannel = new System.Windows.Forms.Panel();
            this.paintedButton = new System.Windows.Forms.Button();
            this.besierButton = new System.Windows.Forms.Button();
            this.brokenLineButton = new System.Windows.Forms.Button();
            this.curveButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.movementButton = new System.Windows.Forms.Button();
            this.propertiesButton = new System.Windows.Forms.Button();
            this.pointsButton = new System.Windows.Forms.Button();
            this.buttonPannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPannel
            // 
            this.buttonPannel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.buttonPannel.Controls.Add(this.paintedButton);
            this.buttonPannel.Controls.Add(this.besierButton);
            this.buttonPannel.Controls.Add(this.brokenLineButton);
            this.buttonPannel.Controls.Add(this.curveButton);
            this.buttonPannel.Controls.Add(this.clearButton);
            this.buttonPannel.Controls.Add(this.movementButton);
            this.buttonPannel.Controls.Add(this.propertiesButton);
            this.buttonPannel.Controls.Add(this.pointsButton);
            this.buttonPannel.Location = new System.Drawing.Point(9, 9);
            this.buttonPannel.Name = "buttonPannel";
            this.buttonPannel.Size = new System.Drawing.Size(190, 396);
            this.buttonPannel.TabIndex = 0;
            // 
            // paintedButton
            // 
            this.paintedButton.Location = new System.Drawing.Point(14, 319);
            this.paintedButton.Name = "paintedButton";
            this.paintedButton.Size = new System.Drawing.Size(159, 35);
            this.paintedButton.TabIndex = 7;
            this.paintedButton.Text = "Painted";
            this.paintedButton.UseVisualStyleBackColor = true;
            this.paintedButton.Click += new System.EventHandler(this.PaintedButton_Click_1);
            // 
            // besierButton
            // 
            this.besierButton.Location = new System.Drawing.Point(14, 278);
            this.besierButton.Name = "besierButton";
            this.besierButton.Size = new System.Drawing.Size(159, 35);
            this.besierButton.TabIndex = 6;
            this.besierButton.Text = "Besier";
            this.besierButton.UseVisualStyleBackColor = true;
            this.besierButton.Click += new System.EventHandler(this.BesierButton_Click_1);
            // 
            // brokenLineButton
            // 
            this.brokenLineButton.Location = new System.Drawing.Point(14, 237);
            this.brokenLineButton.Name = "brokenLineButton";
            this.brokenLineButton.Size = new System.Drawing.Size(159, 35);
            this.brokenLineButton.TabIndex = 5;
            this.brokenLineButton.Text = "Broken line";
            this.brokenLineButton.UseVisualStyleBackColor = true;
            this.brokenLineButton.Click += new System.EventHandler(this.button6_Click);
            // 
            // curveButton
            // 
            this.curveButton.Location = new System.Drawing.Point(14, 196);
            this.curveButton.Name = "curveButton";
            this.curveButton.Size = new System.Drawing.Size(159, 35);
            this.curveButton.TabIndex = 4;
            this.curveButton.Text = "Curve";
            this.curveButton.UseVisualStyleBackColor = true;
            this.curveButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(14, 155);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(159, 35);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear All";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // movementButton
            // 
            this.movementButton.Location = new System.Drawing.Point(14, 114);
            this.movementButton.Name = "movementButton";
            this.movementButton.Size = new System.Drawing.Size(159, 35);
            this.movementButton.TabIndex = 2;
            this.movementButton.Text = "Movement";
            this.movementButton.UseVisualStyleBackColor = true;
            this.movementButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // propertiesButton
            // 
            this.propertiesButton.Location = new System.Drawing.Point(14, 73);
            this.propertiesButton.Name = "propertiesButton";
            this.propertiesButton.Size = new System.Drawing.Size(159, 35);
            this.propertiesButton.TabIndex = 1;
            this.propertiesButton.Text = "Properties";
            this.propertiesButton.UseVisualStyleBackColor = true;
            this.propertiesButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // pointsButton
            // 
            this.pointsButton.Location = new System.Drawing.Point(14, 30);
            this.pointsButton.Name = "pointsButton";
            this.pointsButton.Size = new System.Drawing.Size(159, 35);
            this.pointsButton.TabIndex = 0;
            this.pointsButton.Text = "Points";
            this.pointsButton.UseVisualStyleBackColor = true;
            this.pointsButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(642, 411);
            this.Controls.Add(this.buttonPannel);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MaximumSize = new System.Drawing.Size(1020, 760);
            this.MinimumSize = new System.Drawing.Size(450, 450);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Flying Points";
            this.buttonPannel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPannel;
        private System.Windows.Forms.Button paintedButton;
        private System.Windows.Forms.Button besierButton;
        private System.Windows.Forms.Button brokenLineButton;
        private System.Windows.Forms.Button curveButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button movementButton;
        private System.Windows.Forms.Button propertiesButton;
        private System.Windows.Forms.Button pointsButton;
    }
}

