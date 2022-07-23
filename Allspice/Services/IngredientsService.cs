using System;
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
      Recipe found = _rs.GetById(ingredientData.RecipeId);
      if (found.CreatorId != userId)
      {
        throw new Exception("Invalid Id");
      }
      _repo.Create(ingredientData);
      return (ingredientData);

    }

    internal Ingredient GetById(int id)
    {
      Ingredient found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal List<Ingredient> GetByRecipeId(int recipeId)
    {
      _rs.GetById(recipeId);
      return _repo.GetByRecipeId(recipeId);
    }

    internal Ingredient Edit(Ingredient ingredientData, string userId)
    {
      Ingredient original = this.GetById(ingredientData.Id);
      Recipe found = _rs.GetById(original.RecipeId);
      if (found.CreatorId != userId)
      {
        throw new Exception("This is not yours to alter.");
      }
      original.Name = ingredientData.Name ?? original.Name;
      original.Quantity = ingredientData.Quantity ?? original.Quantity;
      _repo.Edit(original);
      return original;
    }

    internal Ingredient Delete(int id, string userId)
    {
      Ingredient original = this.GetById(id);
      Recipe found = _rs.GetById(original.RecipeId);
      if (found.CreatorId != userId)
      {
        throw new Exception("This is not your to alter.");
      }
      _repo.Delete(original);
      return original;
    }
  }
}