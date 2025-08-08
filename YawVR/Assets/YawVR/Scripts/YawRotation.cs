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
    string logFile = "consoleLog.txt";

    void LogFile(string entry)
    {
        string logPath = Path.Combine(Application.dataPath, logFile);
        string logMessage = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "- " + entry + "\n";
        File.AppendAllText(logPath, logMessage);
    }


    void Start()
    {
        string path = Path.Combine(Application.dataPath, file);
        fileContent = new List<string>(File.ReadAllLines(path));
        //Shuffle(fileContent);
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
            float lineNumber = int.Parse(sections[0]);
            string direction = sections[1];
            float degrees = int.Parse(sections[2]);
            float speed = int.Parse(sections[3]);
            float duration = int.Parse(sections[4]);

            if (speed > 50)
            {
                speed = 10;
            }

            float timer = 0f;
            Vector3 axis = direction == "L" ? Vector3.down : Vector3.up;

            while (timer < degrees)
            {
                transform.Rotate(axis * speed * Time.deltaTime);
                timer += speed * Time.deltaTime;
                yield return null;
            }

            Debug.Log(line);
            LogFile(line);
            yield return new WaitForSeconds(duration);
        }
    }

}
