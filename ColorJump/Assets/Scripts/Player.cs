using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce;
    private Rigidbody2D playerRb;
    private SpriteRenderer playerSr;
    [SerializeField] Color[] playerColor;
    public int tagNumber;
    private bool playerState;


    [SerializeField] private AudioClip clickSoundClip;
    [SerializeField] private ParticleSystem popFx;
    public TextMeshProUGUI scoreText;
    private int score = -1;


    // Start is called before the first frame update
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        playerRb.isKinematic = true;//set playerrb to kinematic
        playerState = true;
        RandomColor();//get random color on player
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();

        if (Input.GetMouseButtonDown(0) && playerState)//if player state false cant jump no audio n movement etc etc
        {
            playerRb.isKinematic = false;
            playerRb.velocity = Vector2.up * jumpForce;

            if (!GameManager.instance.gameIsPaused)// avoid playing audio when game is paused
            {
                AudioManager.instance.PlayAudio(clickSoundClip);//play clicksound oneshot through audio manager
            }


        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ColorSwapper"))//on collision colorswapper get random color;
        {
            RandomColor();
            Destroy(other.gameObject);
            return;
        }

        if (other.tag != tagNumber.ToString() && other.tag != "spawnner" && other.tag != "pass")//checking different triggers for death
        {
            playerState = false;
            GameManager.instance.Invoke("ActiveMode", 3);
            Instantiate(popFx, gameObject.transform.position, popFx.transform.rotation);
            gameObject.SetActive(false);
        }

        if (other.CompareTag("spawnner"))//spawnner object = coin object = update score
        {
            score++;
        }

    }



    private void RandomColor()
    {
        int colorIndex = Random.Range(0, 4);//getting random index for color
        if (colorIndex == tagNumber) //checking for repeating colors
        {
            RandomColor();
        }
        else//if no repeat assign tag colorindex value
        {
            tagNumber = colorIndex;

            switch (colorIndex)
            {
                case 0:
                    playerSr.color = playerColor[0];
                    break;
                case 1:
                    playerSr.color = playerColor[1];
                    break;
                case 2:
                    playerSr.color = playerColor[2];
                    break;
                case 3:
                    playerSr.color = playerColor[3];
                    break;
            }
        }
    }
}
