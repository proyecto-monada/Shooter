using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPistola : MonoBehaviour
{
	public Vector3 Pospistola;
	public float giroZ;

	private Vector3 imu_origin;



	void Start()
	{
		ComArduino comArdu = GameObject.Find("Com").GetComponent<ComArduino>();
		imu_origin.x = comArdu.imu_x;
		imu_origin.y = 0f;
		imu_origin.z = comArdu.imu_y;


	}

	// Update is called once per frame
	void Update()
	{
		
		ComArduino comArdu = GameObject.Find("Com").GetComponent<ComArduino>();
		//UN EJE
		// transform.position = new Vector3(comArdu.imu_x,0,0);
		//Pospistola = transform.eulerAngles;

		//DOS EJES SIN OFFSETS
		//transform.localRotation.eulerAngles = new Vector3(comArdu.imu_y, 0f, comArdu.imu_x);

		//DOS EJES CON OFFSET Y SIN LOCAL
		//giroZ = comArdu.imu_x*(-1);
		//transform.eulerAngles = new Vector3(comArdu.imu_y - 100, 0f, giroZ);

		//DOS EJES CON OFFSET CON LOCAL
		//giroZ = comArdu.imu_x*(-1);
		//transform.localEulerAngles = new Vector3(comArdu.imu_y - 100, 0f, giroZ);

		//DOS EJES LOCAL Y REFERENCIA INICIAL
		giroZ = comArdu.imu_x*(1);
		transform.localEulerAngles = new Vector3(comArdu.imu_y - imu_origin.y - 90, 0f, giroZ-imu_origin.z);

		Pospistola = transform.eulerAngles;

	}
}