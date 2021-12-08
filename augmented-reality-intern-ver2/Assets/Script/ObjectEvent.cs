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


    void Start(){
        rbArutalaLogo = arutalaLogo.GetComponent<Rigidbody>();

    }

    void Update(){
        // print(transform.position);
        print (arutalaLogo.transform.rotation);
    }

    public void targetDetected(){
        rbArutalaLogo.AddTorque(TorqueObject, ForceMode.Impulse);
        Instantiate(particleStart, transform.position, Quaternion.identity);
        bgmGame.Play();
    }

    public void targetNotDetected(){
        bgmGame.Stop();
    }
}
