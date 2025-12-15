using System.Diagnostics;
using System.Threading.Tasks.Dataflow;
using UnityEngine;

public class StegoDetectionScript : MonoBehaviour
{

    public float stegoCount;


    public TransformBlock detectionPoint;
    public float detectionRadius = 5f;
    public LayerMask stegoLayer;

    public int stegoIndex()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(detectionPoint.position, detectionRadius, stegoLayer);

        return hitColliders.Length;
    }

    public bool CarniAggro(int stegoCount <= 2)
    {
        int count = stegoIndex();
        Debug.Log(count);
        return count > stegoCount;
    }
}
