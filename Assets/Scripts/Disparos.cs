using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparos : MonoBehaviour
{
    public bool IsAimed;
    public Vector3 Offset;
    public Vector3 VectorPistola;
    public Vector3 Canon_Test;

    // Start is called before the first frame update
    void Start()
    {
        Offset.Set(0.1f, 0.1f, 0.1f);
        VectorPistola = transform.position - GameObject.Find("Arma").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Canon_Test = Canon.canon;
        VectorPistola = transform.position - GameObject.Find("Arma").transform.position;
        VectorPistola.Normalize();
        Apuntado();
    }

    void Apuntado()
    {
        var dx = VectorPistola.x - Canon.canon.x;
        var dy = VectorPistola.y - Canon.canon.y;
        var dz = VectorPistola.z - Canon.canon.z;
        if ((Mathf.Abs(dx) > Offset.x) && (Mathf.Abs(dy) > Offset.y) && (Mathf.Abs(dz) > Offset.z))
            IsAimed = false;
        else
            IsAimed = true;
    }
}
