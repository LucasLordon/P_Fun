namespace P_Fun_Forms.MyWindows
{
    partial class Graph
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
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            cantonSelectionPanel = new Panel();
            showDataButton = new Button();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            isDefaultView = new CheckBox();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(200, 12);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(566, 426);
            formsPlot1.TabIndex = 0;
            // 
            // cantonSelectionPanel
            // 
            cantonSelectionPanel.AutoScroll = true;
            cantonSelectionPanel.Location = new Point(12, 12);
            cantonSelectionPanel.Name = "cantonSelectionPanel";
            cantonSelectionPanel.Size = new Size(180, 350);
            cantonSelectionPanel.TabIndex = 1;
            // 
            // showDataButton
            // 
            showDataButton.Location = new Point(12, 380);
            showDataButton.Name = "showDataButton";
            showDataButton.Size = new Size(180, 40);
            showDataButton.TabIndex = 2;
            showDataButton.Text = "Show Data";
            showDataButton.UseVisualStyleBackColor = true;
            showDataButton.Click += onShowDataButtonClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(772, 299);
            label1.Name = "label1";
            label1.Size = new Size(114, 21);
            label1.TabIndex = 3;
            label1.Text = "Date de début :";
            label1.UseMnemonic = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(772, 362);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 4;
            label2.Text = "Date de fin :";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(772, 323);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.Value = new DateTime(2020, 2, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(772, 386);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 6;
            dateTimePicker2.Value = new DateTime(2024, 10, 5, 9, 22, 58, 0);
            // 
            // isDefaultView
            // 
            isDefaultView.AutoSize = true;
            isDefaultView.Location = new Point(772, 277);
            isDefaultView.Name = "isDefaultView";
            isDefaultView.Size = new Size(159, 19);
            isDefaultView.TabIndex = 7;
            isDefaultView.Text = "Activé la vue par default :";
            isDefaultView.UseVisualStyleBackColor = true;
            // 
            // Graph
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1106, 481);
            Controls.Add(isDefaultView);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(showDataButton);
            Controls.Add(cantonSelectionPanel);
            Controls.Add(formsPlot1);
            Name = "Graph";
            Text = "Graph";
            Load += Graph_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private System.Windows.Forms.Panel cantonSelectionPanel; 
        private System.Windows.Forms.Button showDataButton;
        private Label label1;
        private Label label2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private CheckBox isDefaultView;
    }
}
