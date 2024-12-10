using TMPro;
using UnityEngine;

public class ButtonTextTranslation : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textComponent;

    public void MoveUp()
    {
        if(textComponent is null)
        {
            return;
        }

        textComponent.transform.localPosition = new Vector3(
            textComponent.transform.localPosition.x,
            textComponent.transform.localPosition.y + 3,
            textComponent.transform.localPosition.z);
    }

    public void MoveDown()
    {
        if(textComponent is null)
        {
            return;
        }

        textComponent.transform.localPosition = new Vector3(
            textComponent.transform.localPosition.x,
            textComponent.transform.localPosition.y - 3,
            textComponent.transform.localPosition.z);
    }
}
