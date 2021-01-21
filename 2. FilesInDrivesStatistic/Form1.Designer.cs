
namespace _2.FilesInDrivesStatistic
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
            this.DriveComboBox = new System.Windows.Forms.ComboBox();
            this.DrivesAndDirectoriesPanel = new System.Windows.Forms.Panel();
            this.DirectoryListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListBox3 = new System.Windows.Forms.ListBox();
            this.ListBox2 = new System.Windows.Forms.ListBox();
            this.ListBox1 = new System.Windows.Forms.ListBox();
            this.DrivesAndDirectoriesPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DriveComboBox
            // 
            this.DriveComboBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.DriveComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DriveComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DriveComboBox.FormattingEnabled = true;
            this.DriveComboBox.Location = new System.Drawing.Point(15, 18);
            this.DriveComboBox.Name = "DriveComboBox";
            this.DriveComboBox.Size = new System.Drawing.Size(291, 33);
            this.DriveComboBox.TabIndex = 0;
            this.DriveComboBox.SelectedIndexChanged += new System.EventHandler(this.DriveComboBox_SelectedIndexChanged);
            // 
            // DrivesAndDirectoriesPanel
            // 
            this.DrivesAndDirectoriesPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DrivesAndDirectoriesPanel.Controls.Add(this.DirectoryListBox);
            this.DrivesAndDirectoriesPanel.Controls.Add(this.DriveComboBox);
            this.DrivesAndDirectoriesPanel.Location = new System.Drawing.Point(12, 12);
            this.DrivesAndDirectoriesPanel.Name = "DrivesAndDirectoriesPanel";
            this.DrivesAndDirectoriesPanel.Size = new System.Drawing.Size(322, 691);
            this.DrivesAndDirectoriesPanel.TabIndex = 1;
            // 
            // DirectoryListBox
            // 
            this.DirectoryListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DirectoryListBox.FormattingEnabled = true;
            this.DirectoryListBox.ItemHeight = 25;
            this.DirectoryListBox.Location = new System.Drawing.Point(15, 66);
            this.DirectoryListBox.Name = "DirectoryListBox";
            this.DirectoryListBox.Size = new System.Drawing.Size(291, 604);
            this.DirectoryListBox.TabIndex = 1;
            this.DirectoryListBox.SelectedIndexChanged += new System.EventHandler(this.DirectoryListBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.ListBox3);
            this.panel1.Controls.Add(this.ListBox2);
            this.panel1.Controls.Add(this.ListBox1);
            this.panel1.Location = new System.Drawing.Point(347, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 691);
            this.panel1.TabIndex = 2;
            // 
            // ListBox3
            // 
            this.ListBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListBox3.FormattingEnabled = true;
            this.ListBox3.ItemHeight = 25;
            this.ListBox3.Location = new System.Drawing.Point(657, 18);
            this.ListBox3.Name = "ListBox3";
            this.ListBox3.Size = new System.Drawing.Size(306, 654);
            this.ListBox3.TabIndex = 4;
            // 
            // ListBox2
            // 
            this.ListBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListBox2.FormattingEnabled = true;
            this.ListBox2.ItemHeight = 25;
            this.ListBox2.Location = new System.Drawing.Point(337, 18);
            this.ListBox2.Name = "ListBox2";
            this.ListBox2.Size = new System.Drawing.Size(306, 654);
            this.ListBox2.TabIndex = 3;
            this.ListBox2.SelectedIndexChanged += new System.EventHandler(this.ListBox2_SelectedIndexChanged);
            // 
            // ListBox1
            // 
            this.ListBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListBox1.FormattingEnabled = true;
            this.ListBox1.ItemHeight = 25;
            this.ListBox1.Location = new System.Drawing.Point(15, 18);
            this.ListBox1.Name = "ListBox1";
            this.ListBox1.Size = new System.Drawing.Size(306, 654);
            this.ListBox1.TabIndex = 2;
            this.ListBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 714);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DrivesAndDirectoriesPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DrivesAndDirectoriesPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox DriveComboBox;
        private System.Windows.Forms.Panel DrivesAndDirectoriesPanel;
        private System.Windows.Forms.ListBox DirectoryListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox ListBox3;
        private System.Windows.Forms.ListBox ListBox2;
        private System.Windows.Forms.ListBox ListBox1;
    }
}

