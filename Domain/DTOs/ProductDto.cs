using System.Text.Json.Serialization;

namespace Domain.DTOs;

public class ProductDto
{
    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("Nome")]
    public string? Nome { get; set; }

    [JsonPropertyName("Preco")]
    public decimal Preço { get; set; }

    [JsonPropertyName("Quantidade")]
    public int Quantidade { get; set; }

    [JsonPropertyName("DataCadastro")]
    public DateTime DataCadastro { get; set; }

    [JsonPropertyName("DataAlteracao")]
    public DateTime DataAlteração { get; set; }
}

