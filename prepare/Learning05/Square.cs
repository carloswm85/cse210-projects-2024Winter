public class Square : Shape
{
	private double _side;

	public double Side { get { return _side;} set { _side = value;} }
	
	public Square(string color, double side) : base(color)
	{
		Side = side;
	}

  public override double GetArea()
  {
      return Side * Side;
  }
}