namespace morning_challenge_tuesday.Models
{
  public class Brick
  {
    public Brick()
    {

    }
    public Brick(int size, string color, int id)
    {
      this.Size = size;
      this.Color = color;
      this.Id = id;
    }

    public int Size { get; set; }
    public string Color { get; set; }

    public int Id { get; set; }
  }
}