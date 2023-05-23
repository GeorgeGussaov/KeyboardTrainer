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
            buttonFirstMode = new Button();
            buttonSecondMode = new Button();
            SuspendLayout();
            // 
            // buttonFirstMode
            // 
            buttonFirstMode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonFirstMode.Location = new Point(129, 91);
            buttonFirstMode.Name = "buttonFirstMode";
            buttonFirstMode.Size = new Size(442, 65);
            buttonFirstMode.TabIndex = 2;
            buttonFirstMode.Text = "Режим 1";
            buttonFirstMode.UseVisualStyleBackColor = true;
            buttonFirstMode.Click += buttonFirstMode_Click;
            // 
            // buttonSecondMode
            // 
            buttonSecondMode.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonSecondMode.Location = new Point(129, 230);
            buttonSecondMode.Name = "buttonSecondMode";
            buttonSecondMode.Size = new Size(442, 65);
            buttonSecondMode.TabIndex = 3;
            buttonSecondMode.Text = "Режим 2";
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
            Name = "FormModeSelection";
            Text = "Выбор режима";
            ResumeLayout(false);
        }

        #endregion
        private Button buttonFirstMode;
        private Button buttonSecondMode;
    }
}