namespace KeyboardTrainer
{
    partial class FormFirstMode
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelText = new Label();
            textBoxTrainingField = new TextBox();
            labelCntError = new Label();
            labelCurrentWord = new Label();
            SuspendLayout();
            // 
            // labelText
            // 
            labelText.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            labelText.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelText.Location = new Point(12, 9);
            labelText.Name = "labelText";
            labelText.Size = new Size(1060, 410);
            labelText.TabIndex = 0;
            labelText.Text = "Text from file";
            // 
            // textBoxTrainingField
            // 
            textBoxTrainingField.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxTrainingField.Location = new Point(262, 347);
            textBoxTrainingField.Name = "textBoxTrainingField";
            textBoxTrainingField.Size = new Size(450, 23);
            textBoxTrainingField.TabIndex = 1;
            textBoxTrainingField.TextChanged += textBoxTrainingField_TextChanged;
            // 
            // labelCntError
            // 
            labelCntError.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCntError.AutoSize = true;
            labelCntError.Location = new Point(12, 355);
            labelCntError.Name = "labelCntError";
            labelCntError.Size = new Size(66, 15);
            labelCntError.TabIndex = 2;
            labelCntError.Text = "Ошибок: 0";
            // 
            // labelCurrentWord
            // 
            labelCurrentWord.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            labelCurrentWord.AutoSize = true;
            labelCurrentWord.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCurrentWord.Location = new Point(769, 424);
            labelCurrentWord.Name = "labelCurrentWord";
            labelCurrentWord.Size = new Size(119, 21);
            labelCurrentWord.TabIndex = 3;
            labelCurrentWord.Text = "Текущее слово:";
            // 
            // FormFirstMode
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 711);
            Controls.Add(labelCurrentWord);
            Controls.Add(labelCntError);
            Controls.Add(textBoxTrainingField);
            Controls.Add(labelText);
            Name = "FormFirstMode";
            Text = "Keyboard Trainer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelText;
        private TextBox textBoxTrainingField;
        private Label labelCntError;
        private Label labelCurrentWord;
    }
}