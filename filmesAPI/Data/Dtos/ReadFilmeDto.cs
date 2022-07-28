using System.ComponentModel.DataAnnotations;

namespace filmesAPI.Data.Dtos
{
    public class ReadFilmeDto
    {
        [Key]
        [Required]
        public int Id
        {
            get; set;
        }
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        public string Titulo
        {
            get; set;
        }
        [Required(ErrorMessage = "O campo Diretor é obrigatório.")]
        public string Diretor
        {
            get; set;
        }
        [StringLength(30, ErrorMessage = "Limite de caracteres excedido apra Campo: 'Gênero'")]
        public string Genero
        {
            get; set;
        }
        [Range(1, 300, ErrorMessage = "A duração deve ter no mínimo 1 minuto e no máx. 300 minutos.")]
        public int Duracao
        {
            get; set;
        }
        public DateTime HoraDaConsulta
        {
            get; set;
        }
    }
}
