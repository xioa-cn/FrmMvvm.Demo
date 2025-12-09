using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectRecord.Models.Db;

namespace ProjectRecord.Models.Mapper;

public class BaseSysEntity : BaseEntity
{
    [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }
}