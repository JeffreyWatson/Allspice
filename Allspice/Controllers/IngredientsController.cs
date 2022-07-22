using System;
using System.Threading.Tasks;
using Allspice.Models;
using Allspice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Allspice.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  [Authorize]
  public class IngredientsController : ControllerBase
  {
    private readonly IngredientsService _ins;

    public IngredientsController(IngredientsService ins)
    {
      _ins = ins;
    }

    // get by recipe id

    // create
    [HttpPost]

    public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Ingredient ingredient = _ins.Create(ingredientData, userInfo.Id);
        return Ok(ingredient);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // delete
    // [HttpDelete("{id}")]
    // [Authorize]

    // public async Task<ActionResult<Ingredient>> DeleteAsync(int id)
    // {
    //   try
    //   {
    //     Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
    //     Ingredient deletedIngredient = _ins.Delete(id, userInfo.Id);
    //     return Ok(deletedIngredient);
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
  }
}
