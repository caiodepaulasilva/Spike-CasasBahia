namespace Domain.DTOs;

public class ProductDto
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public decimal Preço { get; set; }

    public int Quantidade { get; set; }

    public DateTime DataCadastro { get; set; }

    public DateTime DataAlteração { get; set; }
}

