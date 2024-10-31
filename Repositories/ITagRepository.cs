using DSCC_CW1_00013940.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ITagRepository
{
    Task<IEnumerable<Tag>> GetAllTags();
    Task<Tag> GetTagById(int id);
    Task AddTag(Tag tag);
    Task UpdateTag(Tag tag);
    Task DeleteTag(int id);
}
