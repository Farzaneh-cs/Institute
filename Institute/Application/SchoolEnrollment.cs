using Institute.Domain;
using Institute.Services;

namespace Institute.Application;

public class SchoolEnrollment
{
    private readonly IEnrollService _enrollService;
    private readonly Func<InstituteType, IInstituteState> _stateFactory;

    public SchoolEnrollment(IEnrollService enrollService,
                            Func<InstituteType, IInstituteState> stateFactory)

    {
        _enrollService = enrollService;
        _stateFactory = stateFactory;
    }

    public void EnrollSchool(string name, int cost, InstituteType instituteType)
    {
        var school = new Domain.School(name, cost, instituteType);
        var state = _stateFactory(instituteType);
        var sName = state.Handle(school);
        Console.WriteLine("**" + sName);
        _enrollService.EnroolSchool(school);
    }
}