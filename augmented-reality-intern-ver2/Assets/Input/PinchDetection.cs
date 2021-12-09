using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchDetection : MonoBehaviour
{

    public float rotatingSpeed = 5f;
    public float scalingSpeed = 0.01f;

    private float currentScale;
    private float minSizeScale = 0.5f;

    private TouchControl controls;
    private Coroutine zoomCoroutine;
    private void Awake(){
        controls = new TouchControl();
    }

    private void OnEnable(){
        controls.Enable();
    }
    private void OnDisable(){
        controls.Disable();
    }

    void Start(){
        controls.Touch.SecondaryTouchContact.started += _ => ZoomStart();
        controls.Touch.SecondaryTouchContact.started += _ => ZoomEnd();
    }

    private void ZoomStart(){
        zoomCoroutine = StartCoroutine(ZoomDetection());
    }

    private void ZoomEnd(){
        StopCoroutine(zoomCoroutine);
    }

    IEnumerator ZoomDetection(){
        float previousDistance = 0f, distance = 0f;
        while(true){
            distance = Vector2.Distance(controls.Touch.PrimaryFingerPosition.ReadValue<Vector2>(), controls.Touch.SecondaryFingerPosition.ReadValue<Vector2>());

            //zoom out
            if ((distance < previousDistance) && (currentScale > minSizeScale)){
                transform.localScale += Vector3.one*scalingSpeed;
            }

            //zoom in
            if (distance > previousDistance){
                transform.localScale -= Vector3.one*scalingSpeed;
            }
            previousDistance = distance;
            yield return null;
        }
    }

}
