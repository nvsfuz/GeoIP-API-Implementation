namespace ApiImplementation
{
	using System;
	using System.Collections.Generic;
	using static System.Console;

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

	public class Triangle : Figure
	{
		public decimal Width { get; }
		public decimal Height { get; }
		public decimal CoordinateX { get; }
		public decimal CoordinateY { get; }

		public Triangle (decimal width, decimal height)
		{
			this.Width = width;
			this.Height = height;
		}

		public override decimal CalculateSquare()
		{
			return this.Width * ((decimal)0.5 * this.Height);
		}
	}

	public class Foo
	{
		public void DoStuff()
		{
			var figures = new List<Figure>();

			var circle = new Circle(20);
			var rectangle = new Rectangle(10, 30);
			var triangle = new Triangle(15, 5);

			figures.Add(circle);
			figures.Add(rectangle);
			figures.Add(triangle);

			Clear();

			decimal summarySquare = 0;

			WriteLine("Square calculations:\n");

			foreach (var figure in figures)
			{
				summarySquare += figure.CalculateSquare();
			}
		}
	}
}