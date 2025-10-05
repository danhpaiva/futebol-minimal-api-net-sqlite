using System.ComponentModel.DataAnnotations;

namespace FutebolApi.Models;

public class Jogador
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Nome { get; set; }
    public int Idade { get; set; }
    public string Nacionalidade { get; set; }
    public string UltimoClube { get; set; }
    public string Posicao { get; set; }
    public int Qtde_Gols { get; set; }
    public decimal SalarioMensal { get; set; }
    public double Altura { get; set; }
    public double Peso { get; set; }
}
