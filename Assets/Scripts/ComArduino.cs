using UnityEngine;
using System;
using System.IO.Ports; //incluimos el namespace Sustem.IO.Ports


public class ComArduino : MonoBehaviour
{

    public string valor;
    public string[] vec_valor;
    public float dato1;
    public float dato2;
    SerialPort serialPort = new SerialPort("COM5", 9600); //Inicializamos el puerto serie

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

                valor = serialPort.ReadLine(); //leemos una linea del puerto serie y la almacenamos en un string
                print(valor); //printeamos la linea leida para verificar que leemos el dato que manda nuestro Arduino
                vec_valor = valor.Split(','); //Separamos el String leido valiendonos 
                                              //de las comas y almacenamos los valores en un array.
                dato1 = float.Parse(vec_valor[0]);
                dato2 = float.Parse(vec_valor[1]);
            }

            catch
            {

            }

        }

    }

}