using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuGame : MonoBehaviour
{
    [SerializeField] GameObject helper;
    private bool pause = false;
    private CharacterController player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>();   
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
            if (pause) {
                Pause();
            }
            else Resume();
        }
    }

    private void Resume() {
        helper.SetActive(false);
        player.enabled = true;
        Time.timeScale = 1f;
    }

    private void Pause() {
        helper.SetActive(true);
        player.enabled = false;
        Time.timeScale = 0f;
    }
}
