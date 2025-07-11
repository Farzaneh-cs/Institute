using Institute.Domain;

namespace Institute.Services
{
    public interface IEnrollService
    {
        void EnroolSchool(School school);
    }
    class EnrollService : IEnrollService
    {
        public EnrollService()
        {

        }
        public void EnroolSchool(School school)
        {
            using var context = new InstituteDBContext();

            context.Database.EnsureCreated();

            context.Schools.Add(school);

            context.SaveChanges();
        }
    }
}
