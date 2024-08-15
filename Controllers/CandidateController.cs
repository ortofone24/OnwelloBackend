using Microsoft.AspNetCore.Mvc;
using OnwelloBackend.Common;
using OnwelloBackend.Models;

namespace OnwelloBackend.Controllers
{
    public class CandidateController(InMemoryStore<Candidate> itemStore) : ApiController
    {
        // GET: api/candidate
        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> GetAll()
        {
            return Ok(itemStore.GetAll());
        }

        // GET: api/candidate/{id}
        [HttpGet("{id}")]
        public ActionResult<Candidate> GetById(int id)
        {
            var item = itemStore.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/candidate
        [HttpPost]
        public ActionResult<Candidate> Create(Candidate item)
        {
            itemStore.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/candidate/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Candidate item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            var existingItem = itemStore.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }

            itemStore.Update(item);
            return NoContent();
        }

        // DELETE: api/candidate/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = itemStore.GetById(id);
            if (item == null)
            {
                return NotFound();
            }

            itemStore.Delete(id);
            return NoContent();
        }
    }
}
