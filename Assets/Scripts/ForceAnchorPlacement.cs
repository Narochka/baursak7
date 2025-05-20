using UnityEngine;
using Zappar;

public class ForceAnchorPlacement : MonoBehaviour
{
    public GameObject groundAnchor;

    private void Start()
    {
        // Просто включаем GroundAnchor через 1 секунду после старта
        Invoke(nameof(EnableAnchor), 1f);
    }

    void EnableAnchor()
    {
        if (groundAnchor != null)
        {
            groundAnchor.SetActive(true);
        }
    }
}
