public abstract class Shape {
	private string _color = "No color";

	public string Color { set { _color = value; } }

	public Shape(string color)
	{
		Color = color;
	}

	public virtual string GetColor() {
		return _color;
	}

	public abstract double GetArea();
}