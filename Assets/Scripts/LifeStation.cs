using DefaultNamespace;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LifeStation : MonoBehaviour
{
    public FirstPersonDog firstDog;
    private FirstPersonController firstPersonController;

    int charOn = 1;

    private void Awake()
    {
        if (firstDog == null)
        {
            firstDog = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonDog>();
        }
        firstPersonController = firstDog.transform.GetComponent<FirstPersonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") {
            return;
        }
        CancelInvoke("takeDamage");
        InvokeRepeating("takeHealth", .5f, 0.3f);
    }

    //При выходе из триггера будет прекращать вызываться функция хила, и через 0.5 сек начнет вызываться функция takeDamage каждую секунду
    //Для здоровья (OnTriggerEnter) аналогично
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            return;
        }
        CancelInvoke("takeHealth");
        InvokeRepeating("takeDamage", .5f, 1f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchCharecter();
        }
    }

    //Время нахождения на Марсе можно высчитывать по формуле t * d = 100, где t время которое за которое разряжается, d - дамаг который нужен для этого
    //0.833f - дамаг для нахождения 3мин, 1.66f - 2мин
    private void takeDamage()
    {
        firstDog.putDischarge(0.833f);
        if (firstDog.currentEnergy < 1)
        {
            firstDog.putDamage(1.66f);
        }
    }

    private void takeHealth()
    {
        firstDog.putHealth(1f);
        firstDog.putCharge(2f);
    }

    public void SwitchCharecter()
    {
    //     switch (charOn)
    //     {
    //         case 1:
    //             charOn = 2;
    //             Dog.SetActive(false);
    //             Spaceman.SetActive(true);
    //             firstPersonController.m_CharacterController.Move(Dog.transform.localPosition);
    //             firstPersonController.m_PreviouslyGrounded = true;
    //
    //             // firstDog.transform.SetPositionAndRotation(Dog.transform.position, Dog.transform.rotation);
    //             break;
    //         case 2:
    //             charOn = 1;
    //             Dog.SetActive(true);
    //             Spaceman.SetActive(false);
    //             firstPersonController.m_CharacterController.Move(Spaceman.transform.localPosition);
    //             firstPersonController.m_PreviouslyGrounded = true;
    //             // firstDog.transform.SetPositionAndRotation(Spaceman.transform.position, Spaceman.transform.rotation);
    //             break;
    //     }
    }
}