using UnityEngine;
using UnityEngine.Events;

public class GateTriggerScript : MonoBehaviour
{
    public UnityEvent OnPlayerEnter;   //ссылка на обработчик события "игрок вошёл в триггер"
    public UnityEvent OnPlayerExit;    //ссылка на обработчик события "игрок покинул триггер"

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            OnPlayerEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            OnPlayerExit?.Invoke();
    }
}