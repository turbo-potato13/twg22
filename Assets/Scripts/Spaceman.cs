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
        helps.Add("Для сада нужна вода, семена и вода");
        helps.Add("Чтобы сделать солнечную панель нужен металл и сломанная панель");
        helps.Add("металл для солнечной панели нужен не один, но и не два");
        helps.Add("где-то в куполе есть модуль с музыкой и фильмами");
        helps.Add("в кратере я точно видел уголь");
        helps.Add("в кратере сломанный марсоход, рядом валяется много металла");
        helps.Add("мешки с семенами остались в куполе, как и вода");
        helps.Add("в куполе должны сохранится работающие солнечные панели");
        helps.Add("купол единственное место на марсе, где осталась вода (в бочках)");
        helps.Add("почва Марса подойдет для выращивания растений, она разбросана по всему Марсу");
        tutorial.Add("Нажми z, чтобы посмотреть текущие задания");
        tutorial.Add("Нажми I, чтобы посмотреть инвентарь");

    }
    
    private void awakeTutorial()
    {
        tutorial.Add("Пистолет делается только из металла");
        tutorial.Add("Чтобы убить ебак тебе нужен пистолет");
        tutorial.Add("Металл можно найти рядом с куполом или внутри кратера");
        tutorial.Add("Нажми z, чтобы посмотреть текущие задания");
    }
}