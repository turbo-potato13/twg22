using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public GameObject tasks;
    public List<Task> tasksList;
    public FirstPersonDog firstPerson;
    public GameObject awakePanel;
    public void Awake()
    {
        firstPerson = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonDog>();
        tasksList[0].gameObject.SetActive(true);
        tasksList[0].image.gameObject.SetActive(false);
        for (int i = 1; i < tasksList.Count; i++)
        {
            tasksList[i].gameObject.SetActive(false);
        }
    }

    void OnGUI()
    {
        if (Input.anyKey)
        {
            awakePanel.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            tasks.SetActive(true);
        }
        else
        {
            tasks.SetActive(false);
        }
    }

    public void successTask(int taskNumber)
    {
        tasksList[taskNumber].image.gameObject.SetActive(true);
        firstPerson.TaskText.gameObject.SetActive(true);
        firstPerson.TaskText.text = "Вы выполнили задание";
        Invoke("disableText", 2);
    }

    public void enableAllTasks()
    {
        for (int i = 1; i < (tasksList.Count - 1); i++)
        {
            tasksList[i].gameObject.SetActive(true);
        }
    }

    public void enableBonusTask()
    {
        int i = tasksList.Count - 1;
        tasksList[i].gameObject.SetActive(true);
        successTask(i);
    }

    private void disableText()
    {
        firstPerson.TaskText.gameObject.SetActive(false);
    }
    
}