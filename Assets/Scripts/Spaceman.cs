using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using Random = UnityEngine.Random;

public class Spaceman : MonoBehaviour
{
    public FirstPersonDog firsPerson;
    public List<string> helps;
    public List<string> tutorial;

    private void Awake()
    {
        firsPerson = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonDog>();
        helps = new List<string>();
        tutorial = new List<string>();
        awakeHelps();
        awakeTutorial();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!firsPerson.Gun.activeSelf)
            {
                firsPerson.helpText.text = tutorial[Random.Range(0, tutorial.Count)];
            }
            else
            {
                firsPerson.helpText.text = helps[Random.Range(0, helps.Count)];
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            firsPerson.helpText.text = "";
        }
    }

    private void awakeHelps()
    {
        helps.Add("Чтобы сделать фильтр нужен уголь и металл");
        helps.Add("В фильтре много металла, угля конечно поменьше");
    }
    
    private void awakeTutorial()
    {
        tutorial.Add("Пистолет делается только из металла");
        tutorial.Add("Чтобы убить ебак тебе нужен пистолет");
        tutorial.Add("Металл можно найти рядом с куполом или внутри кратера");
    }
}