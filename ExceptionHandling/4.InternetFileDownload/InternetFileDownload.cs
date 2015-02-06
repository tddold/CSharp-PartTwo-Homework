﻿using System;
using System.ComponentModel;
using System.Net;

class InternetFileDownload
{
    static void Main()
    {
        Console.Write("Enter the address and name of the file you want to download: ");
        string source = Console.ReadLine();
        Console.Write("Enter directory path to download the file: ");
        string destination = Console.ReadLine();

        WebClient webClient = new WebClient();
        using (webClient)
        {
            try
            {
                webClient.DownloadFile(source, destination);
            }
            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("No address entered.");
            }
            catch (WebException)
            {
                Console.Error.WriteLine("The address is invalid.");
            }
            catch (NotSupportedException)
            {
                Console.Error.WriteLine("The method has been called simultaneously on multiple threads.");
            }
        }
    }
}
