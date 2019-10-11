using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raygun : MonoBehaviour
{		//detecta que con rayo puede haber colision con algo, si es el zombie activa la muerte
		//!!se crea un objeto vacio en la punta del arma!!
    public float shootRate;
    private float m_shootRateTimeStamp;

    public GameObject m_shotPrefab;

    RaycastHit hit;
    float range = 1000.0f;


    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                shootRay();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }

    }

    void shootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range))
        {

 	EnemyController enemy = hit.transform.GetComponent<EnemyController>();

 	if(enemy != null) 
  {
    enemy.die();
   }

            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<shotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 2f);


        }

    }



}
