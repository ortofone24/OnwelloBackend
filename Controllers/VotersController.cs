using Microsoft.AspNetCore.Mvc;
using OnwelloBackend.Common;
using OnwelloBackend.Models;

namespace OnwelloBackend.Controllers
{
    public class VotersController(InMemoryStore<Voter> itemStore) : ApiController
    {
        // GET: api/voters
        [HttpGet]
        public ActionResult<IEnumerable<Voter>> GetAll()
        {
            return Ok(itemStore.GetAll());
        }

        // GET: api/items/{id}
        [HttpGet("{id}")]
        public ActionResult<Voter> GetById(int id)
        {
            var item = itemStore.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST: api/voters
        [HttpPost]
        public ActionResult<Voter> Create(Voter item)
        {
            itemStore.Add(item);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/voters/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Voter item)
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

        // DELETE: api/voter/{id}
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
