using System;
using System.Collections.Generic;
using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
  public class RecipesService
  {
    private readonly RecipesRepository _repo;
    public RecipesService(RecipesRepository repo)
    {
      _repo = repo;
    }

    internal List<Recipe> GetAll()
    {
      return _repo.Get();
    }

    internal Recipe GetById(int recipeId)
    {
      Recipe found = _repo.GetById(recipeId);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Recipe Create(Recipe recipeData)
    {
      return _repo.Create(recipeData);
    }

    internal Recipe Edit(Recipe recipeData)
    {
      Recipe original = GetById(recipeData.Id);
      if (recipeData.CreatorId != original.CreatorId)
      {
        throw new Exception("This is not yours");
      }
      original.Picture = recipeData.Picture ?? original.Picture;
      original.Title = recipeData.Title ?? original.Title;
      original.Subtitle = recipeData.Subtitle ?? original.Subtitle;
      original.Category = recipeData.Category ?? original.Category;

      _repo.Edit(original);
      return original;
    }

    internal Recipe Delete(int id, string userId)
    {
      Recipe original = GetById(id);
      _repo.Delete(id);
      return original;
    }

    internal List<Recipe> GetFavoriteRecipes(string id)
    {
      return _repo.GetFavoriteRecipes(id);
    }
  }
}