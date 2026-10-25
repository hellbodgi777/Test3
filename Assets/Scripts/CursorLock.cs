using UnityEngine;

public class CursorLock : MonoBehaviour
{
    [SerializeField] bool cursorLock = true;    //начальное состояние курсора

    private void Start() => changeCursorState();

    void OnEscape()  //обработчик события нажатия на клавишу Esc
    {
        cursorLock = !cursorLock;    //смена состояния курсора на противоположное
        changeCursorState();
    }

    void changeCursorState()     //метод включения/выключения курсора
    {
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}