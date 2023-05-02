namespace KeyboardTrainer
{
    partial class FormModeSelection
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
            labelText1 = new Label();
            labelText2 = new Label();
            buttonFirstMode = new Button();
            buttonSecondMode = new Button();
            SuspendLayout();
            // 
            // labelText1
            // 
            labelText1.AutoSize = true;
            labelText1.Location = new Point(328, 73);
            labelText1.Name = "labelText1";
            labelText1.Size = new Size(54, 15);
            labelText1.TabIndex = 0;
            labelText1.Text = "Режим 1";
            // 
            // labelText2
            // 
            labelText2.AutoSize = true;
            labelText2.Location = new Point(328, 212);
            labelText2.Name = "labelText2";
            labelText2.Size = new Size(54, 15);
            labelText2.TabIndex = 1;
            labelText2.Text = "Режим 2";
            // 
            // buttonFirstMode
            // 
            buttonFirstMode.Location = new Point(129, 91);
            buttonFirstMode.Name = "buttonFirstMode";
            buttonFirstMode.Size = new Size(442, 65);
            buttonFirstMode.TabIndex = 2;
            buttonFirstMode.Text = "button1";
            buttonFirstMode.UseVisualStyleBackColor = true;
            buttonFirstMode.Click += buttonFirstMode_Click;
            // 
            // buttonSecondMode
            // 
            buttonSecondMode.Location = new Point(129, 230);
            buttonSecondMode.Name = "buttonSecondMode";
            buttonSecondMode.Size = new Size(442, 65);
            buttonSecondMode.TabIndex = 3;
            buttonSecondMode.Text = "button2";
            buttonSecondMode.UseVisualStyleBackColor = true;
            buttonSecondMode.Click += buttonSecondMode_Click;
            // 
            // FormModeSelection
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonSecondMode);
            Controls.Add(buttonFirstMode);
            Controls.Add(labelText2);
            Controls.Add(labelText1);
            Name = "FormModeSelection";
            Text = "FormModeSelection";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelText1;
        private Label labelText2;
        private Button buttonFirstMode;
        private Button buttonSecondMode;
    }
}