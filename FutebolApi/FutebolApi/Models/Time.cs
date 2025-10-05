using System.ComponentModel.DataAnnotations;

namespace FutebolApi.Models;

public class Time
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    public string Nome { get; set; }
    public string Pais { get; set; }
    public string Fundacao { get; set; }
    public string Estadio { get; set; }
    public int Capacidade { get; set; }
    public string Tecnico { get; set; }
    public string Alcunha { get; set; }
    public string Liga { get; set; }
}
