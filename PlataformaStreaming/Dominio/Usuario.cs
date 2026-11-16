using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PlataformaStreaming.Dominio;

[Index(nameof(Correo), IsUnique = true)]
public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string Correo { get; set; } = string.Empty;

    [Required]
    [MaxLength(255)]
    public string Contrasena { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string Rol { get; set; } = string.Empty;
}
