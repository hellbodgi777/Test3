using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] Transform player;   //ссылка на объект игрока
    [SerializeField] Transform visor;    //ссылка на объект, отображающий глаза/голову игрока

    [SerializeField]
    [Range(0.01f, 10f)] float xSens = 0.1f;    //чувствительность курсора по горизонтали
    [SerializeField]
    [Range(0.01f, 10f)] float ySens = 0.1f;    //чувствительность курмора по вертикали

    Quaternion center;                         //центр экрана

    private void Start() => center = visor.localRotation;

    private void OnLook(InputValue lookValue)  //метод, вызываемый при перемещении курсора
    {
        Vector2 rotation = lookValue.Get<Vector2>();  //получение смещения курсора
        float mouseY = rotation.y * ySens;
        //рассчёт поворота вокруг оси X
        Quaternion yRotation = visor.localRotation * Quaternion.AngleAxis(mouseY, -Vector3.right);

        if (Quaternion.Angle(center, yRotation) < 90) //не превышает ли поворот относительно начальной позиции 90 градусов
            visor.localRotation = yRotation;

        //рассчёт поворота вокруг оси X
        float mouseX = rotation.x * xSens;
        Quaternion xRotation = player.localRotation * Quaternion.AngleAxis(mouseX, Vector3.up);

        player.localRotation = xRotation;
    }
}