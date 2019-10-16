/*<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> fe7221612b3742f41510e876eeb0fc54f46f7f78
*/
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
        transform.position = new Vector3(comArdu.dato1,0,0);
        Poscubo = transform.position;
    }
}
/*<<<<<<< HEAD
=======
=======
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
        transform.position = new Vector3(comArdu.dato1,0,0);
        Poscubo = transform.position;
    }
}
>>>>>>> cf512e1bcec256c971526caf826a03282bb7499f
>>>>>>> fe7221612b3742f41510e876eeb0fc54f46f7f78
*/
