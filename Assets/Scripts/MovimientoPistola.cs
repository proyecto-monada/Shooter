using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPistola : MonoBehaviour
{
	public Vector3 Pospistola;

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		ComArduino comArdu = GameObject.Find("Com").GetComponent<ComArduino>();
		// transform.position = new Vector3(comArdu.imu_x,0,0);
		transform.eulerAngles = new Vector3(270f, 180f, comArdu.imu_x);
		Pospistola = transform.eulerAngles;
	}
}