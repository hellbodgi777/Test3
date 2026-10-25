using UnityEngine;

public class GateAnimationScript : MonoBehaviour
{
    Animator animator;       //ссылка на компонент, содержащий анимации
    bool isOpen = false;     //индикатор состояния врат (открыты/закрыты)

    private void Start() => animator = GetComponent<Animator>();

    public void openGate()
    {
        isOpen = true;
        animator.SetBool("isOpen", isOpen);       //запуск анимации открытия врат
    }

    public void closeGate()
    {
        isOpen = false;
        animator.SetBool("isOpen", isOpen);       //запуск анимации закрытия врат
    }
}