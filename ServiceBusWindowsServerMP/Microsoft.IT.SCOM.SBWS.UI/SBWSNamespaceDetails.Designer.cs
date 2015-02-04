namespace Microsoft.IT.SCOM.SBWS.UI
{
    partial class SBWSNamespaceDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sbwsNamespaceDetailsTitleLabel = new Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel();
            this.sbwsNamespaceNameLabel = new System.Windows.Forms.Label();
            this.sbwsNamespaceNameTextBox = new System.Windows.Forms.TextBox();
            this.sqlAzureRunAsAccountLabel = new System.Windows.Forms.Label();
            this.runAsAccountComboBox = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.sqlAzureDetailsDescriptionLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sbwsHostNameBrowseButton = new System.Windows.Forms.Button();
            this.sbwsHostNameBrowseTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // sbwsNamespaceDetailsTitleLabel
            // 
            this.sbwsNamespaceDetailsTitleLabel.BackColor = System.Drawing.Color.Transparent;
            this.sbwsNamespaceDetailsTitleLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.sbwsNamespaceDetailsTitleLabel.Location = new System.Drawing.Point(0, 0);
            this.sbwsNamespaceDetailsTitleLabel.MinimumSize = new System.Drawing.Size(244, 0);
            this.sbwsNamespaceDetailsTitleLabel.Name = "sbwsNamespaceDetailsTitleLabel";
            this.sbwsNamespaceDetailsTitleLabel.Size = new System.Drawing.Size(244, 23);
            this.sbwsNamespaceDetailsTitleLabel.TabIndex = 0;
            this.sbwsNamespaceDetailsTitleLabel.Text = "Service Bus for Windows Server Details";
            // 
            // sbwsNamespaceNameLabel
            // 
            this.sbwsNamespaceNameLabel.AutoSize = true;
            this.sbwsNamespaceNameLabel.Location = new System.Drawing.Point(3, 97);
            this.sbwsNamespaceNameLabel.Name = "sbwsNamespaceNameLabel";
            this.sbwsNamespaceNameLabel.Size = new System.Drawing.Size(254, 13);
            this.sbwsNamespaceNameLabel.TabIndex = 0;
            this.sbwsNamespaceNameLabel.Text = "Service Bus for Windows Server Namespace Name:";
            // 
            // sbwsNamespaceNameTextBox
            // 
            this.sbwsNamespaceNameTextBox.Location = new System.Drawing.Point(6, 113);
            this.sbwsNamespaceNameTextBox.Name = "sbwsNamespaceNameTextBox";
            this.sbwsNamespaceNameTextBox.Size = new System.Drawing.Size(237, 20);
            this.sbwsNamespaceNameTextBox.TabIndex = 1;
            this.sbwsNamespaceNameTextBox.TextChanged += new System.EventHandler(this.ValidatePageConfigurationEventHandler);
            // 
            // sqlAzureRunAsAccountLabel
            // 
            this.sqlAzureRunAsAccountLabel.AutoSize = true;
            this.sqlAzureRunAsAccountLabel.Location = new System.Drawing.Point(3, 183);
            this.sqlAzureRunAsAccountLabel.Name = "sqlAzureRunAsAccountLabel";
            this.sqlAzureRunAsAccountLabel.Size = new System.Drawing.Size(244, 13);
            this.sqlAzureRunAsAccountLabel.TabIndex = 4;
            this.sqlAzureRunAsAccountLabel.Text = "Service Bus for Windows Server Run As Account:";
            // 
            // runAsAccountComboBox
            // 
            this.runAsAccountComboBox.FormattingEnabled = true;
            this.runAsAccountComboBox.Location = new System.Drawing.Point(6, 199);
            this.runAsAccountComboBox.Name = "runAsAccountComboBox";
            this.runAsAccountComboBox.Size = new System.Drawing.Size(241, 21);
            this.runAsAccountComboBox.TabIndex = 5;
            this.runAsAccountComboBox.SelectedIndexChanged += new System.EventHandler(this.ValidatePageConfigurationEventHandler);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 0;
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // sqlAzureDetailsDescriptionLabel
            // 
            this.sqlAzureDetailsDescriptionLabel.AutoSize = true;
            this.sqlAzureDetailsDescriptionLabel.Location = new System.Drawing.Point(0, 34);
            this.sqlAzureDetailsDescriptionLabel.Name = "sqlAzureDetailsDescriptionLabel";
            this.sqlAzureDetailsDescriptionLabel.Size = new System.Drawing.Size(0, 13);
            this.sqlAzureDetailsDescriptionLabel.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Microsoft.IT.SCOM.SBWS.UI.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(6, 370);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(208, 30);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(219, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Service Bus for Windows Server Host Name:";
            // 
            // sbwsHostNameBrowseButton
            // 
            this.sbwsHostNameBrowseButton.Location = new System.Drawing.Point(280, 155);
            this.sbwsHostNameBrowseButton.Name = "sbwsHostNameBrowseButton";
            this.sbwsHostNameBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.sbwsHostNameBrowseButton.TabIndex = 12;
            this.sbwsHostNameBrowseButton.Text = "Browse...";
            this.sbwsHostNameBrowseButton.UseVisualStyleBackColor = true;
            this.sbwsHostNameBrowseButton.Click += new System.EventHandler(this.sbwsHostNameBrowseButton_Click);
            // 
            // sbwsHostNameBrowseTextBox
            // 
            this.sbwsHostNameBrowseTextBox.Location = new System.Drawing.Point(6, 157);
            this.sbwsHostNameBrowseTextBox.Name = "sbwsHostNameBrowseTextBox";
            this.sbwsHostNameBrowseTextBox.ReadOnly = true;
            this.sbwsHostNameBrowseTextBox.Size = new System.Drawing.Size(268, 20);
            this.sbwsHostNameBrowseTextBox.TabIndex = 11;
            // 
            // SBWSNamespaceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sbwsHostNameBrowseButton);
            this.Controls.Add(this.sbwsHostNameBrowseTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.sqlAzureDetailsDescriptionLabel);
            this.Controls.Add(this.sbwsNamespaceDetailsTitleLabel);
            this.Controls.Add(this.runAsAccountComboBox);
            this.Controls.Add(this.sqlAzureRunAsAccountLabel);
            this.Controls.Add(this.sbwsNamespaceNameTextBox);
            this.Controls.Add(this.sbwsNamespaceNameLabel);
            this.Name = "SBWSNamespaceDetails";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls.PageSectionLabel sbwsNamespaceDetailsTitleLabel;
        private System.Windows.Forms.Label sbwsNamespaceNameLabel;
        private System.Windows.Forms.TextBox sbwsNamespaceNameTextBox;
        private System.Windows.Forms.Label sqlAzureRunAsAccountLabel;
        private System.Windows.Forms.ComboBox runAsAccountComboBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label sqlAzureDetailsDescriptionLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sbwsHostNameBrowseButton;
        private System.Windows.Forms.TextBox sbwsHostNameBrowseTextBox;
        private System.Windows.Forms.Label label2;
    }
}
