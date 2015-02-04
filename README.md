# Microsoft IT Service Bus for Windows Server Management Pack
The Microsoft IT Service Bus for Windows Server Management Pack provides a new template to use with System Center Operations Manager 2012 R2 to monitor Service Bus for Windows Server

## Features

* Management Pack Template for Creating Service Bus for Windows Server Management Packs
* Securely Encrypts User/Pass for Service Bus Authentication
* Auto Discovers Service Bus Queues, Topics and Subscriptions
* Views for Alerts and Namespace, Queues, Topics and Subscriptions Health
* Monitors for Queues
  * Queue is Enabled
  * Acceptable Message Count in Queue
  * Acceptable Message Count in Dead Letter Queue
  * Old Messages in Queue
* Monitors for Topics
  * Topic is Enabled
  * Topic has Correct Number of Subscribers
* Monitors for Subscriptions
  * Subscription is Enabled
  * Acceptable Message Count in Subscription
  * Acceptable Message Count in Dead Letter Queue
  * Old Messages in Subscription


## Quick Start - Usage

**Please always test new management packs in a test environment before importing to production!**

### Requirements
* System Center Operations Manager 2012 R2

### Importing the MP
1. Download the MPB by downloading a zip file of the code from by clicking the link *Download Zip* on the right of this web page.  The MPB file will be located in the root of the extracted folder.
2. Import the management pack into SCOM
3. Create a Windows Run As Account and grant it "Manage Users" rights to the Service Bus namespace to be monitored
4. Create a new Microsoft IT Service Bus for Windows Server management pack using the Management Pack templates in the Authoring section of the SCOM 2012 R2 Console

## Quick Start - Compiling

### Requirements
* Visual Studio 2013
* [System Center 2012 Visual Studio Authoring Extensions](http://www.microsoft.com/en-us/download/details.aspx?id=30169)

### Compiling
1. Open the solution file
2. Open the Microsoft.IT.SCOM.SBWS Project's properties and on the Build tab either provide a key to seal the MP or uncheck "Generate sealed and signed management pack"
3. Open the Microsoft.IT.SCOM.SBWS.UI Project's properties and on the Build Events tab change the Post-Build event to copy to the Resources folder located in the Microsoft.IT.SCOM.SBWS project directory