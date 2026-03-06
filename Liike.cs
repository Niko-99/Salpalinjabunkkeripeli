using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.Collections;


public class Liike : MonoBehaviour
{

   public AudioSource footstepOutside;
    public AudioSource footstepInside;
    public AudioSource footstepGrass;
    public AudioSource AmbientAudio;
    public AudioSource SadeAudio;
    public AudioListener audio1;
    public bool sisalla;
    public bool ulkona;
    public bool nurmi;

    public GameObject camera1;
    
    private bool musicFadeOutEnabled = false;
    private bool MusicFadeinEnabled = false;

    public GameObject Canvas;

    private Vector3 alku;

    [SerializeField] private SaaVaihto saaVaihto;

    //public ControllerSampleInputActions inputActions;
    
    //public ActionBasedController Rightcontroller;

    float audiovolume;

    bool pressed;

    public float RotationSensitivity = 35.0f;
    public float minAngle = -45.0f;
    public float maxAngle = 45.0f;

    float yrotate = 0.0f;

    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    void Start()
    {
       ulkona = true;
        sisalla = false;
        nurmi = false;
        
        audio1 = GetComponent<AudioListener>();

        //saaVaihto = FindObjectOfType<SaaVaihto>();

        alku = this.transform.position;
    }

    // Update is called once per frame  

    public float nopeus;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag  ("Sisalla"))
        {
            sisalla = true;
            ulkona = false;
            nurmi=false;
            //FadeOutAudio();
            if (saaVaihto.sade == true)
            {
                SadeAudio.volume = 0.1f;
            }
        }
        else if (other.gameObject.CompareTag ("Ulkona"))
        {
            ulkona = true;
            sisalla = false;
            nurmi= false;
            //FadeinAudio();
            if (saaVaihto.sade == true)
            {
                SadeAudio.volume = 0.5f;
            }

        }
        else if (other.gameObject.CompareTag("Nurmikko"))
        {
            ulkona = false;
            sisalla = false;
            nurmi = true;

        }

        else if (other.gameObject.CompareTag("Respawn"))
        {
            this.transform.position = alku;

        }

    }
    public void FadeinAudio()
    {
        MusicFadeinEnabled = true;
    }
   

    public void FadeOutAudio()
    {
        musicFadeOutEnabled = true;
    }

  
    //public GameObject seina;
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            
            this.transform.Translate(Vector3.forward * nopeus * Time.deltaTime);
         
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
           
            this.transform.Translate(Vector3.back * nopeus * Time.deltaTime);
           
            
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            
            this.transform.Rotate(Vector3.up, -5);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(Vector3.up, 5);
        }

        if (Input.GetKey(KeyCode.W))
        {
            camera1.transform.Rotate(Vector3.right, -2);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            camera1.transform.Rotate(Vector3.right, 2);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

      



 


        //if (inputActions.LeftController.JoystickClick && CommonUsages.SecondaryTrigger)
        //{ }



        //if (pressed)
        //{
        //    this.transform.Translate(Vector3.forward * nopeus * Time.deltaTime);
        //}

        //if (Input.GetAxis("Horizontal") < 0) ismoving = true;
        //if (nopeus > 0) ismoving = true;
        // else ismoving = false;
        // if (ismoving && !audioSource.isPlaying) audioSource.Play();
        // if (!ismoving) audioSource.Stop();



        //void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.tag == "seina1") ;
        //    {
        //        nopeus = 0;
        //    }

        //}



    }

        private void Update()
    {
        if (Input.GetKey(KeyCode.H))
        {
            if (Canvas.activeSelf == true)
            {
                Canvas.SetActive(false);
            }
            else if (Canvas.activeSelf == false)
            {
                Canvas.SetActive(true);
            }
        }

        if (Input.GetKey(KeyCode.M))
        {
            if (AudioListener.volume == 1)
            {
                AudioListener.volume = 0;
            }
            else if (AudioListener.volume == 0)
            {
                AudioListener.volume = 1;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            if (sisalla == true && ulkona == false && nurmi == false)
            {
                footstepOutside.enabled = false;
                footstepInside.enabled = true;
                footstepGrass.enabled = false;
                AmbientAudio.enabled = true;
                AmbientAudio.volume = 0.1f;
                //FadeOutAudio();
            }
            else if (ulkona == true && sisalla == false && nurmi == false)
            {
                footstepOutside.enabled = true;
                footstepInside.enabled = false;
                footstepGrass.enabled = false;
                AmbientAudio.enabled = true;
                AmbientAudio.volume = 0.75f;
                //FadeinAudio();
            }

            //else if (ulkona == true && sisalla == false && nurmi == false && )
            //{
            //    footstepOutside.enabled = true;
            //    footstepInside.enabled = false;
            //    footstepGrass.enabled = false;
            //    SadeAudio.enabled = true;
            //    SadeAudio.volume = 0.75f;

            //}
            else if (nurmi == true && ulkona == false && sisalla == false)
            {
                footstepOutside.enabled = false;
                footstepInside.enabled = false;
                footstepGrass.enabled = true;
                AmbientAudio.enabled = true;
    
                
            }

        }

        else
        {
            footstepOutside.enabled = false;
            footstepInside.enabled = false;
            footstepGrass.enabled = false;
        }

        if (musicFadeOutEnabled)
        {
            if (AmbientAudio.volume <= 0.1f)
            {
                
                musicFadeOutEnabled = false;
           }
           else
            {
               float newVolume = AmbientAudio.volume - (0.35f * Time.deltaTime);
                float newVolumeSade = SadeAudio.volume - (0.35f * Time.deltaTime);
               if (newVolume < 0f)
                {
                    newVolume = 0f;
               }
                AmbientAudio.volume = newVolume;
                if (newVolumeSade < 0f)
               {
                    newVolumeSade = 0f;
                }
                SadeAudio.volume = newVolumeSade;
            }

            if (MusicFadeinEnabled)
            {
                float newVolume2 = AmbientAudio.volume + (0.24f * Time.deltaTime);
                if (newVolume2 == 0.75f)
                {

                    MusicFadeinEnabled = false;
                }
               
               


            //    AmbientAudio.volume = newVolume2;

            //    //if (SadeAudio.volume <= 0.75f)
            //    //{

            //    //    MusicFadeinEnabled = false;
            //    //}

            //    //float newVolumeSade2 = SadeAudio.volume + (0.24f * Time.deltaTime);
            //    //SadeAudio.volume = newVolumeSade2;

            }

         
        }
    }
}

