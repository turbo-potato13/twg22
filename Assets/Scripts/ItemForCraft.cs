using UnityEngine;

namespace DefaultNamespace
{
    public class ItemForCraft : MonoBehaviour
    {
        public FirstPersonDog firstPerson;
        public Item.ItemType itemType;
        public int itemAmount = 1;
        public TaskManager taskManager;

        private void Awake()
        {
            firstPerson = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonDog>();
            taskManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<TaskManager>();
        }


        private void Update()
        {
            float distance = Vector3.Distance(transform.position, firstPerson.transform.position);
            if (Input.GetKeyDown(KeyCode.E) && distance < 5)
            {
                if (itemType == Item.ItemType.FunModule)
                {
                    Debug.Log("FUUUUUUUN");
                    taskManager.enableBonusTask();
                    firstPerson.TaskText.gameObject.SetActive(true);
                    firstPerson.TaskText.text = "Вы выполнили бонусное задание!\n Найден модуль с развлечениями!";
                    Invoke("disableText", 2);
                }

                Item item = new Item {itemType = itemType, amount = itemAmount};
                firstPerson.takeItem(item);
                Destroy(gameObject);
                firstPerson.helpText.text = "";
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                firstPerson.helpText.text = "Нажмите E, чтобы подобрать материал";
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                firstPerson.helpText.text = "";
            }
        }

        private void disableText()
        {
            firstPerson.TaskText.gameObject.SetActive(false);
        }
    }
}