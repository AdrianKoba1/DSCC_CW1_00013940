using DSCC_CW1_00013940.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class TagsController : ControllerBase
{
    private readonly ITagRepository _tagRepository;

    public TagsController(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    // GET: api/Tags
    [HttpGet]
    public async Task<IEnumerable<Tag>> GetTags()
    {
        return await _tagRepository.GetAllTags(); // Fetch tags using repository
        
    }

    // GET: api/Tags/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tag>> GetTagById(int id)
    {
        var tag = await _tagRepository.GetTagById(id);
        if (tag == null) return NotFound();
        return Ok(tag);
    }

    // POST: api/Tags
    [HttpPost]
    public async Task<ActionResult<Tag>> CreateTag(Tag tag)
    {
        await _tagRepository.AddTag(tag);
        return CreatedAtAction("GetTags", new { id = tag.Id }, tag);
    }

    // PUT: api/Tags/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTag(int id, Tag tag)
    {
        if (id != tag.Id) return BadRequest();

        await _tagRepository.UpdateTag(tag);
        return NoContent();
    }

    // DELETE: api/Tags/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTag(int id)
    {
        await _tagRepository.DeleteTag(id);

        return NoContent();
    }
}
