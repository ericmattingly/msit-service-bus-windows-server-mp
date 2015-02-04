using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.UI;
//using Microsoft.EnterpriseManagement.Mom.UI;

namespace Microsoft.IT.SCOM.SBWS.UI
{
    public partial class Summary : UIPage
    {
        private string name;
        private string description;
        private ManagementPack outputManagementPack;
        private string sbwsNamespaceName;
        private string runAsName;
        private string hostName;

        public Summary()
        {
            InitializeComponent();
        }

        private void AddSummaryItem(string name, string value)
        {
            ListViewItem item = new ListViewItem(name);
            item.SubItems.Add(value);
            this.summaryListView.Items.Add(item);
        }

        private void GetSharedUserData()
        {

            this.name = base.SharedUserData["NameAndDescriptionPage.Name"] as string;
            this.description = base.SharedUserData["NameAndDescriptionPage.Description"] as string;
            this.outputManagementPack = base.SharedUserData["NameAndDescriptionPage.ManagementPack"] as ManagementPack;
            this.sbwsNamespaceName = base.SharedUserData["SBWSNamespaceDetails.SBWSNamespaceName"] as string;
            this.runAsName = SharedUserData["SBWSNamespaceDetails.RunAsName"] as string;
            this.hostName = SharedUserData["SBWSNamespaceDetails.SBWSHostName"] as string;
        }

        public override bool OnSetActive()
        {
            this.GetSharedUserData();
            this.SetListViewItems();
            base.IsConfigValid = true;
            return base.OnSetActive();
        }


        private void SetListViewItems()
        {
            this.summaryListView.Items.Clear();
            base.IsConfigValid = false;
            this.AddSummaryItem("Name", this.name);
            if (!string.IsNullOrEmpty(this.description))
            {
                this.AddSummaryItem("Description", this.description);
            }
            if (base.DestinationManagementPack != null)
            {
                this.AddSummaryItem("Management Pack", base.DestinationManagementPack.DisplayName);
            }
            else if (this.outputManagementPack != null)
            {
                this.AddSummaryItem("Management Pack", this.outputManagementPack.DisplayName);
            }
            this.AddSummaryItem("Service Bus for Windows Server Namespace Name", this.sbwsNamespaceName);
            this.AddSummaryItem("Service Bus for Windows Server Host Name", this.hostName);
            this.AddSummaryItem("Run As Account", this.runAsName);
            
            this.summaryListView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.summaryListView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
    }
}
