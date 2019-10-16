
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public float daño = 10.0f;
    public float alcance = 100 - 0f;
    public float cadencia = 15.0f;

    public GameObject Impacto;
    public ParticleSystem flash;
    public Camera cam;

    private float tiempo = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && (Time.time >= tiempo))
        {
            Disparo();
            tiempo = Time.time + (1f / cadencia);
        }
    }

    void Disparo()
    {
        flash.Play();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, alcance))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(daño);
            }

            GameObject imp = Instantiate(Impacto, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(imp, 2.0f);
        }
    }

}
