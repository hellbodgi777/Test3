using UnityEngine;

public class EventParameters
{
    public Vector3 playerPosition; //позиция игрока
    public RaycastHit hit;       //точка по которой пришлось попадание
    public float impulse;          //импульс, передаваемый объекту при попадании

    public EventParameters(Vector3 playerPosition, RaycastHit hit, float impulse)
    {
        this.playerPosition = playerPosition;
        this.hit = hit;
        this.impulse = impulse;
    }
}