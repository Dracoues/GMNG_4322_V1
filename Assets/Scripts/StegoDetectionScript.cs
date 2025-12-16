using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

public class StegoDetectionScript : MonoBehaviour
{

    public Transform detectionPoint;
    public float detectionRadius = 5f;
    public LayerMask stegoLayer;



    public int lastStegoCount;

    public void Update()
    {
        UnityEngine.Debug.Log("In stego detect update");
        stegoIndex();
        
    }

    //many stegos!
    public int stegoIndex()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(detectionPoint.position, detectionRadius, stegoLayer);

        return hitColliders.Length;
    }

    //stego!
    public bool StegoAggro()
    {
        UnityEngine.Debug.Log("in StegoAggro!");
        int count = stegoIndex();
        lastStegoCount = count;
        UnityEngine.Debug.Log("This is Stego count " + count);
        return count >= 2;
    }

    //carni!
    public bool CarniAggro()
    {
        int count = stegoIndex();
        lastStegoCount = count;
        UnityEngine.Debug.Log(count);
        return count <= 2;
    }
}
