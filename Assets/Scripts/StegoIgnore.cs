using UnityEngine;

public class StegoIgnore : MonoBehaviour
{
    public LayerMask enemyLayer, stegoLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 8);
    }
}
