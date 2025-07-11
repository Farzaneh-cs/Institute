using System.ComponentModel.DataAnnotations;

namespace Institute.Domain;

public record InstituteType(int Id, string Name)
{
    public static InstituteType PublicSchool { get; } = new InstituteType(1, "Public School");
    public static InstituteType PrivateSchool { get; } = new InstituteType(2, "Private School");
    public override string ToString() => Name;

    public static InstituteType FromId(int id) => id switch
    {
        1 => PublicSchool,
        2 => PrivateSchool,
        _ => throw new ArgumentException("Invalid InstituteType Id")
    };
}