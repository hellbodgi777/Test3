using UnityEngine;

public class GunLogic : MonoBehaviour
{
    [SerializeField] Transform firingPoint;                //точка, от которой будет расчитываться траектория выстрела
    [SerializeField][Range(1f, 100f)] float impulse = 10;  //импульс от попадания из оружия по объекту

    public void shot()
    {

        //построение луча из позиции камеры по направлению её взгляда
        Ray ray = new Ray(firingPoint.transform.position, firingPoint.transform.forward);
        RaycastHit hit;

        Debug.Log("Луч из: " + firingPoint.position + " направление: " + firingPoint.forward);
        if (Physics.Raycast(ray, out hit))
            Debug.Log("Луч попал в: " + hit.transform.name);
        else
            Debug.Log("Луч ни во что не попал");
        if (Physics.Raycast(ray, out hit)) //поиск пересечения луча и первого объекта сцены на его пути
        {
            TargetHitScript hitScript = hit.transform.GetComponent<TargetHitScript>();

            if (hitScript != null) //если попадание прошло по объекту с тэгом Target
                hitScript.targetHit(new EventParameters(transform.position, hit, impulse));
        }
    }
}