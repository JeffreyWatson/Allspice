using System;
using System.Collections.Generic;
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

  public class RecipesController : ControllerBase
  {
    private readonly RecipesService _rs;
    private readonly IngredientsService _ins;
    private readonly StepsService _ss;
    private readonly FavoritesService _fs;

    public RecipesController(RecipesService rs, IngredientsService ins, StepsService ss, FavoritesService fs)
    {
      _rs = rs;
      _ins = ins;
      _ss = ss;
      _fs = fs;
    }

    // get all
    [HttpGet]
    public ActionResult<List<Recipe>> Get()
    {
      try
      {
        List<Recipe> recipes = _rs.GetAll();
        return Ok(recipes);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // get by id
    [HttpGet("{id}")]
    public ActionResult<Recipe> Get(int id)
    {
      try
      {
        Recipe recipe = _rs.GetById(id);
        return Ok(recipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //get by id for ingredient
    [HttpGet("{id}/ingredients")]
    public ActionResult<List<Ingredient>> GetIngredients(int id)
    {
      try
      {
        List<Ingredient> ingredients = _ins.GetByRecipeId(id);
        return Ok(ingredients);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}/steps")]
    public ActionResult<List<Step>> GetSteps(int id)
    {
      try
      {
        List<Step> steps = _ss.GetByRecipeId(id);
        return Ok(steps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // create
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipeData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        recipeData.CreatorId = userInfo.Id;
        Recipe newRecipe = _rs.Create(recipeData);
        newRecipe.Creator = userInfo;
        return Ok(newRecipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // edit
    [HttpPut("{id}")]
    [Authorize]

    public async Task<ActionResult<Recipe>> EditAsync(int id, [FromBody] Recipe recipeData)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        recipeData.Id = id;
        recipeData.CreatorId = userInfo.Id;
        Recipe update = _rs.Edit(recipeData);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // delete
    [HttpDelete("{id}")]
    [Authorize]

    public async Task<ActionResult<Recipe>> DeleteAsync(int id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Recipe deletedRecipe = _rs.Delete(id, userInfo.Id);
        return Ok(deletedRecipe);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}