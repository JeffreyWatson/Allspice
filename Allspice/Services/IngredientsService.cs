using System.Collections.Generic;
using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
  public class IngredientsService
  {
    private readonly RecipesService _rs;
    private readonly IngredientsRepository _repo;

    public IngredientsService(RecipesService rs, IngredientsRepository repo)
    {
      _rs = rs;
      _repo = repo;
    }

    internal Ingredient Create(Ingredient ingredientData, string userId)
    {
      // NOTE this is where the 1 to many comes into play
      _rs.GetRecId(ingredientData.RecipeId, userId);
      return _repo.Create(ingredientData);
    }

    internal List<Ingredient> GetByRecipeId(int recipeId, string userId)
    {
      // NOTE here too
      _rs.GetRecId(recipeId, userId);
      return _repo.GetByRecipeId(recipeId);
    }

    // internal Ingredient Delete(int id)
    // {
    //   Ingredient original = GetById(id);
    //   _repo.Delete(id);
    //   return original;
    // }
  }
}