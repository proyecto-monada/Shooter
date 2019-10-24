
﻿using UnityEngine;
using System;
using System.IO.Ports; //incluimos el namespace Sustem.IO.Ports


public class ComArduino : MonoBehaviour
{
    public string cadena;
    public string[] vec_cadena;
    public string valor;
    public string[] vec_valor;
    public string control;
    public float imu_x;
    public float imu_y;
    public int trigg;
    SerialPort serialPort = new SerialPort("COM5", 115200); //Inicializamos el puerto serie
  
    void Start()
    {

        serialPort.Open(); //Abrimos una nueva conexión de puerto serie
        serialPort.ReadTimeout = 1; //Establecemos el tiempo de espera cuando una operación de lectura no finaliza
    }

    void Update()
    {
        if (serialPort.IsOpen) //comprobamos que el puerto esta abierto
        {
            try //utilizamos el bloque try/catch para detectar una posible excepción.
            {
                /*
                cadena = serialPort.ReadLine(); //leemos una linea del puerto serie y la almacenamos en un string
             //   print(cadena); //printeamos la linea leida para verificar que leemos el dato que manda nuestro Arduino
                vec_cadena = cadena.Split(';'); //Separamos el String leido valiendonos de los # y almacenamos los valores en un array.
                */
              
                    valor = serialPort.ReadLine(); //almacenamos en un string la parte de la cadena que toque
                                                   //      print(valor); //printeamos la linea leida para verificar que leemos el dato que manda nuestro Arduino
                    vec_valor = valor.Split(','); //Separamos el String leido valiendonos de las comas y almacenamos los valores en un array.

                    control = vec_valor[0];
                    if (control.Equals("#imu"))
                    {
                        imu_x = float.Parse(vec_valor[1]);
                        imu_y = float.Parse(vec_valor[2]);
                    }
                    else if (control.Equals("#trigg"))
                    {
                        trigg = int.Parse(vec_valor[1]);
                    
                    }
                    
                    
               
               
            }

            catch
            {

            }

        }

    }

}