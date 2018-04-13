using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA
{
	private List<float> genes = new List<float>();
	private int dnaLength = 0;
	private float maxValues = 0;

	public DNA(int l, float v)
	{
		dnaLength = l;
		maxValues = v;
		SetRandom();
	}

	public void SetRandom()
	{
		genes.Clear();
		for(int i = 0; i < dnaLength; i++)
			genes.Add(Random.Range(0, maxValues));
	}

	public void Combine(DNA d1, DNA d2, float mutationChance)
	{
		for(int i = 0; i < dnaLength; i++)
		{
			if (Random.Range(0.0f, 1.0f) < mutationChance)
				genes[i] = Random.Range(0, maxValues);
			else
				genes[i] = (i < dnaLength / 2) ? d1.genes[i] : d2.genes[i];
		}
	}
	public void SetGene(int pos, float value)
	{
		genes[pos] = value;
	}
	public float GetGene(int pos)
	{
		return genes[pos];
	}
}
