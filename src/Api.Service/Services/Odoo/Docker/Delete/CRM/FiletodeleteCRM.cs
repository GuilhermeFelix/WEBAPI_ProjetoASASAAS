using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Api.Service.Services.Odoo.Docker.Delete.CRM
{
    public class FiletodeleteCRM
    {
        private string basePath = @"/Odoo";
        private string nomeArquivo;
        private string customerEmail;
        private string configPath;
        private string customerTag;

        public FiletodeleteCRM(string CustomerEmail, string CustomerTag)
        {
            this.customerEmail = ((CustomerEmail.Replace("-", "0")).Replace("_", "-").Replace(".", "-")).Replace("@", "-");
            this.customerTag = CustomerTag;
            DeleteSAAS();
        }

        private void DeleteSAAS()
        {

            //script para excluir uma instancia
            configPath = Path.GetFullPath(basePath).Substring(0, 5) + @"/" + customerEmail + @"/CRM/" + customerEmail + "_" + customerTag;
            nomeArquivo = configPath + @"/odoo11_delete.sh";
            StreamWriter writer = new StreamWriter(nomeArquivo);
            writer.WriteLine("#!/bin/bash");
            writer.WriteLine("#++++++++++++++++++++++++++++++++++++++");
            writer.WriteLine("#APENINOS SOFTWARE");
            writer.WriteLine("#DELETE CUSTOMER INSTANCE: " + customerEmail);
            writer.WriteLine("#______________________________________");
            var nomecontainer = customerEmail + customerTag;
            nomecontainer = nomecontainer.Replace("-", "");
            writer.WriteLine("set +e");
            writer.WriteLine("docker container rm -f " + nomecontainer + "_odoo11_1 || true"); //remove container odoo
            writer.WriteLine("docker container rm -f " + nomecontainer + "_db_1 || true"); //remove container postgree
            writer.WriteLine("docker network rm " + nomecontainer + "_default || true"); //remove network        
            writer.Close();
            opensh();
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
            catch (Exception)
            {
                return;
            }

        }
    }
}
