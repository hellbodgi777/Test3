using UnityEngine;
using UnityEngine.Events;

public class GunFiringScript : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzleFlash;    //ссылка на эффект дульной вспышки
    [SerializeField] ShellEjectionScript shellEjector; //ссылка на скрипт, отвечающий за выброс гильз
    public UnityEvent Shot;                         //ссылка на обработчики событий выстрела

    Animator animator;

    private void Start() =>
        animator = GetComponent<Animator>();

    public void playShotAnimation() //метод запуска анимации выстрела
    {
        animator.SetBool("isFiring", true);
    }

    public void shotStarts()    //обработчик события начала выстрела
    {
        muzzleFlash.Play();
        Shot?.Invoke();
        Debug.Log("started");
    }

    public void shotEnds()  //обработчик события завершения выстрела
    {
        animator.SetBool("isFiring", false);
        muzzleFlash.Stop();
        Debug.Log("stoped");
    }

    public void ejectionMoment()    //обработчик события выброса гильзы
    {
        shellEjector.ejectShell();
    }
}