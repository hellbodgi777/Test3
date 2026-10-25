using TMPro;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] GunFiringScript gunFiring;      //ссылка на скрипт управления анимацией выстрела
    [SerializeField] GunLogic gunLogic;              //ссылка на логику расчёта попадания
    [SerializeField] ReloadingScript gunReloading;   //ссылка на скрипт управления анимацией перезарядки
    [SerializeField] GunUIScript gunUIScript;        //ссылка на скрипт отображения информации об оружии

    [SerializeField]
    [Range(5, 35)] int maxAmmo = 5;                  //максимальный запас патронов в обойме
    int currentAmmo;                                 //текущее количество патронов в обойме
    bool reloading = false;                          //индикатор, идёт ли перезарядка

    [SerializeField]
    [Range(0.05f, 2.0f)] float fireRate = 0.2f;  // задержка между выстрелами в секундах
                                                 // 0.2 = 5 выстрелов в секунду
    float nextFireTime = 0f;                       // время, когда можно стрелять снова

    private void Start()
    {
        currentAmmo = maxAmmo;
        gunUIScript.updateAmmoCount(currentAmmo, maxAmmo);
    }

    public void shoot() //метод запуска анимации выстрела
    {
        if (reloading) return;
        if (currentAmmo <= 0) return;
        if (Time.time < nextFireTime) return;

        gunFiring.playShotAnimation();
        nextFireTime = Time.time + fireRate;
    }

    public void reloadingStart() //метод запуска анимации перезарядки
    {
        if (reloading) return;
        reloading = true;
        gunReloading.playReloadingAnimation();
    }

    public void reloadingEnds() //обработчик события окончания перезарядки
    {
        reloading = false;
        currentAmmo = maxAmmo;
        gunUIScript.updateAmmoCount(currentAmmo, maxAmmo);
    }

    public void gunShot() //обработчик события выстрела
    {
        gunLogic.shot();
        currentAmmo--;
        gunUIScript.updateAmmoCount(currentAmmo, maxAmmo);
    }
}