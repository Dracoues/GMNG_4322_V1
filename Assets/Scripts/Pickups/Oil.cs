using UnityEngine;
using TMPro;

public class Oil : MonoBehaviour
{
    public AudioClip oilClip;
    private TextMeshProUGUI oilText;
    private Animator _animator;

    private void Start()
    {
        oilText = GameObject.FindWithTag("OilText").GetComponent<TextMeshProUGUI>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.oil += 1;
            player.PlaySFX(oilClip);
            oilText.text = player.oil.ToString();
            Destroy(gameObject);

            //if (player.oil =< 100)

        }

        

    }
}
