using UnityEngine;

public class JugadorMovil : MonoBehaviour
{
    public float velocidad = 8f;
    public float sensibilidad = 2f;
    public CharacterController controller;
    public Transform camara;
    float rotX = 0;
    Vector2 inicioIzq, inicioDer;
    bool tocandoIzq = false, tocandoDer = false;
    int idIzq = -1, idDer = -1;
    Vector2 moveTouch = Vector2.zero;

    void Start()
    {
        if(controller == null) controller = GetComponent<CharacterController>();
        if(camara == null) camara = Camera.main.transform;
    }

    void Update()
    {
        float h = 0, v = 0;
        float mouseX = 0, mouseY = 0;

        // --- PC: Teclado + Mouse ---
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X") * sensibilidad;
        mouseY = Input.GetAxis("Mouse Y") * sensibilidad;

        // --- CELULAR: Táctil ---
        // Dedo izquierdo = moverse, dedo derecho = mirar
        for(int i=0; i<Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);
            if(t.position.x < Screen.width * 0.5f)
            {
                if(t.phase == TouchPhase.Began) { idIzq = t.fingerId; inicioIzq = t.position; }
                if(t.fingerId == idIzq)
                {
                    if(t.phase == TouchPhase.Moved)
                    {
                        Vector2 delta = (t.position - inicioIzq) / 100f;
                        h = Mathf.Clamp(delta.x, -1, 1);
                        v = Mathf.Clamp(delta.y, -1, 1);
                    }
                    if(t.phase == TouchPhase.Ended) { idIzq = -1; h=0; v=0; }
                }
            }
            else
            {
                if(t.phase == TouchPhase.Began) { idDer = t.fingerId; inicioDer = t.position; }
                if(t.fingerId == idDer)
                {
                    if(t.phase == TouchPhase.Moved)
                    {
                        Vector2 delta = t.deltaPosition;
                        mouseX = delta.x * sensibilidad * 0.1f;
                        mouseY = delta.y * sensibilidad * 0.1f;
                    }
                    if(t.phase == TouchPhase.Ended) idDer = -1;
                }
            }
        }

        rotX -= mouseY;
        rotX = Mathf.Clamp(rotX, -80, 80);
        camara.localRotation = Quaternion.Euler(rotX, 0, 0);
        transform.Rotate(Vector3.up * mouseX);

        Vector3 mov = transform.right * h + transform.forward * v;
        controller.Move(mov * velocidad * Time.deltaTime);
        controller.Move(Vector3.down * 9.8f * Time.deltaTime);
    }
}