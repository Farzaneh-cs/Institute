using Institute.Services;
using System.ComponentModel.DataAnnotations.Schema;

namespace Institute.Domain;

public class School
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Cost { get; set; }
    public int InstituteTypeId { get; set; }

    [NotMapped]
    public InstituteType InstituteType
    {
        get => InstituteType.FromId(InstituteTypeId); 
        set => InstituteTypeId = value.Id;
    }
    private School()
    {

    }

    public School(string name,
                  int cost,
                  InstituteType instituteType)
    {
        Name = name;
        Cost = cost;
        InstituteType = instituteType;
    }
}
