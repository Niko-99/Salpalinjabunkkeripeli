using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMovement : MonoBehaviour
{

    Rigidbody rb;

    public GameObject hahmo;
    public GameObject Kamera1;

    //public Button forward;
    //public Button backward;
    //public Button turnleft;
    //public Button turnright;
    //public Button lookup;
    //public Button lookdown;

    bool liike =  false;
    bool moveLeft;
    bool moveRight;
    bool moveForward;
    bool moveBackward;
    bool lookUp;
    bool lookDown;
    float horizontalMove;
    float verticalMove;
    public float nopeus2 = 300;
    public float rotateNopeus = 20;
    private Touch kosketus;
    private float kosketusloppu;
    // Start is called before the first frame update
    void Start()
    {
        //forward.onClick.AddListener(eteen);
        //backward.onClick.AddListener(taakse);
        //turnleft.onClick.AddListener(vasen);
        //turnright.onClick.AddListener(oikea);
        //lookup.onClick.AddListener(ylos);
        //lookdown.onClick.AddListener(alas);
        rb = GetComponent<Rigidbody>();
    }

    public void PointerDownLeft()
    {
        
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    public void PointerDownForward()
    {
        moveForward = true;
    }

    public void PointerUpForward()
    {
        moveForward = false;
    }

    public void PointerDownBackward()
    {
        moveBackward = true;
    }

    public void PointerUpBackward()
    {
        moveBackward = false;
    }

    public void PointerDownLookUp()
    {
        lookUp = true;
    }

    public void PointerUpLookUp()
    {
        lookUp = false;
    }

    public void PointerDownLookDown()
    {
        lookDown = true;
    }

    public void PointerUpLookDown()
    {
        lookDown = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void eteen()
    {
        hahmo.transform.Translate(Vector3.forward * nopeus2 * Time.deltaTime);
    }

    void taakse()
    {
        hahmo.transform.Translate(Vector3.back * nopeus2 * Time.deltaTime);
    }

    void vasen()
    {
        hahmo.transform.Rotate(Vector3.up, -5);
    }

    void oikea()
    {
        hahmo.transform.Rotate(Vector3.up, 5);
    }

    void ylos()
    {
        Kamera1.transform.Rotate(Vector3.right, -2);
    }

    void alas()
    {
        Kamera1.transform.Rotate(Vector3.right, 2);
    }

    void Movement()
    {
        if (moveLeft   )
        {
            hahmo.transform.Rotate(Vector3.up, -2);
        }
        else if (moveRight )  
        {
           hahmo.transform.Rotate(Vector3.up, 2);
       }
        else 
      {
           horizontalMove = 0;
        }
    if (moveForward )
    {
        hahmo.transform.Translate(Vector3.forward * nopeus2 * Time.deltaTime);
       }
       if (moveBackward )
        {
            hahmo.transform.Translate(Vector3.back * nopeus2 * Time.deltaTime);
        }
        else
        {
            verticalMove = 0;
        }
        if (lookUp )
        {
            Kamera1.transform.Rotate(Vector3.right, -1);
       }
        else if (lookDown )
        {
            Kamera1.transform.Rotate(Vector3.right, 1);
        }
        else
        {
            horizontalMove = 0;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(horizontalMove * Time.deltaTime, rb.velocity.y, verticalMove * Time.deltaTime);
        Movement();
    }
}