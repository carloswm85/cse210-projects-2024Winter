public class Circle : Shape
{
	private double _radius;

	public double Radius { get { return _radius;} set { _radius = value;} }
	
	public Circle(string color, double radius) : base(color)
	{
		Radius = radius;
	}

  public override double GetArea()
  {
      return Radius * Radius * Math.PI;
  }
}