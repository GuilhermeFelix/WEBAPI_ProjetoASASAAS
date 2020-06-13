using System.IO;


namespace Api.Service.Services.Odoo.Configuration.New.Vendas
{
    public class NewconfigurationVendas
    {

        private string nomeArquivo;
        private string customerEmail;
        private string customerTag;
        private string basePath = @"/Odoo";
        private string configPath;
        private string logPath;

        public NewconfigurationVendas(string CustomerEmail, string CustomerTag)
        {
            this.customerEmail = CustomerEmail;
            this.customerTag = CustomerTag;
            //Odoo.conf
            Newodooconf();
            //Odoo-server.log
            Newodooserverlog();
        }

        private void Newodooconf() //Odoo.conf
        {

            configPath = Path.GetFullPath(basePath).Substring(0, 5) + @"/" + customerEmail + @"/VENDAS/" + customerEmail + "_" + customerTag;
            System.IO.Directory.CreateDirectory(configPath);

            nomeArquivo = configPath + @"/odoo.conf";

            StreamWriter writer = new StreamWriter(nomeArquivo);
            writer.WriteLine("addons_path = /mnt/extra - addons");
            writer.WriteLine("data_dir = /var/lib/odoo");
            writer.WriteLine("logfile = " + Path.GetFullPath(basePath).Substring(0, 5) + @"/" + customerEmail + @"/Logs" + @"/" + "Vendas" + @"/odoo-server" + ".log");
            writer.WriteLine("; admin_passwd = admin");
            writer.WriteLine("; csv_internal_sep = ,");
            writer.WriteLine("; db_name = False");
            writer.WriteLine("; db_template = template1");
            writer.WriteLine("; dbfilter = .*");
            writer.WriteLine("; debug_mode = False");
            writer.WriteLine("; email_from = False");
            writer.WriteLine("; list_db = True");
            writer.WriteLine("; log_db = False");
            writer.WriteLine("; log_handler = [':INFO']");
            writer.WriteLine("; log_level = info");
            writer.WriteLine("; logfile = None");
            writer.WriteLine("; longpolling_port = 8072");
            writer.WriteLine("; osv_memory_count_limit = False");
            writer.WriteLine("; smtp_password = False");
            writer.WriteLine("; smtp_port = 25");
            writer.WriteLine("; smtp_server = localhost");
            writer.WriteLine("; smtp_ssl = False");
            writer.WriteLine("; smtp_user = False");
            writer.WriteLine("; workers = 0");
            writer.WriteLine("; xmlrpc = True");
            writer.WriteLine("; xmlrpc_interface =");
            writer.WriteLine("; xmlrpc_port = 8069");
            writer.WriteLine("; xmlrpcs = True");
            writer.WriteLine("; xmlrpcs_interface =");
            writer.WriteLine("; xmlrpcs_port = 8071");
            writer.Close();
        }

        private void Newodooserverlog() //Odoo-server.log
        {
            logPath = Path.GetFullPath(basePath).Substring(0, 5) + @"/" + customerEmail + @"/Logs" + @"/" + "Vendas";
            System.IO.Directory.CreateDirectory(logPath);
            nomeArquivo = logPath + @"/odoo-server" + ".log";
            StreamWriter writer = new StreamWriter(nomeArquivo);
            writer.Close();
        }
    }
}
