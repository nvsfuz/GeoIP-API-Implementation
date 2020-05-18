namespace ApiImplementation
{
	using System;
	using System.Collections.Generic;

	public abstract class Figure
	{
		public abstract decimal CalculateSquare();
	}

	public class Circle : Figure
	{
		public decimal Radius { get; }

		public Circle(decimal radius)
		{
			this.Radius = radius;
		}
		public override decimal CalculateSquare()
		{
			return (decimal)(Math.PI * Math.Sqrt((double)this.Radius));
		}
	}

	public class Rectangle : Figure
	{
		public decimal A { get; }
		public decimal B { get; }

		public Rectangle(decimal a, decimal b)
		{
			this.A = a;
			this.B = b;
		}

		public override decimal CalculateSquare()
		{
			return this.A * this.B;
		}
	}


	public class Foo
	{
		public void DoStuff()
		{
			var figures = new List<Figure>();

			var circle = new Circle(20);
			var rectangle = new Rectangle(10, 30);

			figures.Add(circle);
			figures.Add(rectangle);

			foreach (var figure in figures)
			{
				figure.CalculateSquare();
			}
		}
	}
}