using UnityEngine;
using YawVR;
using System.Collections;
using System.Collections.Generic;

public class YawRotation : MonoBehaviour
{
    public float duration = 10f;
    public bool notSpinning = false;
    public float counter = 0f;

    void Update()
    {
        if (notSpinning)
        {
            return;
        }

        counter += Time.deltaTime;

        if (counter >= duration)
        {
            notSpinning = true;
        }
        else
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 30f);
        }
    }

}