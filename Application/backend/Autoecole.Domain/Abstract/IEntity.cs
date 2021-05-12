using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Autoecole.Domain.Abstract
{
    public interface IEntity<TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        TKey Id { get; set; }
    }
}