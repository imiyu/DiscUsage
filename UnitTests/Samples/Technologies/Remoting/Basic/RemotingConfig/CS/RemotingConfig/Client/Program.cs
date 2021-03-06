﻿//---------------------------------------------------------------------
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
using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Text;
using Microsoft.Samples.SharedImplementation;

namespace Microsoft.Samples.Remoting.RemotingConfig.Client
{
    class Program
    {
        static void Main()
        {
            RemotingConfiguration.Configure("Client.exe.config", true /*ensureSecurity*/);

            HelloWorld proxy = new HelloWorld();
            Console.WriteLine("Echo response: {0}", proxy.Echo("Hello"));

        }
    }
}
