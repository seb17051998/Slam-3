namespace ChargementGesperForm
{
    partial class Fm_menu
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_services = new System.Windows.Forms.Button();
            this.bt_diplomes = new System.Windows.Forms.Button();
            this.bt_employes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_services
            // 
            this.bt_services.Location = new System.Drawing.Point(102, 31);
            this.bt_services.Name = "bt_services";
            this.bt_services.Size = new System.Drawing.Size(81, 25);
            this.bt_services.TabIndex = 0;
            this.bt_services.Text = "Services";
            this.bt_services.UseVisualStyleBackColor = true;
            // 
            // bt_diplomes
            // 
            this.bt_diplomes.Location = new System.Drawing.Point(102, 83);
            this.bt_diplomes.Name = "bt_diplomes";
            this.bt_diplomes.Size = new System.Drawing.Size(81, 25);
            this.bt_diplomes.TabIndex = 1;
            this.bt_diplomes.Text = "Diplômes";
            this.bt_diplomes.UseVisualStyleBackColor = true;
            // 
            // bt_employes
            // 
            this.bt_employes.Location = new System.Drawing.Point(102, 129);
            this.bt_employes.Name = "bt_employes";
            this.bt_employes.Size = new System.Drawing.Size(81, 25);
            this.bt_employes.TabIndex = 2;
            this.bt_employes.Text = "Employés";
            this.bt_employes.UseVisualStyleBackColor = true;
            // 
            // Fm_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.bt_employes);
            this.Controls.Add(this.bt_diplomes);
            this.Controls.Add(this.bt_services);
            this.Name = "Fm_menu";
            this.Text = "Gestion du Personnel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_services;
        private System.Windows.Forms.Button bt_diplomes;
        private System.Windows.Forms.Button bt_employes;
    }
}

