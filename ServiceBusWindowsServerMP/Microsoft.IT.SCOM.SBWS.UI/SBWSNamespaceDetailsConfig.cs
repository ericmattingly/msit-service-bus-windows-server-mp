using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Microsoft.IT.SCOM.SBWS.UI
{
    [Serializable, XmlType(AnonymousType = true), XmlRoot(Namespace = "", IsNullable = false)]
    public class SBWSNamespaceDetailsConfig
    {
        private string sbwsNamespaceName;
        private string sbwsHostName;
        private string runAsAccount;
        private string templateIdString;

        public SBWSNamespaceDetailsConfig()
        {
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string SBWSNamespaceName
        {
            get
            {
                return this.sbwsNamespaceName;
            }
            set
            {
                this.sbwsNamespaceName = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string SBWSHostName
        {
            get
            {
                return this.sbwsHostName;
            }
            set
            {
                this.sbwsHostName = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RunAsAccount
        {
            get
            {
                return this.runAsAccount;
            }
            set
            {
                this.runAsAccount = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TemplateIdString
        {
            get
            {
                return this.templateIdString;
            }
            set
            {
                this.templateIdString = value;
            }
        }
    }
}
