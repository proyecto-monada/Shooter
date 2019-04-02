using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboLed : MonoBehaviour {

    public ArduinoConnector serial;
    private float posx;
    public string pwm;

    // Use this for initialization
    void Start () {
        serial.Open();
	}
	
	// Update is called once per frame
	void Update () {
        posx = GameObject.Find("Cube").transform.position.x;
        pwm = posx.ToString();
        serial.WriteToArduino("PWM");
        serial.WriteToArduino(pwm);
    }
}
