using Jale_Xanm.Contexts;
using Jale_Xanm.Models;
using Jale_Xanm.Repositories.Implmentations.Generic;
using Jale_Xanm.Repositories.Interfaces;

namespace Jale_Xanm.Repositories.Implmentations;

public class StudentRepository : Repository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context)
    {
    }
}
