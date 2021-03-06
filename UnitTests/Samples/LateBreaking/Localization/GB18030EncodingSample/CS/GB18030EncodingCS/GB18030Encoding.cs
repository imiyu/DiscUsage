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
using System;
using System.Collections;
using System.Text;
using System.Security.Permissions;

[assembly:CLSCompliant(true)]
[assembly:SecurityPermissionAttribute(SecurityAction.RequestMinimum,
Assertion=true)]
namespace Microsoft.Samples.GB18030EncodingCS
{
    //In order to see the DBCS characters in your Console Window, you need
    //change the code page to 936, even when this is done, you could only 
    //see GB18030-only characters as ?
    class GB18030Encoding
    {        
        static Encoding unicode = new UnicodeEncoding();
        static Encoding GB18030 = Encoding.GetEncoding(54936);
        static Encoding GB2312 = Encoding.GetEncoding(936);
        static byte[] bUnicode = new byte[128];
        static byte[] bGB18030 = new byte[128];
        static byte[] bGB2312 = new byte[128];	

        static void Main()
        {            
            String sGB18030, sUnicode, sGB2312;            
            Char[] cGB18030 = new Char[64];
            SortedList sl1 = new SortedList();
            SortedList sl2 = new SortedList();
            SortedList sl4 = new SortedList();                     
            int i, byteCount, charCount, bn;          

            //This part of the sample will demonstrate that .NET Framework
            //supported GB18030 encoding as one of its encodings, so it awares
            //that GB18030 encoding is a variable length format which allows
            //1, 2 and 4 bytes
            Console.Write("First Part: GB18030 is a variable length");
            Console.WriteLine(" formating");
            //The Unicode string which contains 1/2/4-bytes in GB18030 
            //encoding is \u3400 \u0061 \u0061 \u554A 
            //\u554A \u3400 \u3400 \u554A \u0061
            //In GB18030 encoding \u3400 is encoded as 8139EE39
            //which is 4 bytes
            //In GB18030 encoding \u0061 is encoded as 61 which is 1 byte
            //In GB18030 encoding \u5541 is encoded as B0A1 which is 2 byte
            sUnicode = "\u3400\u0061\u0061\u554A\u554A" +
                       "\u3400\u3400\u554A\u0061";                
            //Get Unicode byte array from Unicode string
            bUnicode = unicode.GetBytes(sUnicode);
            //Get GB18030 byte array from Unicode byte array            
            bGB18030 = Encoding.Convert(unicode, GB18030, bUnicode);
            //Get GB18030 encoded string from GB18030 byte array
            sGB18030 = GB18030.GetString(bGB18030);	
            Console.WriteLine("The GB18030 string is {0}", sGB18030);
            //Get the char count of GB18030 encoded byte array
            charCount = GB18030.GetCharCount(bGB18030);
            //Get the byte count of GB18030 encoded string
            byteCount = GB18030.GetByteCount(sGB18030);            
            Console.WriteLine("It has {0} chars, {1} bytes", charCount, 
                            byteCount);
            //Get GB18030 char array from GB18030 byte array  
            cGB18030 = GB18030.GetChars(bGB18030);
            for (i = 0; i < charCount; i++)
            {
                bn = GB18030.GetByteCount(cGB18030[i].ToString());
                Console.WriteLine("No.{0} char is {1}, it has {2} bytes", i, 
                                cGB18030[i], bn);
                switch (bn)
                {
                    //Add 1-byte GB18030 encoded char to sl1
                    case 1:                        
                        sl1.Add(i, cGB18030[i]);
                        break;
                    //Add 2-byte GB18030 encoded char to sl1
                    case 2:
                        sl2.Add(i, cGB18030[i]);
                        break;
                    //Add 4-byte GB18030 encoded char to sl1
                    case 4:
                        sl4.Add(i, cGB18030[i]);
                        break;
                    default:
                        Console.WriteLine("Invalid GB18030 encoding!");
                        break;
                }
            }
            Console.WriteLine("The string has {0} 1-byte characters, they are"
                            , sl1.Count);
            PrintKeysAndValues(sl1);
            Console.WriteLine("The string has {0} 2-byte characters, they are"
                            , sl2.Count);
            PrintKeysAndValues(sl2);
            Console.WriteLine("The string has {0} 4-byte characters, they are"
                            , sl2.Count);
            PrintKeysAndValues(sl4);

            //Below part sample demonstrate to convert a Unicode string
            //to GB18030 and then to GB2312 and then back to Unicode 
            Console.WriteLine();
            Console.WriteLine("Second Part: Encoding Conversion");            
            sUnicode = "\u4E02\u4E90\u9CCC\u9F44\u4E96\u6C49" +
                       "\u724B\u9F22\u8140\u512C\u7218\u7222" +
                       "\u4E06\u9C49\u71EC\u716A\u4F04\u7667" +
                       "\u76F6\u7788\u7789\u8A3D\u8B20\u9C78" +
                       "\u5FA0\u74EA\u74D9\u616F\u616B\u6142";
            Console.WriteLine("The original Unicode string is {0}", sUnicode);
            sGB18030 = UnicodeToGB18030(sUnicode);
            Console.WriteLine("Convert to GB18030 the string is {0}", 
                            sGB18030);
            sGB2312 = GB18030ToGB2312(sGB18030);
            Console.WriteLine("Convert to GB2312 the string is {0}", sGB2312);
            sUnicode = GB2312ToUnicode(sGB2312);
            Console.WriteLine("Convert back to Unicode the string is {0}",
                            sUnicode);
        }

