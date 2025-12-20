using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WinformCore.Models.Db;

namespace WinformCore.Models.Mapper;

public class BaseSysEntity : BaseEntity
{
    [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }
}