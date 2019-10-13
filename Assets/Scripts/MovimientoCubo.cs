using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCubo : MonoBehaviour
{
    public Vector3 Poscubo;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ComArduino comArdu = GameObject.Find("Com").GetComponent<ComArduino>();
        transform.position = new Vector3(comArdu.dato1,0,0);
        Poscubo = transform.position;
    }
}
