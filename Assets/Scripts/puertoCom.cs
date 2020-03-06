using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class puertoCom : MonoBehaviour
{

	public InputField Port; 
	private string puertoArdu; //variable que le pasaremos al juego tipo "COM4"
	private Transform inputfield;

    // Start is called before the first frame update
    void Start()
    {
		inputfield = transform.Find ("SerialPort");
    }

    // Update is called once per frame
    void Update()
    {
		puertoArdu = Port.text;
    }
}
