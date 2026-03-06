using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaaVaihto : MonoBehaviour
{
    public Material selkeaSkybox;
    public Material sadeSkybox;
    public GameObject sadeParticle;
    public AudioSource tuuliAudio;
    public AudioSource sadeAudio;
    public bool selkea;
    public bool sade;
    public float saaVaihtoAika = 480;
    public float saaVaihtoAika2;
    public bool ajastinPaalla = false;
    public bool ajastinPaalla2 = false;

    public int SaaID;

    // Start is called before the first frame update
    void Start()
    {
        selkea = true;
        sade = false;
        ajastinPaalla = true;
        ajastinPaalla2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ajastinPaalla == true && ajastinPaalla2 == false)
        {
            if (saaVaihtoAika > 0)
            {
                saaVaihtoAika -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                saaVaihtoAika = 0;
                saaVaihtoAika2 = 180;
                ajastinPaalla2 = true;
                ajastinPaalla = false;

                selkea = false;
                sade = true;
            }
        }
            else if (ajastinPaalla2 == true && ajastinPaalla == false)
            {
                if (saaVaihtoAika2 > 0)
                {
                    saaVaihtoAika2 -= Time.deltaTime;
                }
                else
                {
                    Debug.Log("Time has run out again!");
                    saaVaihtoAika2 = 0;
                    saaVaihtoAika = 480;
                    ajastinPaalla2 = false;
                    ajastinPaalla = true;
                  
                    selkea = true;
                    sade = false;
                }
            }
                if (selkea)
                {
                    RenderSettings.skybox = selkeaSkybox;
                    sadeParticle.SetActive(false);
                    tuuliAudio.enabled = true;
                    sadeAudio.enabled = false;
                    SaaID = 1;
                }
                else if (sade)
                {
                    RenderSettings.skybox = sadeSkybox;
                    sadeParticle.SetActive(true);
                    tuuliAudio.enabled = false;
                    sadeAudio.enabled = true;
                    SaaID = 2;

                }
            
            
        }
        }

    

