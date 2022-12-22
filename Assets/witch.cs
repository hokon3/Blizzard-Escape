using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class witch : MonoBehaviour
{
    public Rigidbody2D playerRigidbody2D;
    public Slider slider;
    public GameObject textGameObject;
    public GameObject weather;
    public GameObject restartButton;
    public GameObject gameOverMessage;
    public GameObject victoryScreen;
    private BoxCollider2D BoxCollider2D;
    private SnowController snowController;
    private TextMeshProUGUI text;
    private float speed;
    public bool started;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.000005F;
        text = textGameObject.GetComponent<TextMeshProUGUI>();
        snowController = weather.GetComponent<SnowController>();
        started = false;
        BoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            return;
        }

        slider.value = slider.value + speed;

        if (slider.value >= 1F)
        {
            Victory();
        }

        if (speed < 0.000010F)
        {
            speed += (0.0000001F * Time.deltaTime);
        }

        text.text = (speed*100000).ToString();

        var adjustment = (0.000005F - speed) * 10;
        var newIntensity = snowController.windIntensity + adjustment;
        if (newIntensity < 0)
            newIntensity = 0;
        snowController.windIntensity = newIntensity;
        snowController.fogIntensity = newIntensity;

        if (newIntensity > 1)
        {
            Loss();
        }

        var HorizontalInput = Input.GetAxis("Horizontal");

        if (HorizontalInput != 0)
        {
            float vel = 2;
            if (HorizontalInput < 0)
            {
                vel *= -1;
            }
            playerRigidbody2D.velocity = (new Vector2(vel, playerRigidbody2D.velocity.y));
        }
        else
        {
            playerRigidbody2D.velocity = (new Vector2(0, playerRigidbody2D.velocity.y));
        }

        var VerticalInput = Input.GetAxis("Vertical");

        if (VerticalInput != 0)
        {
            float vel = 2;
            if (VerticalInput < 0)
            {
                vel *= -1;
            }
            playerRigidbody2D.velocity = (new Vector2(playerRigidbody2D.velocity.x, vel));
        }
        else
        {
            playerRigidbody2D.velocity = (new Vector2(playerRigidbody2D.velocity.x, 0));
        }
    }

    private void Victory()
    {
        started = false;
        victoryScreen.SetActive(true);
    }

    private void Loss()
    {
        started = false;
        playerRigidbody2D.gravityScale = 1;
        BoxCollider2D.enabled = false;
        restartButton.SetActive(true);
        gameOverMessage.SetActive(true);
    }

    public void StartGame()
    {
        started = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Hit()
    {
        if (speed > 0)
            speed -= 0.000001F;
    }
}
