using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class justRotate : MonoBehaviour
{
	public bool canRotate = true;
	public float speed = 180;

	void Update()
	{
		if (canRotate)
			transform.Rotate(speed * Vector3.forward * Time.deltaTime);
	}

	public void rot(bool rotates)
	{
		canRotate = rotates;
	}
}
