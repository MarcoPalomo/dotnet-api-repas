using mornaloRepas.Models;
using mornaloRepas.Services;
using Microsoft.AspNetCore.Mvc;

namespace mornaloRepas.Controllers;

[ApiController]
[Route("[controller]")]
public class RepasController : ControllerBase
{
    public RepasController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Repas>> GetAll() =>
    RepasService.GetAll();

    // GET by Id action

    [HttpGet("{id}")]
    public ActionResult<Repas> Get(int id)
    {
        var repas = RepasService.Get(id);
    
        if(repas == null)
            return NotFound();
    
        return repas;
    }

    // POST action

    [HttpPost]
    public IActionResult Create(Repas repas)
    {            
        RepasService.Add(repas);
        return CreatedAtAction(nameof(Get), new { id = repas.Id }, repas);
    }

    // PUT action

    [HttpPut("{id}")]
    public IActionResult Update(int id, Repas repas)
    {
        if (id != repas.Id)
        return BadRequest();
               
        var existingRepas = RepasService.Get(id);
        if(existingRepas is null)
            return NotFound();
       
        RepasService.Update(repas);           
       
        return NoContent();
    }

    // DELETE action

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = RepasService.Get(id);
   
        if (pizza is null)
            return NotFound();
           
        RepasService.Delete(id);
       
        return NoContent();
    }
}
