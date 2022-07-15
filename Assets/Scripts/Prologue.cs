using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    public float speed = 10;
    public bool isEbaka = false;
    public List<String> scenary;
    public TMP_Text story;
    public int i = 0;

    void Start()
    {
        transform.position = new Vector3(270f, 415f, 104f);
        transform.rotation = new Quaternion(0.342020094f, 0f, 0f, 0.939692676f);
        story.text = scenary[i];
    }

    void Update()
    {
        if (i >= 4)
        {
            isEbaka = true;
        }

        if (transform.position.z < 380f && !isEbaka)
        {
            transform.position = transform.position + (Vector3.forward * speed * Time.deltaTime);
        }
        else if (transform.position.z >= 380f && !isEbaka)
        {
            transform.position = new Vector3(270f, 415f, 104f);
        }
        else if (transform.position.z < 150f && isEbaka)
        {
            transform.position = transform.position + (Vector3.forward * speed * Time.deltaTime);
        }
        else if (transform.position.z >= 150f && isEbaka)
        {
            transform.position = new Vector3(123f, 305, 54);
        }
    }

    public void nextScenary()
    {
        i++;
        if (i > 3)
        {
            transform.position = new Vector3(123f, 305, 54);
            transform.rotation = new Quaternion(0, 0, 0, 1);
        }

        if (i > 7)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            story.text = scenary[i];
        }
    }
}