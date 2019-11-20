using System;

namespace TaskManagerApi.Models
{
  public class Tarefa
  {
        
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public bool StatusConclusao { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime DataRemocao { get; set; }
    public DateTime DataAlteracao { get; set; }
  }
} 