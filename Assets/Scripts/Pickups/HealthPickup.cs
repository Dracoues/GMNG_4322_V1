using UnityEngine;

using TMPro;



public class Health : MonoBehaviour

{

    public AudioClip healthClip;

    private TextMeshProUGUI healthText;

    private Animator _animator;



    private void Start()

    {

        healthText = GameObject.FindWithTag("HealthText").GetComponent<TextMeshProUGUI>();

    }





    private void OnTriggerEnter2D(Collider2D collision)

    {

        if(collision.gameObject.tag == "Player")

        {

            Player player = collision.gameObject.GetComponent<Player>();

            player.health += 1;

            if(player.health > 100)
                player.health = 100;

            player.PlaySFX(healthClip);

            healthText.text = player.health.ToString();

            Destroy(gameObject);

        }    

    }

}
