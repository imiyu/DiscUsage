//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

//
//A range of different International Domain Names you can try:
//    http://www.bücher.de - a German Internet bookstore
//    http://理容ナカムラ.com - Nakamura Barber Shop: Japanese company site
//    http://www.푸른소아과.com - Poorunsoahkwa: Korean pediatric medicine site
//
//More information on the technology behind International Domain Names is available on:
//    http://www.verisign.com/products-services/naming-and-directory-services/naming-services/internationalized-domain-names/
//  

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Microsoft.Samples.InternationalDomainName
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            // This code section extracts the protocol, host section and extension of the string that is
            // entered in the address control
            // A more sophisticated verification is recommended to make this adapt for all possible erroneous input
            Regex r = new Regex(@"(?<proto>\w+)://(?<host>[\w.]+)/*(?<ext>\S*)", RegexOptions.Compiled);
            string proto = r.Match(this.textBoxAddress.Text).Result("${proto}");
            string host = r.Match(this.textBoxAddress.Text).Result("${host}");
            string ext = r.Match(this.textBoxAddress.Text).Result("${ext}");

            // Convert the entered IDN host name to Punycode
            IdnMapping mapping = new IdnMapping();
            string puny = mapping.GetAscii(host);

            // Assemble the URL and navigate to the specified site
            this.textBoxPunycode.Text = proto + "://" + puny + "/" + ext;
            this.webBrowser1.Navigate(this.textBoxPunycode.Text);
        }
    }
}