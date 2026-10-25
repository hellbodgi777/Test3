using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    [Range(1, 100)] float moveSpeed = 10;             //скорость перемещения персонажа
    [SerializeField]
    [Range(1, 100)] float jumpForce = 10;
    [SerializeField] CharacterController controller;  //ссылка на контроллер персонажа

    [SerializeField] float gravity = -9.81f;          //сила притяжения
    Vector3 direction = Vector3.zero;                 //направление перемещения персонажа
    Vector3 velocity = Vector3.zero;                  //скорость перемещения игрока
    bool grounded = true;                             //флаг, определяющий, стоит ли персонаж на поверхности

    private void OnMove(InputValue movementValue)     //метод, вызываемый системой ввода при нажатии клавиш перемещения
    {
        Vector2 movementVector = movementValue.Get<Vector2>();  //можно посмотреть значения вектора при помощи Debug.Log
        //расчёт направления перемещения
        direction = new Vector3(movementVector.x, 0, movementVector.y).normalized;
    }
    private void OnJump()  //метод, вызываемый системой ввода при нажатии клавиши прыжка
    {
        if (grounded)      //если персонаж имеет контакт с поверхностью снизу
            velocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravity);
    }

    private void LateUpdate()
    {
        grounded = controller.isGrounded;   //получение информации о контакте игрока с поверхностью
        controller.Move(transform.TransformDirection(direction) * (moveSpeed * Time.deltaTime));  //перемещение в плоскости XZ

        if (grounded && velocity.y < 0) velocity.y = 0; //предотвращение прохождения персонажа сквозь поверхность снизу
        velocity.y += gravity * Time.deltaTime;         //применение силы тяжести

        controller.Move(velocity * Time.deltaTime);     //перемещение персонажа
    }
}
