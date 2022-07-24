using System;
using Allspice.Models;
using Allspice.Repositories;

namespace Allspice.Services
{
  public class StepsService
  {
    private readonly StepsRepository _repo;
    private readonly RecipesService _rs;

    public StepsService(StepsRepository repo, RecipesService rs)
    {
      _repo = repo;
      _rs = rs;
    }

    internal Step Create(Step stepData, string userId)
    {
      Recipe found = _rs.GetById(stepData.RecipeId);
      if (found.CreatorId != userId)
      {
        throw new Exception("This is not yours to alter.");
      }
      _repo.Create(stepData);
      return stepData;
    }

    internal Step GetById(int id)
    {
      Step found = _repo.GetById(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Step Edit(Step stepData, string userId)
    {
      Step original = this.GetById(stepData.Id);
      Recipe found = _rs.GetById(original.RecipeId);
      if (found.CreatorId != userId)
      {
        throw new Exception("This is not yours to alter.");
      }
      original.Position = stepData.Position ?? original.Position;
      original.Body = stepData.Body ?? original.Body;
      _repo.Edit(original);
      return original;
    }

    internal Step Delete(int id, string userId)
    {
      Step original = this.GetById(id);
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