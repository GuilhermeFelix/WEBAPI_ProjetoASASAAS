using System;
using System.Diagnostics;
using System.IO;

namespace Api.Service.Services.Odoo.Docker.Delete
{
    public class StartDeleteSAAS
    {
        private string basePath = @"/Odoo";
        private string configPath;
        private string customerTag;
        public StartDeleteSAAS(string CustomerEmail, string CustomerTag)
        {
            this.customerTag = CustomerTag;
            this.configPath = Path.GetFullPath(basePath).Substring(0, 5) + @"/Delete/" + ((CustomerEmail.Replace("-", "0")).Replace("_", "-").Replace(".", "-")).Replace("@", "-") + @"/" + customerTag;
            opensh();
        }

        public void opensh()
        {
            try
            {
                System.IO.Directory.CreateDirectory(configPath);
                var nomeArquivo = configPath + @"/odoo11_delete_Saas.sh";
                var myBatchFile = nomeArquivo; //Path to shell script file
                var argss = $"{myBatchFile}";


                var processInfo = new ProcessStartInfo();
                processInfo.UseShellExecute = true;
                processInfo.UserName = "guilherme";
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
