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

        private void Awake()
        {
            if (firstDog == null)
            {
                firstDog = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonDog>();
            }
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
            nearCraft = true;
        }

        private void OnTriggerExit(Collider other)
        {
            nearCraft = false;
        }

        private void OnTriggerStay(Collider other)
        {
            if (Input.GetKey(KeyCode.F))
            {
                Time.timeScale = 0f;
                firstDog.gameObject.GetComponent<FirstPersonController>().m_MouseLook.setLock(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                activateCanvas();
            }

            if (Input.GetKey(KeyCode.Space))
            {
                Time.timeScale = 1f;
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