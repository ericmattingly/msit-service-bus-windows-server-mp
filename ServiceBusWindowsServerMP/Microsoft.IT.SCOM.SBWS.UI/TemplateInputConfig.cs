using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace Microsoft.IT.SCOM.SBWS.UI
{
    [Serializable, XmlType(AnonymousType = true), XmlRoot(Namespace = "", IsNullable = false)]
    public class TemplateInputConfig
    {
        // Fields
        private string nameField;
        private string descriptionField;
        private string sbwsNamespaceNameField;
        private string sbwsHostNameField;
        private string runAsAccountField;
        private string templateIdStringField;
        

        // Properties
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string RunAsAccount
        {
            get
            {
                return this.runAsAccountField;
            }
            set
            {
                this.runAsAccountField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string SBWSNamespaceName
        {
            get
            {
                return this.sbwsNamespaceNameField;
            }
            set
            {
                this.sbwsNamespaceNameField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string SBWSHostName
        {
            get
            {
                return this.sbwsHostNameField;
            }
            set
            {
                this.sbwsHostNameField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TemplateIdString
        {
            get
            {
                return this.templateIdStringField;
            }
            set
            {
                this.templateIdStringField = value;
            }
        }       
    }
}
