using UnityEngine;
using YawVR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;


public class YawRotation : MonoBehaviour
{
    string file = "standardRoute.txt";
    List<string> fileContent;


    void Start()
    {
        string path = Path.Combine(Application.dataPath, file);
        fileContent = new List<string>(File.ReadAllLines(path));
        Shuffle(fileContent);
        StartCoroutine(Execute());
    }


    void Shuffle(List<string> fileContent)
    {
        for (int i = 0; i < fileContent.Count; i++)
        {
            string temp = fileContent[i];
            int r = UnityEngine.Random.Range(i, fileContent.Count);
            fileContent[i] = fileContent[r];
            fileContent[r] = temp;
        }
    }

    IEnumerator Execute()
    {
        foreach (string line in fileContent)
        {
            string[] sections = line.Split(",");
            string direction = sections[0];
            float degrees = int.Parse(sections[1]);
            float speed = int.Parse(sections[2]);
            float duration = int.Parse(sections[3]);

            float timer = 0f;
            Vector3 axis = direction == "L" ? Vector3.down : Vector3.up;

            while (timer < degrees)
            {
                transform.Rotate(axis * speed * Time.deltaTime);
                timer += speed * Time.deltaTime;
                yield return null;
            }

            Debug.Log(line);
            yield return new WaitForSeconds(duration);
        }
    }
}


/*
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
}
*/
