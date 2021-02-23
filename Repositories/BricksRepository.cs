using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using morning_challenge_tuesday.Models;

namespace morning_challenge_tuesday.Repositories
{
  public class BricksRepository
  {
    private readonly IDbConnection _db;

    public BricksRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Brick> GetAll()
    {
      string sql = "SELECT * FROM bricks;";
      return _db.Query<Brick>(sql);
    }

    internal Brick GetOne(int id)
    {
      string sql = "SELECT * FROM bricks WHERE id = @id;";
      return _db.QueryFirstOrDefault<Brick>(sql, new { id });
    }

    internal Brick Create(Brick newBrick)
    {
      string sql = @"
      INSERT INTO bricks
      (size, color)
      VALUES
      (@size, @color);
      SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(sql, newBrick);
      newBrick.Id = id;
      return newBrick;
    }

    internal Brick Edit(Brick newBrick)
    {
      string sql = @"
      UPDATE bricks
      SET
        size = @size,
        color = @color
      WHERE id = @Id;
      SELECT * FROM bricks WHERE id = @Id";
      return _db.QueryFirstOrDefault<Brick>(sql, newBrick);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM bricks WHERE id = @Id;";
      _db.Execute(sql, new { id });
    }
  }
}