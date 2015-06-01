using UnityEngine;
using System.Collections;

public class IntVector2 {

	public int x, y;
	
	public IntVector2(int x, int y) {
		this.x = x;
		this.y = y;
	}

	public IntVector2() {
		this.x = -1;
		this.y = -1;
	}

	public static implicit operator Vector2(IntVector2 From)
	{
		return new Vector2(From.x, From.y);
	}
	
	public static implicit operator IntVector2(Vector2 From)
	{
		return new IntVector2((int)From.x, (int)From.y);
	}
	 
	public override string ToString()
	{
		return "("+x + " , " + y+")";
	}

	public static IntVector2 operator +(IntVector2 a, IntVector2 b) {
		return new IntVector2(a.x + b.x, a.y + b.y);
	}

	public static IntVector2 operator -(IntVector2 a, IntVector2 b) {
		return new IntVector2(a.x - b.x, a.y - b.y);
	}

	public static IntVector2 operator *(IntVector2 a, IntVector2 b) {
		return new IntVector2(a.x * b.x, a.y * b.y);
	}

	public static IntVector2 operator /(IntVector2 a, IntVector2 b) {
		return new IntVector2(a.x / b.x, a.y / b.y);
	}

	
	public static IntVector2 operator +(IntVector2 a, int b) {
		return new IntVector2(a.x + b, a.y + b);
	}

	public static IntVector2 operator -(IntVector2 a, int b) {
		return new IntVector2(a.x - b, a.y - b);
	}

	public static IntVector2 operator *(IntVector2 a, int b) {
		return new IntVector2(a.x * b, a.y * b);
	}

	public static IntVector2 operator /(IntVector2 a, int b) {
		return new IntVector2(a.x / b, a.y / b);
	}

	public static bool operator ==(IntVector2 a, IntVector2 b) {
		return a.x == b.x && a.y == b.y;
	}

	public static bool operator !=(IntVector2 a, IntVector2 b) {
		return a.x != b.x || a.y != b.y;
	}
}
