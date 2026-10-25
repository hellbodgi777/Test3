using UnityEngine;
using UnityEngine.InputSystem;

public class ShootingScript : MonoBehaviour
{
    [SerializeField] GunScript gun;

    // —сылка на действие Attack из Input Actions
    InputAction attackAction;

    private void Start()
    {
        // ѕолучаем действие "Attack" из PlayerInput
        PlayerInput playerInput = GetComponent<PlayerInput>();
        attackAction = playerInput.actions["Attack"];
    }

    private void Update()
    {
        // ≈сли кнопка зажата и оружие готово Ч стрел€ем
        if (attackAction != null && attackAction.IsPressed())
        {
            gun.shoot();
        }
    }

    // ћетод OnReload можно оставить как есть Ч перезар€дка по нажатию
    void OnReload()
    {
        gun.reloadingStart();
    }
}