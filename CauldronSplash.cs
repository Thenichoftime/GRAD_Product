using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronSplash : MonoBehaviour
{
    public AudioSource Splash;

    private void OnTriggerEnter(Collider other)
    {
        Splash.Play();
    }
}
