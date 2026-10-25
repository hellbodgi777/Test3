using UnityEngine;

public class ExplosiveTargetScript : MonoBehaviour
{
    [SerializeField][Range(0.5f, 5.0f)] float duration = 1.2f; //длительность эффекта взрыва
    [SerializeField] GameObject explosionPrefab;                //ссылка на шаблон эффекта взрыва

    public void OnHit() //обработчик события попадания по объекту
    {
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, duration);
        Destroy(gameObject);
    }
}