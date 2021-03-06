using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace DefaultNamespace
{
    public class CraftScript : MonoBehaviour
    {
        public FirstPersonDog firstDog;
        public ItemCanvas itemCanvas;
        public Transform craft;
        public bool nearCraft;
        private FirstPersonController firstPersonController;

        private void Awake()
        {
            if (firstDog == null)
            {
                firstDog = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonDog>();
            }

            firstPersonController = firstDog.transform.GetComponent<FirstPersonController>();
        }

        void OnGUI()
        {
            if (Input.GetKey(KeyCode.I) || nearCraft)
            {
                itemCanvas.setCount(firstDog.inventory);
                itemCanvas.transform.gameObject.SetActive(true);
            }
            else
            {
                itemCanvas.transform.gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            firstDog.helpText.text = "Нажмите F для создания предметов";
            nearCraft = true;
        }

        private void OnTriggerExit(Collider other)
        {
            firstDog.helpText.text = "";
            nearCraft = false;
        }

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKey(KeyCode.F))
            {
                firstDog.helpText.text = "Нажмите esc чтобы выйти из режима создания предметов";
                Time.timeScale = 0.1f;
                firstPersonController.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                activateCanvas();
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                firstDog.helpText.text = "Нажмите F для создания предметов";
                Time.timeScale = 1f;
                firstPersonController.enabled = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                disActivateCanvas();
            }
        }

        public void activateCanvas()
        {
            itemCanvas.gameObject.SetActive(true);
            craft.gameObject.SetActive(true);
        }

        public void disActivateCanvas()
        {
            itemCanvas.gameObject.SetActive(false);
            craft.gameObject.SetActive(false);
        }
    }
}