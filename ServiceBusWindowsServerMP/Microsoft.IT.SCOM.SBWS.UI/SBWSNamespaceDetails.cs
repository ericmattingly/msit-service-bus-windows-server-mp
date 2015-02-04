using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Common;
using Microsoft.EnterpriseManagement.Internal.UI.Authoring.Pages.Azure;
//using Microsoft.EnterpriseManagement.Mom.UI;
using Microsoft.EnterpriseManagement.Monitoring.Security;
using Microsoft.EnterpriseManagement.Security;
using Microsoft.EnterpriseManagement.UI;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Administration;
using Microsoft.EnterpriseManagement.Common;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.Mom.Internal.UI.Controls;
//using Microsoft.EnterpriseManagement.Mom.UI;
using Microsoft.EnterpriseManagement.Monitoring;

namespace Microsoft.IT.SCOM.SBWS.UI
{
    public partial class SBWSNamespaceDetails : UIPage
    {
        private List<WindowsRunAsAccount> runAsAccountList;
        private PartialMonitoringObject sbwsHostComputer;
        private string templateIdString;

        public SBWSNamespaceDetails()
        {
            InitializeComponent();
        }

        public override void LoadPageConfig()
        {
            if (base.IsCreationMode)
            {
                this.templateIdString = Guid.NewGuid().ToString("N");
            }
            else
            {
                if (string.IsNullOrEmpty(base.InputConfigurationXml))
                {
                    //Bid.TraceError("<ApplicationDetails.LoadPageConfig|ERR> input configuration xml is null\n");
                    return;
                }
                try
                {
                    Predicate<WindowsRunAsAccount> match = null;

                    SBWSNamespaceDetailsConfig pageConfig = XmlHelper.Deserialize(base.InputConfigurationXml, typeof(SBWSNamespaceDetailsConfig), true) as SBWSNamespaceDetailsConfig;
                    this.PopulateRunAsComboBox();

                    this.sbwsNamespaceNameTextBox.Text = pageConfig.SBWSNamespaceName;
                    this.sbwsHostNameBrowseTextBox.Text = pageConfig.SBWSHostName;
                    this.templateIdString = pageConfig.TemplateIdString;

                    if (string.IsNullOrEmpty(pageConfig.RunAsAccount))
                    {
                        this.runAsAccountComboBox.SelectedIndex = -1;
                    }
                    else
                    {
                        if (match == null)
                        {
                            match = delegate(WindowsRunAsAccount windowsAccount)
                            {
                                return windowsAccount.AccountStorageIdString.Equals(pageConfig.RunAsAccount);
                            };
                        }
                        this.runAsAccountComboBox.SelectedIndex = this.runAsAccountList.FindIndex(match);
                    }

                    this.SetSharedUserData();
                }
                catch (Exception exception)
                {
                    return;
                }
            }        

            base.IsConfigValid = this.ValidatePageConfiguration();
            base.LoadPageConfig();

        }

        public override bool OnSetActive()
        {
            this.PopulateRunAsComboBox();
            return base.OnSetActive();
        }


        public override bool SavePageConfig()
        {
            base.IsConfigValid = this.ValidatePageConfiguration();
            if (!base.IsConfigValid)
            {
                return false;
            }

            this.SetSharedUserData();

            if (!this.RunAsAccountDistributionDialog())
            {
                return false;
            }

            SBWSNamespaceDetailsConfig config = new SBWSNamespaceDetailsConfig();

            config.SBWSNamespaceName = this.sbwsNamespaceNameTextBox.Text.ToLowerInvariant();
            config.RunAsAccount = this.runAsAccountList[this.runAsAccountComboBox.SelectedIndex].AccountStorageIdString;
            config.SBWSHostName = this.sbwsHostNameBrowseTextBox.Text.ToLowerInvariant();
            config.TemplateIdString = this.templateIdString;

            base.OutputConfigurationXml = XmlHelper.Serialize(config, true);           
            return true;
        }

