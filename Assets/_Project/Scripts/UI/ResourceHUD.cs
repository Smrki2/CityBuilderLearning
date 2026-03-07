using TMPro;
using UnityEngine;

public class ResourceHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI woodText;
    [SerializeField] TextMeshProUGUI stoneText;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI waterText;

    private void Update()
    {
        woodText.SetText("Wood: " + ResourceManager.instance.Get(ResourceType.Wood).ToString());
        stoneText.SetText("Stone: " + ResourceManager.instance.Get(ResourceType.Stone).ToString());
        goldText.SetText("Gold: " + ResourceManager.instance.Get(ResourceType.Gold).ToString());
        waterText.SetText("Water: " + ResourceManager.instance.Get(ResourceType.Water).ToString());
    }

}
