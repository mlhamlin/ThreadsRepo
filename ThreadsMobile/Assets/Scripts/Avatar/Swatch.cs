using UnityEngine;
using System.Collections;

public class Swatch {

	public float r;
	public float g;
	public float b;
	public float a;

	public int weight;

	public Color GetColor(){
		return new Color(r/255, g/255, b/255, a/255);
	}

	public static Swatch GetDefaultSwatch(){
		Swatch sw = new Swatch();
		sw.r = 255;
		sw.g = 255;
		sw.b = 255;
		sw.a = 255;
		sw.weight = 1;

		return sw;
	}
}
