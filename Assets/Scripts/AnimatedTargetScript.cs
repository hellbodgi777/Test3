using UnityEngine;
using UnityEngine.Events;

public class AnimatedTargetScript : MonoBehaviour
{
    public UnityEvent OnTargetHit;

    Animator animator;

    private void Start() => animator = GetComponent<Animator>();

    public void targetReady()
    {
        animator.SetBool("isReady", true);
    }

    public void targetHit()
    {
        animator.SetBool("isHit", true);
    }
    public void OnHit()
    {
        OnTargetHit?.Invoke();
    }
}