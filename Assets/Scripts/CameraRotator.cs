using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    void Update()
    {
        this.transform.Rotate(0f, 0f, 1f);
    }
}
