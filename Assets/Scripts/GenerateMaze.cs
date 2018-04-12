using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMaze : MonoBehaviour
{
	public GameObject blockPrefab;
	int width = 50;
	int depth = 50;
	
	private void Awake ()
	{
		Vector3 offset = new Vector3(width / 2, 0, depth / 2);
		Vector3 v = transform.position - offset;
		for(int w = 0; w < width; w++)
			for(int d = 0; d < depth; d++)
				if(w == 0 || d == 0 || w == width - 1 || d == depth - 1)
					Instantiate(blockPrefab, new Vector3(w + v.x, v.y, d + v.z), Quaternion.identity);
				else if( w < 3 && d < 3)
					continue;
				else if(Random.Range(0,5) < 1)
					Instantiate(blockPrefab, new Vector3(w + v.x, v.y, d + v.z), Quaternion.identity);
	}
}
