using UnityEngine;
using UnityEngine.Events;

public class ReloadingScript : MonoBehaviour
{
    Animator animator;
    public UnityEvent OnReloadingEnd;   //ссылка на обработчики события окончания перезарядки

    private void Start() =>
        animator = GetComponent<Animator>();

    public void playReloadingAnimation()    //метод, запускающий анимацию перезарядки
    {
        animator.SetTrigger("Reloading");
    }

    public void reloadingEnd()  //обработчик события завершения перезарядки
    {
        OnReloadingEnd?.Invoke();
    }
}