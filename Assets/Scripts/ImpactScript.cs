using UnityEngine;

public class ImpactScript : MonoBehaviour
{
    [SerializeField][Range(0.1f, 5.0f)] float duration = 0.5f; //длительность эффекта
    [SerializeField] GameObject impactEffectPrefab;              //ссылка на шаблон эффекта

    public void playImpactEffect(EventParameters parameters)  //метод создания эффекта в указанной точке
    {
        Quaternion r = Quaternion.LookRotation(parameters.hit.normal);             //выравнивание эффекта по нормали
        GameObject effect = Instantiate(impactEffectPrefab, parameters.hit.point, r);
        Destroy(effect, duration);
    }
}