using TMPro;
using UnityEngine;

public class ButtonTextTranslation : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textComponent;

    [SerializeField]
    private int offset = 3;

    private Vector3 originalPosition;
    private Vector3 pressedPosition;

    private void Awake()
    {
        originalPosition = textComponent.transform.localPosition;
        pressedPosition =  new Vector3(
            originalPosition.x,
            originalPosition.y - offset,
            originalPosition.z);
    }

    public void MoveUp()
    {
        if(textComponent is null)
        {
            return;
        }

        textComponent.transform.localPosition = originalPosition;
    }

    public void MoveDown()
    {
        if(textComponent is null)
        {
            return;
        }

        textComponent.transform.localPosition = pressedPosition;
    }
}
