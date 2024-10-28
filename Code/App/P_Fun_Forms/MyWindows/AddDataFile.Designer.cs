using System.Windows.Forms;

namespace P_Fun_Forms.MyWindows
{
    partial class AddDataFile
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblFilePath;
        private TextBox txtFilePath;
        private Button btnSelectFile;
        private Label lblCustomName;
        private TextBox txtCustomName;
        private Button btnAddFile;
        private Button btnCancel;
        private Label lblError;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.lblCustomName = new System.Windows.Forms.Label();
            this.txtCustomName = new System.Windows.Forms.TextBox();
            this.btnAddFile = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // txtFilePath
            this.txtFilePath.Location = new System.Drawing.Point(12, 12);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(200, 23);
            this.txtFilePath.TabIndex = 0;

            // txtCustomName
            this.txtCustomName.Location = new System.Drawing.Point(12, 41);
            this.txtCustomName.Name = "txtCustomName";
            this.txtCustomName.Size = new System.Drawing.Size(200, 23);
            this.txtCustomName.TabIndex = 1;

            // lblFilePath
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(12, 20);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(80, 17);
            this.lblFilePath.Text = "File Path:";

            // txtFilePath
            this.txtFilePath.Location = new System.Drawing.Point(100, 17);
            this.txtFilePath.Name = "txtFilePath"; 
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(500, 22);

            // btnSelectFile
            this.btnSelectFile.Location = new System.Drawing.Point(610, 15);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(100, 25);
            this.btnSelectFile.Text = "Browse...";
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);

            // lblCustomName
            this.lblCustomName.AutoSize = true;
            this.lblCustomName.Location = new System.Drawing.Point(12, 60);
            this.lblCustomName.Name = "lblCustomName";
            this.lblCustomName.Size = new System.Drawing.Size(100, 17);
            this.lblCustomName.Text = "Custom Name:";

            // txtCustomName
            this.txtCustomName.Location = new System.Drawing.Point(100, 57);
            this.txtCustomName.Name = "txtCustomName";
            this.txtCustomName.Size = new System.Drawing.Size(500, 22);

            // btnAddFile
            this.btnAddFile.Location = new System.Drawing.Point(100, 100);
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(100, 25);
            this.btnAddFile.Text = "Add File";
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(220, 100);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 25);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // lblError
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(100, 140);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);

            // AddDataFile Form
            this.ClientSize = new System.Drawing.Size(750, 200);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.lblCustomName);
            this.Controls.Add(this.txtCustomName);
            this.Controls.Add(this.btnAddFile);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblError);
            this.Name = "AddDataFile";
            this.Text = "Add Data File";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}
