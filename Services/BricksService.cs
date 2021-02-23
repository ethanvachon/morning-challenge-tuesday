using System;
using System.Collections.Generic;
using morning_challenge_tuesday.Models;
using morning_challenge_tuesday.Repositories;

namespace morning_challenge_tuesday.Services
{
  public class BricksService
  {

    private readonly BricksRepository _repo;

    public BricksService(BricksRepository repo)
    {
      _repo = repo;
    }

    internal IEnumerable<Brick> GetAll()
    {
      return _repo.GetAll();
    }

    internal Brick GetOne(int id)
    {
      Brick brick = _repo.GetOne(id);
      if (brick == null)
      {
        throw new Exception("invalid id");
      }
      return brick;
    }

    internal Brick Create(Brick newBrick)
    {
      return _repo.Create(newBrick);
    }

    internal Brick Edit(Brick newBrick)
    {
      return _repo.Edit(newBrick);
    }

    internal string Delete(int id)
    {
      _repo.Delete(id);
      return ("deleted");
    }
  }
}