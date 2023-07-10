using Microsoft.AspNetCore.JsonPatch;
using StudentWebApi.Models.Domain;
using StudentWebApi.Models.Domain;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
namespace StudentWebApi.Models.RepositpryPattern
{
    public interface IDhrgStudentDetailRepository
    {
        public List<DhrgStudentDetail> GetAllAysnc();
        Task<DhrgStudentDetail?> GetByIdAsync(int id);
        Task<DhrgStudentDetail?> UpdateAsync(int id, DhrgStudentDetail d);
        Task<DhrgStudentDetail?> DeleteAsync(int id);
        Task<DhrgStudentDetail> CreateAsync(DhrgStudentDetail d);
        Task<DhrgStudentDetail> PartialUpdateAsync(int id, JsonPatchDocument<DhrgStudentDetail> detail);
    }
}
