namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBefore = new System.Windows.Forms.PictureBox();
            this.pictureAfter = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadPicture = new System.Windows.Forms.Button();
            this.textToInsert = new System.Windows.Forms.TextBox();
            this.insertText = new System.Windows.Forms.Button();
            this.insertedText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.keySecurity = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAfter)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBefore
            // 
            this.pictureBefore.Location = new System.Drawing.Point(25, 89);
            this.pictureBefore.Name = "pictureBefore";
            this.pictureBefore.Size = new System.Drawing.Size(558, 374);
            this.pictureBefore.TabIndex = 0;
            this.pictureBefore.TabStop = false;
            // 
            // pictureAfter
            // 
            this.pictureAfter.Location = new System.Drawing.Point(789, 89);
            this.pictureAfter.Name = "pictureAfter";
            this.pictureAfter.Size = new System.Drawing.Size(558, 374);
            this.pictureAfter.TabIndex = 1;
            this.pictureAfter.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // loadPicture
            // 
            this.loadPicture.Location = new System.Drawing.Point(618, 89);
            this.loadPicture.Name = "loadPicture";
            this.loadPicture.Size = new System.Drawing.Size(135, 49);
            this.loadPicture.TabIndex = 2;
            this.loadPicture.Text = "Load bmp ";
            this.loadPicture.UseVisualStyleBackColor = true;
            this.loadPicture.Click += new System.EventHandler(this.loadPicture_Click);
            // 
            // textToInsert
            // 
            this.textToInsert.Location = new System.Drawing.Point(618, 144);
            this.textToInsert.Name = "textToInsert";
            this.textToInsert.Size = new System.Drawing.Size(135, 22);
            this.textToInsert.TabIndex = 3;
            // 
            // insertText
            // 
            this.insertText.Location = new System.Drawing.Point(618, 172);
            this.insertText.Name = "insertText";
            this.insertText.Size = new System.Drawing.Size(135, 46);
            this.insertText.TabIndex = 4;
            this.insertText.Text = "Encrypt and insert to bmp";
            this.insertText.UseVisualStyleBackColor = true;
            this.insertText.Click += new System.EventHandler(this.insertText_Click);
            // 
            // insertedText
            // 
            this.insertedText.Location = new System.Drawing.Point(618, 441);
            this.insertedText.Name = "insertedText";
            this.insertedText.Size = new System.Drawing.Size(135, 22);
            this.insertedText.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 412);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Read msg";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(618, 261);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(135, 102);
            this.save.TabIndex = 7;
            this.save.Text = "Save bmp with encrypted msg";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(569, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Encrypting key";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // keySecurity
            // 
            this.keySecurity.Location = new System.Drawing.Point(676, 12);
            this.keySecurity.Name = "keySecurity";
            this.keySecurity.Size = new System.Drawing.Size(241, 22);
            this.keySecurity.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 710);
            this.Controls.Add(this.keySecurity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.save);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.insertedText);
            this.Controls.Add(this.insertText);
            this.Controls.Add(this.textToInsert);
            this.Controls.Add(this.loadPicture);
            this.Controls.Add(this.pictureAfter);
            this.Controls.Add(this.pictureBefore);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureAfter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBefore;
        private System.Windows.Forms.PictureBox pictureAfter;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button loadPicture;
        private System.Windows.Forms.TextBox textToInsert;
        private System.Windows.Forms.Button insertText;
        private System.Windows.Forms.TextBox insertedText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox keySecurity;
    }
}

