﻿using System.Collections;
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
        // transform.position = new Vector3(comArdu.imu_x,0,0);
        transform.eulerAngles = new Vector3(0f, comArdu.imu_x, 0f);
        Poscubo = transform.eulerAngles;
    }
}