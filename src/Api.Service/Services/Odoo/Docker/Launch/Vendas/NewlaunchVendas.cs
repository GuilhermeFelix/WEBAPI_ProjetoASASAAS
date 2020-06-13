using System;
using System.Diagnostics;
using System.IO;

namespace Api.Service.Services.Odoo.Docker.Launch.Vendas
{
    public class NewlaunchVendas
    {
        private string basePath = @"/Odoo";
        private string nomeArquivo;
        private string customerEmail;
        private string configPath;
        private string customerTag;
        public NewlaunchVendas(string CustomerEmail, string CustomerTag)
        {
            this.customerEmail = CustomerEmail;
            this.customerTag = CustomerTag;
            NewSAAS();
        }

        private void NewSAAS()
        {
            configPath = Path.GetFullPath(basePath).Substring(0, 5) + @"/" + customerEmail + @"/VENDAS/" + customerEmail + "_" + customerTag;
            System.IO.Directory.CreateDirectory(configPath);

            nomeArquivo = configPath + @"/odoo11_install" + ".sh";
            StreamWriter writer = new StreamWriter(nomeArquivo);
            writer.WriteLine("#!/bin/bash");
            writer.WriteLine(":" + char.ConvertFromUtf32(0x0027));
            writer.WriteLine("++++++++++++++++++++++++++++++++++++++");
            writer.WriteLine("APENINOS SOFTWARE");
            writer.WriteLine("CUSTOMER INSTANCE: " + customerEmail);
            writer.WriteLine("______________________________________");
            writer.WriteLine(char.ConvertFromUtf32(0x0027));
            writer.WriteLine("cd " + configPath);
            writer.WriteLine("sudo apt-get update -y");
            writer.WriteLine("docker-compose up");
            writer.Close();

            var myBatchFile = nomeArquivo; //Path to shell script file
            var argss = $"{myBatchFile}";

            var processInfo = new ProcessStartInfo();
            processInfo.UseShellExecute = false;

            processInfo.FileName = "sh";
            processInfo.Arguments = argss;    // The Script name 

            Process process = Process.Start(processInfo);   // Start that process.
            var outPut = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
        }
    }
}
