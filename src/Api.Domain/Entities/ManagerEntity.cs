using Api.Domain.Entities;

namespace Api.Domain.Entities
{
    public class ManagerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Crm_START { get; set; }
        public bool Vendas_START { get; set; }
        public bool Faturamento_START { get; set; }
        public bool Site_START { get; set; }
        public string Crm_IPV4 { get; set; }
        public string Vendas_IPV4 { get; set; }
        public string Faturamento_IPV4 { get; set; }
        public string Site_IPV4 { get; set; }
        public int Crm_PORT { get; set; }
        public int Vendas_PORT { get; set; }
        public int Faturamento_PORT { get; set; }
        public int Site_PORT { get; set; }
        public int Crm_LICENSES { get; set; }
        public int Vendas_LICENSES { get; set; }
        public int Faturamento_LICENSES { get; set; }
        public int Site_LICENSES { get; set; }
        public string Crm_TAG { get; set; }
        public string Vendas_TAG { get; set; }
        public string Faturamento_TAG { get; set; }
        public string Site_TAG { get; set; }
    }
}
