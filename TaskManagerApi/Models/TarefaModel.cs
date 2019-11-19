using System;

namespace TaskManagerApi.Models
{
  public class Tarefa
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public DateTime DateTime { get; set; }
  }
} 