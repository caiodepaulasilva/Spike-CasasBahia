namespace Domain.Entities;

public class Product : BaseEntity
{
    public string? Nome { get; set; }
    public decimal Preço { get; set; }
    public int Quantidade { get; set; }
    public DateTime DataCadastro { get; set; }
    public DateTime DataAlteração { get; set; }
}

