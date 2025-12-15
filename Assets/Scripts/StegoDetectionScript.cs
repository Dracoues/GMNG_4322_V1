using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

public class StegoDetectionScript : MonoBehaviour
{

    public Transform detectionPoint;
    public float detectionRadius = 5f;
    public LayerMask stegoLayer;

    public int stegoIndex()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(detectionPoint.position, detectionRadius, stegoLayer);

        return hitColliders.Length;
    }
    
    public bool StegoAggro()
    {
        int count = stegoIndex();
        UnityEngine.Debug.Log(count);
        return count >= 2;
    }
    
    public bool CarniAggro()
    {
        int count = stegoIndex();
        UnityEngine.Debug.Log(count);
        return count <= 2;
    }
}
