using UnityEngine;
using YawVR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class YawRotation : MonoBehaviour
{
    public bool notSpinning = false;
    public bool complete = false;
    public float duration = 3f;
    public float timer = 0f;
    public float rotationSpeed = 60f;
    public float pause = 1f;
    public int index = 0;

    public string[] rotations = new string[] { "r", "l", "r", "l", "r", "l", "r", "l" };


    void Start()
    {
        Shuffle(rotations);
    }

    void Shuffle(string[] values)
    {
        for (int i = 0; i < rotations.Length; i++)
        {
            string temp = values[i];
            int r = UnityEngine.Random.Range(i, rotations.Length);
            rotations[i] = rotations[r];
            rotations[r] = temp;
        }
    }



    void Update()
    {
        if (complete || index >= rotations.Length)
        {
            return;
        }

        timer += Time.deltaTime;

        if (!notSpinning)
        {
            if (rotations[index] == "r")
            {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }
            else if (rotations[index] == "l")
            {
                transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
            }
            if (timer >= duration)
            {
                notSpinning = true;
                timer = 0f;
            }
        }
        else
        {
            if (timer >= pause)
            {
                notSpinning = false;
                timer = 0f;
                index += 1;
                if (index >= rotations.Length)
                {
                    complete = true;
                    Console.WriteLine("Experiment is complete");
                }
            }
        }
    }



        /*counter += Time.deltaTime;

        if (counter >= 10f)
        {
            notSpinning = true;
        }
        else
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 60f);
        }
        */

}