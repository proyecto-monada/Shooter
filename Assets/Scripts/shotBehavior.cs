using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotBehavior : MonoBehaviour
{		//este script se aplica a objetos disparables
		//esta basicamente copiado de un asset de github

    public Vector3 m_target;
    public GameObject collisionExplosion;
    public float speed=100;


    // Update is called once per frame
    void Update()
    {
        // transform.position += transform.forward * Time.deltaTime * 300f;// The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;
	

        if (m_target != null)
        {
            if (transform.position == m_target)
            {
                explode();
                return;
				
            }
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }
	
    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }

//aun no se usa la explosion
    void explode()
    {

        if (collisionExplosion  != null) {
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
			
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }


    }

}