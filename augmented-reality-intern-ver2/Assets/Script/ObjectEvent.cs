using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectEvent : MonoBehaviour
{
    public GameObject arutalaLogo;
    public GameObject particleStart;
    public AudioSource bgmGame;

    public Vector3 TorqueObject = new Vector3 (0,0,0);
    private Rigidbody rbArutalaLogo;
    private Animator animLogo;


    void Start(){
        rbArutalaLogo = arutalaLogo.GetComponent<Rigidbody>();
        animLogo = arutalaLogo.GetComponent<Animator>();

    }

    void Update(){
        // print(transform.position);
        print (arutalaLogo.transform.rotation);
    }

    public void targetDetected(){
        Instantiate(particleStart, transform.position, Quaternion.identity);
        bgmGame.Play();
        animLogo.SetBool("onStart", true);
        arutalaLogo.transform.Rotate(0,360,0);
    }

    public void targetNotDetected(){
        bgmGame.Stop();
        animLogo.SetBool("onStart", false);
    }
}
