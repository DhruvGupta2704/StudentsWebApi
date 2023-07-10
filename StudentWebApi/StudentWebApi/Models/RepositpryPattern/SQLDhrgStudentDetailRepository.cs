using Microsoft.AspNetCore.JsonPatch;
using StudentWebApi.Models.Domain;

namespace StudentWebApi.Models.RepositpryPattern
{
    public class SQLDhrgsStudentDetailRepository : IDhrgStudentDetailRepository
    {
        private readonly SaxotempdbContext context;

        public SQLDhrgsStudentDetailRepository(SaxotempdbContext context)
        {
            this.context = context;
        }
        /*public async Task<List<DhrgStudentDetail>> GetAllAsync()
        {
            return await context.DhrgStudentDetails.ToListAsync();

            
        }*/


        public async Task<DhrgStudentDetail?> GetByIdAsync(int id)
        {
            return await context.DhrgStudentDetails.FirstOrDefaultAsync(x => x.StudentId == id);
        }

        public async Task<DhrgStudentDetail?> UpdateAsync(int id, DhrgStudentDetail d)
        {
            var existingStudentdetail = await context.DhrgStudentDetails.FirstOrDefaultAsync(x => x.StudentId == id);
            if (existingStudentdetail == null)
            {
                return null;
            }
            existingStudentdetail.StudentId = d.StudentId;
            existingStudentdetail.StudentName = d.StudentName;
            existingStudentdetail.Subject1 = d.Subject1;
            existingStudentdetail.Subject2 = d.Subject2;
            existingStudentdetail.Subject3 = d.Subject3;
            await context.SaveChangesAsync();


            return existingStudentdetail;
        }

        public async Task<DhrgStudentDetail?> DeleteAsync(int id)
        {
            var deleteById = await context.DhrgStudentDetails.FirstOrDefaultAsync(x => x.StudentId.Equals(id));
            if (deleteById == null)
            {
                return null;

            }
            context.DhrgStudentDetails.Remove(deleteById);
            await context.SaveChangesAsync();
            return deleteById;
        }

        async Task<DhrgStudentDetail> IDhrgStudentDetailRepository.CreateAsync(DhrgStudentDetail detail)
        {
            await context.DhrgStudentDetails.AddAsync(detail);
            await context.SaveChangesAsync();
            return detail;
        }

        public async Task<DhrgStudentDetail> PartialUpdateAsync(int id, JsonPatchDocument<DhrgStudentDetail> detail)
        {
            var existingStudent = await context.DhrgStudentDetails.FirstOrDefaultAsync(x => x.StudentId == id);
            if (existingStudent == null)
            {
                return null;
            }


            detail.ApplyTo(existingStudent);
            await context.SaveChangesAsync();
            throw new NotImplementedException();
        }

        public List<DhrgStudentDetail> GetAllAysnc()
        {
            var list = context.DhrgStudentDetails.ToList();
            return list;
        }


    }
}
