using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giro : MonoBehaviour {

		public float yaw;
		public float pitch;
		public float roll;
		public float lectura;
		public Vector3 v3To = new Vector3(-90,0,0);
        public static Vector3 v3 = new Vector3(0,0,0);
        public float speed = 50.0f;
        private float timeCount = 0.0f;
		
	// Use this for initialization
	void Start (){
		transform.eulerAngles = v3; 
	}
	
	// Update is called once per frame
	void Update () { 
		//transform.Rotate(Vector3.right*yaw);
		//transform.Rotate(Vector3.up*pitch);
		//lectura=transform.rotation.x;
		v3 = Vector3.Lerp(v3, v3To, Time.deltaTime * speed);
        transform.eulerAngles = v3; 
         
		 
	}
}
