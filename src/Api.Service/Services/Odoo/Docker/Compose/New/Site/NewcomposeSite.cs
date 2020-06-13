using System.IO;

namespace Api.Service.Services.Odoo.Docker.Compose.New.Site
{
    public class NewcomposeSite
    {
        private string nomeArquivo;
        private string customerEmail;
        private string odooPort;
        private string dockerimage;
        private string basePath = @"/Odoo";
        private string composePath;
        private string customerTag;
        public NewcomposeSite(string CustomerEmail, string OdooPort, string DockerImage, string CustomerTag)
        {
            this.customerEmail = CustomerEmail;
            this.odooPort = ("- " + char.ConvertFromUtf32(0x0022) + OdooPort + ":8069" + char.ConvertFromUtf32(0x0022));
            this.customerTag = CustomerTag;
            this.dockerimage = DockerImage;
            //Docker-compose.yml
            Dockercompose();

        }
        private void Dockercompose() //Docker-compose.yml
        {
            composePath = Path.GetFullPath(basePath).Substring(0, 5) + @"/" + customerEmail + @"/SITE/" + customerEmail + "_" + customerTag;
            System.IO.Directory.CreateDirectory(composePath);

            nomeArquivo = composePath + @"/docker-compose.yml";

            StreamWriter writer = new StreamWriter(nomeArquivo);

            writer.WriteLine("# APENINOS SOFTWARE");
            writer.WriteLine("version: '2'");
            writer.WriteLine("services:");
            writer.WriteLine("  db:");
            writer.WriteLine("    image: apeninos/asasaas_postgres:version9");
            writer.WriteLine("    environment:");
            writer.WriteLine("      - POSTGRES_PASSWORD=odoo");
            writer.WriteLine("      - POSTGRES_USER=odoo");
            writer.WriteLine("  odoo11:");
            writer.WriteLine("    image: " + dockerimage);
            writer.WriteLine("    depends_on:");
            writer.WriteLine("      - db");
            writer.WriteLine("    ports:");
            writer.WriteLine("      " + odooPort);
            writer.WriteLine("    tty: false");
            writer.WriteLine("    command: -- --dev=reload");
            writer.WriteLine("#    command: odoo scaffold /mnt/extra-addons/test_module");
            writer.WriteLine("    volumes:");
            writer.WriteLine("      - ./o_addons:/mnt/extra-addons");
            writer.WriteLine("      - ./o_etc:/etc/odoo");
            writer.WriteLine("volumes:");
            writer.WriteLine("  db:");
            writer.WriteLine("  odoo11:");

            writer.Close();
        }

    }
}
