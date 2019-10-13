using System.Collections;
using UnityEngine;

public class Camara_1 : MonoBehaviour
{
    public GameObject player;    
    public float sensibilidad = 6.0f;

    private Transform PlayerBody;
    private float posicion;
   

    private void Awake()
    {
        LockCursor();
        posicion = 0.0f;
        
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void GiroMaximo(float aux)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = aux;
        transform.eulerAngles = eulerRotation;
    }

    // Update is called once per frame
    void Update()
    {
       

        float giroY = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float giroX = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;
        posicion += giroX;

        if (posicion > 90.0f)
        {
            giroX = 0.0f;
            posicion = 90.0f;
            GiroMaximo(270.0f);
        }
        else if (posicion < -90.0f)
        {
            giroX = 0.0f;
            posicion = -90.0f;
            GiroMaximo(90.0f);
        }


        transform.Rotate(Vector3.left * giroX);
        PlayerBody.Rotate(Vector3.up * giroY);
        
    }
}
