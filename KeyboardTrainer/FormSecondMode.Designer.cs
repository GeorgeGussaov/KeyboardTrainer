namespace KeyboardTrainer
{
    partial class FormSecondMode
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
            labelText = new Label();
            SuspendLayout();
            // 
            // labelText
            // 
            labelText.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelText.AutoSize = true;
            labelText.Location = new Point(436, 247);
            labelText.Name = "labelText";
            labelText.Size = new Size(222, 15);
            labelText.TabIndex = 0;
            labelText.Text = "Нажите любую клавишу чтобы начать";
            // 
            // FormSecondMode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 711);
            Controls.Add(labelText);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormSecondMode";
            Text = "Второй режим";
            KeyDown += FormSecondMode_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label labelText;
    }
}