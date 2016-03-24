using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Allows random selection from a weighted group of type T
public class ProbabilityArray<T> {

	public List<WeightedObject<T>> objects = new List<WeightedObject<T>> ();

	public void AddValue(T o, float weight = 1){
		objects.Add (new WeightedObject<T> (o, weight));
	}

	public float GetSumWeights(){
		float sum = 0;

		foreach(WeightedObject<T> w in objects){
			sum += w.weight;
		}

		return sum;
	}

	public T GetRandomValue(){
		float rando = Random.Range(0, GetSumWeights());
		float accWeight = 0;

		for(int i = 0; i < objects.Count; i++){
			if(objects[i].weight + accWeight >= rando){
				return objects[i].value;
			}else{
				accWeight += objects[i].weight;
			}
		}

		return default(T);
	}
}

public class WeightedObject<T> {
	public T value;
	public float weight;

	public WeightedObject(T v, float w){
		value = v;
		weight = w;
	}
}