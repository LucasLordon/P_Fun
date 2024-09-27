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
            this.formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            this.cantonSelectionPanel = new System.Windows.Forms.Panel();
            this.showDataButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // formsPlot1
            // 
            this.formsPlot1.DisplayScale = 1F;
            this.formsPlot1.Location = new System.Drawing.Point(200, 12); // Ajusté pour laisser de la place pour le panel
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(566, 426);
            this.formsPlot1.TabIndex = 0;

            // 
            // cantonSelectionPanel
            // 
            this.cantonSelectionPanel.AutoScroll = true; // Permettre le défilement si nécessaire
            this.cantonSelectionPanel.Location = new System.Drawing.Point(12, 12); // Positionner à gauche
            this.cantonSelectionPanel.Name = "cantonSelectionPanel";
            this.cantonSelectionPanel.Size = new System.Drawing.Size(180, 350); // Taille pour afficher les checkboxes
            this.cantonSelectionPanel.TabIndex = 1;

            // 
            // showDataButton
            // 
            this.showDataButton.Location = new System.Drawing.Point(12, 380);
            this.showDataButton.Name = "showDataButton";
            this.showDataButton.Size = new System.Drawing.Size(180, 40);
            this.showDataButton.TabIndex = 2;
            this.showDataButton.Text = "Show Data";
            this.showDataButton.UseVisualStyleBackColor = true;
            this.showDataButton.Click += new System.EventHandler(this.onShowDataButtonClick);

            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.showDataButton); // Ajout du bouton
            this.Controls.Add(this.cantonSelectionPanel); // Ajout du panel de sélection
            this.Controls.Add(this.formsPlot1); // Ajout du graphique
            this.Name = "Graph";
            this.Text = "Graph";
            this.Load += new System.EventHandler(this.Graph_Load);
            this.ResumeLayout(false);
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private System.Windows.Forms.Panel cantonSelectionPanel; // Panel pour les checkboxes
        private System.Windows.Forms.Button showDataButton; // Bouton pour afficher les données
    }
}
