using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Api.Service.Services.Odoo.Docker.Delete.CRM
{
    public class NewdeleteVendas
    {
        private string basePath = @"/Odoo";
        private string nomeArquivo;
        private string customerEmail;
        private string configPath;
        private string customerTag;
        public NewdeleteVendas(string CustomerEmail, string CustomerTag)
        {
            this.customerEmail = CustomerEmail;
            this.customerTag = CustomerTag;
            DeleteSAAS();
        }

        private void DeleteSAAS()
        {

            //script para excluir uma instancia
            configPath = Path.GetFullPath(basePath).Substring(0, 5) + @"/" + customerEmail + @"/Vendas/" + customerEmail + "_" + customerTag;
            nomeArquivo = configPath + @"/odoo11_delete.sh";
            StreamWriter writer = new StreamWriter(nomeArquivo);
            writer.WriteLine("#!/bin/bash");
            writer.WriteLine(":" + char.ConvertFromUtf32(0x0027));
            writer.WriteLine("++++++++++++++++++++++++++++++++++++++");
            writer.WriteLine("APENINOS SOFTWARE");
            writer.WriteLine("DELETE CUSTOMER INSTANCE: " + customerEmail);
            writer.WriteLine("______________________________________");
            writer.WriteLine(char.ConvertFromUtf32(0x0027));
            writer.WriteLine("docker container rm -f " + customerEmail + customerTag + "_odoo11_1"); //remove container odoo
            writer.WriteLine("docker container rm -f " + customerEmail + customerTag + "_db_1"); //remove container postgree
            writer.WriteLine("docker network rm " + customerEmail + "_" + customerTag + "_default"); //remove network        
            writer.Close();

            //script para chamar script de exclusão de instancia
            configPath = Path.GetFullPath(basePath).Substring(0, 5) + @"/Delete/" + customerEmail + @"/" + customerTag;
            System.IO.Directory.CreateDirectory(configPath);
            nomeArquivo = configPath + @"/odoo11_delete_Saas.sh";
            StreamWriter writer2 = new StreamWriter(nomeArquivo);
            writer2.WriteLine("#!/bin/bash");
            writer2.WriteLine(":" + char.ConvertFromUtf32(0x0027));
            writer2.WriteLine("++++++++++++++++++++++++++++++++++++++");
            writer2.WriteLine("APENINOS SOFTWARE");
            writer2.WriteLine("DELETE CUSTOMER INSTANCE SAAS: " + customerEmail);
            writer2.WriteLine("______________________________________");
            writer2.WriteLine(char.ConvertFromUtf32(0x0027));
            writer2.WriteLine("cd " + Path.GetFullPath(basePath).Substring(0, 5) + @"/" + customerEmail + @"/CRM/" + customerEmail + "_" + customerTag);
            writer2.WriteLine(@"sudo sh ./odoo11_delete.sh"); //call to remove SAAS odoo
            writer2.Close();

        }



    }
}
