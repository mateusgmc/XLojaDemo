using Newtonsoft.Json;

namespace XLojaDemo.App.Models
{
    public class Produto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("preco")]
        public double Preco { get; set; }
    }
}
