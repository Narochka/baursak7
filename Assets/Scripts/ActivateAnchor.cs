using UnityEngine;

public class ActivateAnchor : MonoBehaviour
{
    public GameObject groundAnchor;

    public void EnableAnchor()
    {
        if (groundAnchor != null)
        {
            groundAnchor.SetActive(true);
        }
    }
}
