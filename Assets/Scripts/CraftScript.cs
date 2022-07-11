using UnityEngine;

namespace DefaultNamespace
{
    public class CraftScript : MonoBehaviour
    {
        public FirstPersonDog firstDog;
        public ItemCanvas itemCanvas;
        public Transform craft;
        public bool nearCraft;

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
                activateCanvas();
            }

            if (Input.GetKey(KeyCode.Space))
            {
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