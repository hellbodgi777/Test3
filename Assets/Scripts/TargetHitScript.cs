using UnityEngine;
using UnityEngine.Events;

public class TargetHitScript : MonoBehaviour
{
    public UnityEvent<EventParameters> OnTargetHit; //ссылка на метод, вызываемый при попадании по объекту

    public void targetHit(EventParameters parameters)
        => OnTargetHit?.Invoke(parameters);
}