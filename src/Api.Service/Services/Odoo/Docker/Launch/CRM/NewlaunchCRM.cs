using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Api.Service.Services.Odoo.Docker.Delete.CRM;

namespace Api.Service.Services.Odoo.Docker.Launch.CRM
{
    public class NewlaunchCRM
    {
        private string basePath = @"/Odoo";
        private string nomeArquivo;
        private string customerEmail;
        private string configPath;
        private string customerTag;
        public NewlaunchCRM(string CustomerEmail, string CustomerTag)
        {
            this.customerEmail = ((CustomerEmail.Replace("-", "0")).Replace("_", "-").Replace(".", "-")).Replace("@", "-");
            this.customerTag = CustomerTag;
            NewSAAS();
        }

        private void NewSAAS()
        {

            //script para executar uma nova instancia
            configPath = Path.GetFullPath(basePath).Substring(0, 5) + @"/" + customerEmail + @"/CRM/" + customerEmail + "_" + customerTag;

            System.IO.Directory.CreateDirectory(configPath);

            nomeArquivo = configPath + @"/odoo11_install.sh";
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

            //new Thread(new ThreadStart(opensh)).Start();
            opensh();


            //Create Scripts to Delete in future
            NewdeleteCRM newdeleteCRM = new NewdeleteCRM(customerEmail, customerTag);

        }

        public void opensh()
        {
            try
            {
                var myBatchFile = nomeArquivo; //Path to shell script file
                var argss = $"{myBatchFile}";

                var processInfo = new ProcessStartInfo();
                processInfo.UseShellExecute = true;

                processInfo.FileName = "sh";
                processInfo.Arguments = argss;    // The Script name 

                Process process = Process.Start(processInfo);   // Start that process.
                var outPut = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
            }
            catch (Exception error)
            {
                var texto = error;
            }

        }

    }
}
