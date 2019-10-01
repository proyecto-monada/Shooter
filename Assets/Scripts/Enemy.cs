using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{


public Collider MainColiider;
public Collider[] AllColliders;


    // Start is called before the first frame update
    void Start()
    {

MainCollider = GetComponent<Collider>();
AllColliders = GetComponentsInChildren<Collider>(true);
DoRagdoll(false);
        
    }


public void DoRagdoll(bool isRagdoll){

foreach (var col in AllColliders)
	col.enabled = isRagdoll;
MainCollider.enabled = !isRagdoll;
GetComponent<Rigidbody>().useGravity=!isRagdoll;
GetComponent<Animator>().enabled = !isRagdoll;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
