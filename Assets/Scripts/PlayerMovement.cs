using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    public float velocidad = 6.0f;
    public float salto = 8.0f;


    [SerializeField] private AnimationCurve Caida;
    [SerializeField] private KeyCode jumpkey;

    private Vector3 moveDirection = Vector3.zero;
    

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        float ejeY = Input.GetAxis("Vertical") * velocidad;
        float ejeX = Input.GetAxis("Horizontal") * velocidad;

        Vector3 MovVertical = transform.forward * ejeY;
        Vector3 MovHorizontal = transform.right * ejeX;
                 
            characterController.SimpleMove(MovVertical + MovHorizontal);

        InputSalto();

    }

    void InputSalto()
    {
        if (Input.GetKeyDown(jumpkey) && characterController.isGrounded)
        {
            StartCoroutine(Salto());
        }
    }

    IEnumerator Salto()
    {
        float AirTime = 0.0f;
        characterController.slopeLimit = 90.0f;
        do
        {
            float FuerzaSalto = Caida.Evaluate(AirTime);
            characterController.Move(Vector3.up * FuerzaSalto * salto * Time.deltaTime);
            AirTime += Time.deltaTime;

            yield return null;
        } while (!characterController.isGrounded && characterController.collisionFlags != CollisionFlags.Above);

        characterController.slopeLimit = 45.0f;

    }

}
