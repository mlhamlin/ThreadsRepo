using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Allows random selection from a weighted group of type T
public class ProbabilityArray<T> {

	public List<T> values = new List<T>();
	public List<float> weights = new List<float>();

	public void AddValue(T o, float weight = 1){
		values.Add(o);
		weights.Add(weight);
	}

	public float GetSumWeights(){
		float sum = 0;

		foreach(float w in weights){
			sum += w;
		}

		return sum;
	}

	public T GetRandomValue(){
		float rando = Random.Range(0, GetSumWeights());
		float accWeight = 0;

		for(int i = 0; i < values.Count; i++){
			if(weights[i] + accWeight >= rando){
				return values[i];
			}else{
				accWeight += weights[i];
			}
		}

		return default(T);
	}
}