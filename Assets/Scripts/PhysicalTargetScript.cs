using Unity.AppUI.UI;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]   //объект, содержащий этот скрипт, должен иметь компонент Rigidbody
public class PhysicalTargetScript : MonoBehaviour
{
    Rigidbody rb;

    private void Start() => rb = GetComponent<Rigidbody>();

    public void OnHit(EventParameters parameters)   //обработчик события попадания по объекту
    {
        //вычисление вектора направленного от игрока к мишени
        Vector3 direction = transform.position - parameters.playerPosition;
        direction.Normalize();

        //применение импульса по вектору от игрока к мишени в точке попадания
        rb.AddForceAtPosition(direction * parameters.impulse, parameters.hit.point, ForceMode.Impulse);
    }

}