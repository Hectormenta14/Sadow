using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement_cc : MonoBehaviour
{
    public float speed, runningSpeed, rotationSpeed, gravityScale, jumpForce; // crear variables para el editor
    private float yVelocity = 0, currentSpeed; //aqui se va a aguardar la gravedad
    private Vector3 auxMovementVector;
    private CharacterController characterController; // no tiene rigitbody asi q todo en update

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        gravityScale = Mathf.Abs(gravityScale);
    }

    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift);
        float mouseX = Input.GetAxis("Mouse X");
        bool jumpPressed = Input.GetKey(KeyCode.Space);
        Jump(jumpPressed); // se añade la variable por que no esta declarada en el public class
        Movement(x, z, shiftPressed); //metodo de movimiento 
        RotatePlayer(mouseX);
    }
    void Jump(bool jumpPressed) // se añade el bool o lo que toque por que las variables solo estan declaradas en el update
    {
        if (jumpPressed && characterController.isGrounded)
        {
            yVelocity = 0;
            yVelocity += Mathf.Sqrt(jumpForce * 3 * gravityScale); // por 3 para que no haya que poner numeros altisimos para que salte y la raiz cuadrada suaviza el salto 
        }
    }
    void Movement(float x, float z, bool shiftPressed) //parametros buleanos
    {
        if (shiftPressed) // que corra cuendo le sas a shift
        {
            currentSpeed = runningSpeed;
        }
        else
        {
            currentSpeed = speed;
        }
        Vector3 movementVector = transform.forward * currentSpeed * z + transform.right * currentSpeed * x; // vector de movimiento
        auxMovementVector = movementVector;
        if (!characterController.isGrounded)
        {
            yVelocity -= gravityScale; // le resta la gravedad si no estamos en el suelo 
        }
        yVelocity -= gravityScale; // le restamos para que vaya para abajo 
        movementVector.y = yVelocity; //establecemos las y que esta relacionada con la gravedad

        movementVector *= Time.deltaTime; // se usa cuando no hay fisica y se usa el deltatime para que se mueva a la misma velocidad en todos los pcs
        if (x != 0 || z != 0) // codigo caca, borrar en el futuro
            characterController.Move(movementVector); //metodo que tiene el character controller para mover el objeto asignado
    }
    public Vector3 GetMovementVector()
    {
        return auxMovementVector;
    } //no recalcular el vector de movimeinto otra vez
    void RotatePlayer(float mouseX)
    {

        Vector3 rotation = new Vector3(0, mouseX, 0) * rotationSpeed * Time.deltaTime; // gira en el eje Y -> mouseX
        transform.Rotate(rotation); //rota en la direccion en la que está / quaterniones/
        // si quiero que un objeto rote automaticamente solo ponemos una velocidad constante -> Vector3 rotation = new Vector3(0, 5, 0) * Time.deltaTime;
        // si quiero que quire en cualquier eje porngo el mouseX en la coordenada -> (mouseX, 0, 0) en x, (0, 0, mouseX) en z
    }
}
