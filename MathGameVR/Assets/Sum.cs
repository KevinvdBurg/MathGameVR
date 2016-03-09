using UnityEngine;
using System.Collections;

public class Sum{
	string[] xArray = new string[] { "+", "-", "x" };

	public int Number1 { get; private set; }

	public int Number2 { get; private set; }

	public string X{ get; private set; }

	public int Range { get; private set; }


	public Sum(int range)
	{
		this.Range = range;
		this.Number1 = Random.Range (1, this.Range);
		this.Number2 = Random.Range (1, this.Range);
		int xRand = Random.Range (0, this.xArray.Length);
		this.X = xArray[xRand];
	}

	public override string ToString()
	{
		return this.Number1 + " " + this.X + " " + this.Number2 + " = ";
	}

	public int GetAnswer()
	{
			switch (this.X)
			{
			case "+":
				return (this.Number1 + this.Number2);
				break;
			case "-":
				return (this.Number1 - this.Number2);
				break;
			case "x":
				return (this.Number1 * this.Number2);
				break;
			}
		return int.MinValue;
	}


}