        private bool RunAsAccountDistributionDialog()
        {            
            byte[] runAsSsid = base.SharedUserData["SBWSNamespaceDetails.RunAsSsid"] as byte[];
            string runAsName = base.SharedUserData["SBWSNamespaceDetails.RunAsName"] as string;
            sbwsHostComputer = GetSBWSHostComputer(this.sbwsHostNameBrowseTextBox.Text);
                
            SecureData securedData = base.ManagementGroup.Security.GetSecureData(runAsSsid);
            if (securedData == null)
            {
                return false;
            }

            IApprovedHealthServicesForDistribution<PartialMonitoringObject> newState = base.ManagementGroup.Security.GetApprovedHealthServicesForDistribution<PartialMonitoringObject>(securedData);

            if (newState == null)
            {
                return false;
            }
            bool flag2 = newState.Result.Equals(ApprovedHealthServicesResults.All) || newState.HealthServices.Contains(sbwsHostComputer);
            if (!flag2)
            {
                string text = string.Empty;
                StringBuilder builder = new StringBuilder();
                if (!flag2)
                {
                    builder.AppendLine(runAsName);
                }
                //TODO: Fix this language
                text = string.Format("To enable discovery of the queues/topics/subscriptions on Service Bus for Windows Server Namespace <{0}>, the following Run As account must be distributed to the health service '{1}':\n\n{2}\n\nWould you like Operations Manager to distribute the accounts?", this.sbwsNamespaceNameTextBox.Text, this.sbwsHostComputer.DisplayName, builder.ToString());
                if (MessageBox.Show(base.ParentForm, text, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                {
                    return false;
                }
                if (!flag2)
                {
                    newState.Result = ApprovedHealthServicesResults.Specified;
                    newState.HealthServices.Add(sbwsHostComputer);
                    base.ManagementGroup.Security.SetApprovedHealthServicesForDistribution<PartialMonitoringObject>(securedData, newState);
                }
            }
            return true;
        }


        private void PopulateRunAsComboBox()
        {
            if ((this.runAsAccountList != null) && (this.runAsAccountList.Count > 0))
            {
            }
            else
            {
                var monitoringSecureData = base.ManagementGroup.Security.GetSecureData();
                this.runAsAccountList = new List<WindowsRunAsAccount>();

                foreach (SecureData data in monitoringSecureData)
                {
                    if (data.SecureDataType.Equals(SecureDataType.Windows))
                    {
                        this.runAsAccountComboBox.Items.Add(data.Name);
                        this.runAsAccountList.Add(new WindowsRunAsAccount(data));
                    }
                }
            }
        }

        private void SetSharedUserData()
        {
            base.SharedUserData["SBWSNamespaceDetails.SBWSNamespaceName"] = this.sbwsNamespaceNameTextBox.Text;
            base.SharedUserData["SBWSNamespaceDetails.SBWSHostName"] = this.sbwsHostNameBrowseTextBox.Text;
            base.SharedUserData["SBWSNamespaceDetails.TemplateIdString"] = this.templateIdString;

            if (this.runAsAccountComboBox.SelectedIndex >= 0)
            {
                base.SharedUserData["SBWSNamespaceDetails.RunAsId"] = this.runAsAccountList[this.runAsAccountComboBox.SelectedIndex].AccountStorageIdString;
                base.SharedUserData["SBWSNamespaceDetails.RunAsName"] = this.runAsAccountList[this.runAsAccountComboBox.SelectedIndex].AccountName;
                base.SharedUserData["SBWSNamespaceDetails.RunAsSsid"] = this.runAsAccountList[this.runAsAccountComboBox.SelectedIndex].AccountStorageIdByteArray;
            }
        }

        private PartialMonitoringObject GetSBWSHostComputer(string sbwsHostComputerName)
        {
            if (base.ManagementGroup == null)
            {
                return null;
            }
            ManagementPackClass monitoringClass = base.ManagementGroup.EntityTypes.GetClass(SystemMonitoringClass.HealthService);
            if (monitoringClass == null)
            {
                return null;
            }

            List<PartialMonitoringObject> partialMonitoringObjects = new List<PartialMonitoringObject>();
            IObjectReader<PartialMonitoringObject> reader =
                ManagementGroup.EntityObjects.GetObjectReader<PartialMonitoringObject>(
                    new MonitoringObjectGenericCriteria(string.Format(CultureInfo.InvariantCulture, "Name = '{0}' OR DisplayName = '{0}'", new object[] { sbwsHostComputerName })), monitoringClass, ObjectQueryOptions.Default);

            partialMonitoringObjects.AddRange(reader);

            if (partialMonitoringObjects.Count == 1)
            {
                return partialMonitoringObjects[0];
            }
            return null;
        }

        private bool ValidatePageConfiguration()
        {
            this.errorProvider.Clear();
            if (string.IsNullOrEmpty(this.sbwsNamespaceNameTextBox.Text.Trim()) || this.sbwsNamespaceNameTextBox.Text.Contains("."))
            {
                this.errorProvider.SetError(this.sbwsNamespaceNameTextBox, string.Format(CultureInfo.CurrentUICulture, "SBWS namespace must be set", new object[0]));
                return false;
            }
            if (string.IsNullOrEmpty(this.sbwsHostNameBrowseTextBox.Text))
            {
                this.errorProvider.SetError(this.sbwsHostNameBrowseButton, string.Format(CultureInfo.CurrentUICulture, "Host computer must be set", new object[0]));
                return false;
            }
            if (this.runAsAccountComboBox.SelectedIndex < 0)
            {
                this.errorProvider.SetError(this.runAsAccountComboBox, string.Format(CultureInfo.CurrentUICulture, "Run as account must be set", new object[0]));
                return false;
            }

            this.SetSharedUserData();
            return true;
        }

        private void ValidatePageConfigurationEventHandler(object sender, EventArgs e)
        {
            base.IsConfigValid = this.ValidatePageConfiguration();
        }

        private void sbwsHostNameBrowseButton_Click(object sender, EventArgs e)
        {
            this.ShowComputerPickerDialog();
        }

        private void ShowComputerPickerDialog()
        {
            AgentSimpleChooserDialog dialog = new AgentSimpleChooserDialog(base.Container);
            dialog.ShowDialog(this);
            if (dialog.DialogResult == DialogResult.OK)
            {
                if (dialog.SelectedItems != null)
                {
                    ChooserControlItem selectedItem = dialog.SelectedItem as ChooserControlItem;
                    if ((selectedItem == null) || (selectedItem.Item == null))
                    {
                    }
                    else
                    {
                        ComputerHealthService item = selectedItem.Item as ComputerHealthService;
                        if (!string.IsNullOrEmpty(item.PrincipalName))
                        {
                            this.sbwsHostNameBrowseTextBox.Text = item.PrincipalName;
                        }
                    }
                }
            }

            base.IsConfigValid = ValidatePageConfiguration();
        }
    }
}
