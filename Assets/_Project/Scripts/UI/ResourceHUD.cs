using TMPro;
using UnityEngine;

public class ResourceHUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI woodText;
    [SerializeField] TextMeshProUGUI stoneText;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI waterText;

    private void OnEnable() => ResourceManager.instance.OnResourcesChanged += Refresh;
    private void OnDisable() => ResourceManager.instance.OnResourcesChanged -= Refresh;
    private void Refresh()
    {
        woodText.SetText("Wood: " + ResourceManager.instance.GetResourceOfType(ResourceType.Wood).ToString());
        stoneText.SetText("Stone: " + ResourceManager.instance.GetResourceOfType(ResourceType.Stone).ToString());
        goldText.SetText("Gold: " + ResourceManager.instance.GetResourceOfType(ResourceType.Gold).ToString());
        waterText.SetText("Water: " + ResourceManager.instance.GetResourceOfType(ResourceType.Water).ToString());
    }
}
