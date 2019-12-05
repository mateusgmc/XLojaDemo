using Newtonsoft.Json;

namespace XLojaDemo.App.Models
{
    public class Usuario
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("foto")]
        public string Foto { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("senha")]
        public string Senha { get; set; }

        [JsonProperty("cargo")]
        public string Cargo { get; set; }
    }
}