        //Print the Key and Value in the SortedList
        public static void PrintKeysAndValues(SortedList myList)
        {
            Console.WriteLine("\t-KEY-\t-VALUE-");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine("\t{0}:\t{1}", myList.GetKey(i),
                                myList.GetByIndex(i));
            }
            Console.WriteLine();
        }

        //Print the contents of the byte array in hexadecimal format
        public static void PrintByte(Byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++) Console.Write("[{0:X}] ",
                bytes[i]);
            Console.WriteLine();
        }

        public static string UnicodeToGB18030(string sUnicode)
        {
            try
            {
                bUnicode = unicode.GetBytes(sUnicode);
                Console.WriteLine("The Unicode Encoding of the string is as below"
                                + ", it has {0} bytes:", bUnicode.Length);
                PrintByte(bUnicode);
                //Convert Unicode to GB18030
                bGB18030 = Encoding.Convert(unicode, GB18030, bUnicode);
                Console.WriteLine("The GB18030 Encoding of the string is as below"
                                + ", it has {0} bytes:", bGB18030.Length);
                PrintByte(bGB18030);
                return GB18030.GetString(bGB18030);
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return "Converstion Failed";
            }
        }

        public static string GB18030ToGB2312(string sGB18030)
        {
            try
            {
                bGB18030 = GB18030.GetBytes(sGB18030);
                Console.WriteLine("The GB18030 Encoding of the string is as below"
                                + ", it has {0} bytes:", bGB18030.Length);
                PrintByte(bGB18030);
                //Convert GB18030 to GB2312
                bGB2312 = Encoding.Convert(GB18030, GB2312, bGB18030);
                Console.WriteLine("The GB2312 Encoding of the string is as below,"
                                + "it has {0} bytes:", bGB2312.Length);
                PrintByte(bGB2312);
                return GB2312.GetString(bGB2312);
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return "Converstion Failed";
            }
        }    

        public static string GB2312ToUnicode(string sGB2312)
        {
            try
            {
                bGB2312 = GB2312.GetBytes(sGB2312);
                Console.WriteLine("The GB2312 Encoding of the string is as below,"
                                + "it has {0} bytes:", bGB2312.Length);
                PrintByte(bGB2312);
                //Convert GB2312 to Unicode
                bUnicode = Encoding.Convert(GB2312, unicode, bGB2312);
                Console.WriteLine("The Unicode Encoding of the string is as below"
                                + ", it has {0} bytes:", bGB2312.Length);
                PrintByte(bUnicode);
                return unicode.GetString(bUnicode);
            }
            catch (System.IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return "Converstion Failed";
            }
        }	
    }
}
