<<<<<<< HEAD
=======
/*<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> fe7221612b3742f41510e876eeb0fc54f46f7f78
*/
>>>>>>> a65dd8b082a8ed31179da91d2b308892685da4bc
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
<<<<<<< HEAD
=======
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
>>>>>>> a65dd8b082a8ed31179da91d2b308892685da4bc
