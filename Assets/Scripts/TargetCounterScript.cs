using TMPro;
using UnityEngine;

public class TargetCounterScript : MonoBehaviour
{
    [SerializeField] TMP_Text counterText;  //ссылка на поле для отображения числа поражённых мишеней
    int targets = 0;                        //число поражённых мишеней

    private void Start()
    {
        counterText.text = "Мишеней поражено: " + targets.ToString();
    }

    public void targetsUp()
    {
        targets++;
        counterText.text = "Мишеней поражено: " + targets.ToString();
    }
}