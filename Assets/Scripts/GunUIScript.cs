using TMPro;
using UnityEngine;

public class GunUIScript : MonoBehaviour
{
    [SerializeField] TMP_Text ammoCountText;   //ссылка на текстовое поле для отображения боезапаса

    public void updateAmmoCount(int currentAmmo, int maxAmmo)   //метод обновления информации о боезапасе
    {
        ammoCountText.text = "Патроны: " + currentAmmo + "/" + maxAmmo;
    }
}