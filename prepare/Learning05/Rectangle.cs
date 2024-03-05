public class Rectangle : Shape
{
	private double _length;
	private double _width;

	public double Length { get { return _length;} set { _length = value;} }
	public double Width { get { return _width;} set { _width = value;} }
	
	public Rectangle(string color, double length, double width) : base(color)
	{
		Length = length;
		Width = width;
	}

  public override double GetArea()
  {
      return Length * Width;
  }
}