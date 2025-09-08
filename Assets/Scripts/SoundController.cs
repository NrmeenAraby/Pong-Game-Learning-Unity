using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioSource ballSound;
    public AudioSource wallSound;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="Player1" || collision.gameObject.name == "Player2")
        {
            ballSound.Play();
        }
        else
        {
            wallSound.Play();
        }
    }
}
