using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteAudio : MonoBehaviour
{

    public GameObject AanetpoisNappi;
    public GameObject AanetpaalleNappi;

 



    // Start is called before the first frame update
    void Start()
    {
        AanetpoisNappi.SetActive(true);
        AanetpaalleNappi.SetActive(false);
    }

    public void AanetPoisNappiKlikattu()
    {
        AudioListener.volume = 0;
        AanetpoisNappi.SetActive(false);
        AanetpaalleNappi.SetActive(true);
    }

    public void AanetPaalleNappiKlikattu()
    {
        AudioListener.volume = 1;
        AanetpoisNappi.SetActive(true);
        AanetpaalleNappi.SetActive(false);
    }

    public void SuljeNappiKlikattu()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
