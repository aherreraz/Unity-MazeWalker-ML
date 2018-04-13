using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
	public float distanceMoved = 0.0f;
	public GameObject eyes;
	[HideInInspector] public DNA dna;

	private Vector3 startPosition;
    private bool alive = true;
	[SerializeField] private bool seeWall;
	
    void OnCollisionEnter (Collision obj)
    {
    	if (obj.gameObject.tag == "dead")
    		alive = false;
    }
    
	public void Init()
	{
		// dna[0] = movement speed when not seeing a wall
		// dna[1] = turn direction when seeing a wall
        dna = new DNA (2, 360.0f);
		startPosition = transform.position;
	}

	private void Update()
    {
		if(!alive) return;
		seeWall = false;
		RaycastHit hit;
		Debug.DrawRay(eyes.transform.position, eyes.transform.forward * 0.5f, Color.red, 10);
		
		// Using Raycast
		// Raycast(startPosition, direction, hit, maxDistance)
		/*if (Physics.Raycast(eyes.transform.position, eyes.transform.forward, out hit, 0.5f))
		{
			if (hit.collider.gameObject.tag == "wall")
				seeWall = true;
		}*/

		if (Physics.SphereCast(eyes.transform.position, 0.1f, eyes.transform.forward, out hit, 0.5f))
		{
			if (hit.collider.gameObject.tag == "wall")
				seeWall = true;
		}
	}
	private void FixedUpdate()
	{
		if (!alive) return;
		float move = seeWall ? 0 : dna.GetGene(0);
		float turn = seeWall ? dna.GetGene(1) : 0;

		transform.Translate(0, 0, move * 0.03f * Time.deltaTime);
		transform.Rotate(0, turn, 0);
		distanceMoved = Vector3.Distance(startPosition, transform.position);
	}
}


