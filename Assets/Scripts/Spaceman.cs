
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

    private void Awake()
    {
        firsPerson =  GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonDog>();
        helps = new List<string>();
        helps.Add("Чтобы сделать фильтр нужен уголь и металл");
        helps.Add("В фильтре много металла, угля конечно поменьше");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            firsPerson.helpText.text = helps[Random.Range(0, helps.Count)];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            firsPerson.helpText.text = "";
        }
    }
}
