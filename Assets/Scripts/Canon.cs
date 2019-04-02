using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public Vector3 canon;
    public Vector3 canon0;
    public Vector3 Mat1;
    public Vector3 Mat2;
    public Vector3 Mat3;

    /*  PARA EL X:
     *  
     *  [   1   0   0   ]
     *  [   0   cos -sen]
     *  [   0   sen cos ]
     * 
     *  PARA EL Y:
     *  
     *  [   cos  0   sen]
     *  [   0    1   0  ]
     *  [   -sen 0   cos]
     *  
     *  PARA EL Z:
     *  
     *  [   cos -sen   0]
     *  [   sen cos    0]
     *  [   0   0      1]  
     *  
     *  PRODUCTO DE LAS 3:
     *  
     *  [                        cos(y)*cos(z),                       -cos(y)*sin(z),         sin(y)]
	 *	[ cos(x)*sin(z) + cos(z)*sin(x)*sin(y), cos(x)*cos(z) - sin(x)*sin(y)*sin(z), -cos(y)*sin(x)]
	 *	[ sin(x)*sin(z) - cos(x)*cos(z)*sin(y), cos(z)*sin(x) + cos(x)*sin(y)*sin(z),  cos(x)*cos(y)]   
     */

    // Start is called before the first frame update
    void Start()
    {
        canon = transform.position;
        canon0 = canon;
    }

    // Update is called once per frame
    void Update()
    {
        //Construimos los vectores fila de la matriz producto de las 3 rotaciones.
        Mat1.Set(
            Mathf.Cos(giro.v3.y)*Mathf.Cos(giro.v3.z), -Mathf.Cos(giro.v3.y)*Mathf.Sin(giro.v3.z), Mathf.Sin(giro.v3.y)
            );
        Mat2.Set(
            Mathf.Cos(giro.v3.x)*Mathf.Sin(giro.v3.z) + Mathf.Cos(giro.v3.z)*Mathf.Sin(giro.v3.x)*Mathf.Sin(giro.v3.y),
            Mathf.Cos(giro.v3.x)*Mathf.Cos(giro.v3.z) - Mathf.Sin(giro.v3.x)*Mathf.Sin(giro.v3.y)*Mathf.Sin(giro.v3.z),
            -Mathf.Cos(giro.v3.y)* Mathf.Sin(giro.v3.x)
            );
        Mat3.Set(
            Mathf.Sin(giro.v3.x)*Mathf.Sin(giro.v3.z) - Mathf.Cos(giro.v3.x)*Mathf.Cos(giro.v3.z)*Mathf.Sin(giro.v3.y),
            Mathf.Cos(giro.v3.z)*Mathf.Sin(giro.v3.x) + Mathf.Cos(giro.v3.x)*Mathf.Sin(giro.v3.y)*Mathf.Sin(giro.v3.z),
            Mathf.Cos(giro.v3.x)*Mathf.Cos(giro.v3.y)
            );

        //La orientacion del canon es el producto de la orient inicial canon0 por la matriz de rotacion
        canon.Set( Vector3.Dot(Mat1, canon0), Vector3.Dot(Mat2, canon0), Vector3.Dot(Mat3, canon0) );
    }
}
