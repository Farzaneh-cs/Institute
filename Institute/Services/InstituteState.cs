using Institute.Domain;

namespace Institute.Services;

public interface IInstituteState
{
    string Handle(School instituteType);
}

public class PublicState : IInstituteState
{
    public string Handle(School school)
    {
        Console.WriteLine($"implemet {school.Name} as public school");
        return school.InstituteType.ToString();
    }
}

public class PrivateState : IInstituteState
{
    public string Handle(School school)
    {
        Console.WriteLine($"implemet {school.Name} for private school");
        return school.InstituteType.ToString();
    }
}