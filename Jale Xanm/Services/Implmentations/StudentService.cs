using Jale_Xanm.Exceptions;
using Jale_Xanm.Exceptions.Common;
using Jale_Xanm.Models;
using Jale_Xanm.Repositories.Interfaces;
using Jale_Xanm.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Jale_Xanm.Services.Implmentations;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;

    public StudentService(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateAsync(Student student)
    {
        var isExist = await _repository.GetSingleAsync(x => x.Fullname == student.Fullname);

        if (isExist is not null)
            throw new Exception("Student is already exist");

        await _repository.CreateAsync(student);
        await _repository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {

    
            var student = await _repository.GetSingleAsync(x => x.Id == id);
      



        if (student == null)
            throw new NotFoundException("Student not found");

        _repository.Delete(student);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<Student>> GetAllAsync()
    {
        var students = await _repository.GetAll().ToListAsync();


        return students;
    }

    public async Task<Student> GetByIdAsync(int id)
    {
        var student = await _repository.GetSingleAsync(x => x.Id == id);


        if (student == null)
            throw new NotFoundException("Student not found");

        return student;
    }

    public async Task UpdateAsync(Student student)
    {
        var existStudent = await GetByIdAsync(student.Id);

        existStudent.Fullname = student.Fullname;
        existStudent.Grade = student.Grade;

        _repository.Update(student);
        await _repository.SaveChangesAsync();
    }
}
