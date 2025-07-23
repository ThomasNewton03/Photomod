using UnityEngine;
using YawVR;
using System.Collections;
using System.Collections.Generic;

public class YawRotation : MonoBehaviour
{
    public bool notSpinning = false;
    public float counter = 0f;

    void Update()
    {
        if (notSpinning)
        {
            return;
        }

        counter += Time.deltaTime;

        if (counter >= 10f)
        {
            notSpinning = true;
        }
        else
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 60f);
        }
    }

}