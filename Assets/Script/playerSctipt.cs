using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class playerSctipt : MonoBehaviour
{
    BoxCollider2D bc;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    PlayerController input = null;
    Vector2 moveVector;
    public TMP_Text healthText; //player health text 
    public TMP_Text coinText; //player health text 
    public Camera mainCamera;
    public GameObject gun;
    public List<GameObject> passiveWeapons; 
    public List<GameObject> upgrades;
    public int moveSpeed = 5;
    bool isPaused = false;
    public int coins;
    public int currentHealth;
    public int maxHealth = 100;
    float gunRotationDistance = 1.7f;


    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); //gets the rigidbody component of the current object
        sprite = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        input = new PlayerController();
        currentHealth = maxHealth;
        healthText.text = "Health:" + currentHealth.ToString() + "/" + maxHealth.ToString();
        coinText.text = "Coin:" + coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        rotatePlayerToCamera();
    }

    private void rotatePlayerToCamera()
    {
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
        worldMousePosition.z = 0; 

        Vector2 direction = (worldMousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        gun.transform.position = transform.position + (Vector3)direction * gunRotationDistance;

    } //rotates the player to the main camera camera when in third person

    public void addCoin()
    {
        coins++;
        coinText.text = "Coin:" + coins.ToString();
        Debug.Log("picked up coin");
    }

    public void loseCoin()
    {
        coins--;
        coinText.text = "Coin:" + coins.ToString();
    }

    public void addHealth()
    {
        currentHealth += 1;
        healthText.text = "Health:" + currentHealth.ToString() + "/" + maxHealth.ToString();
    }

    public void loseHealth()
    {
        currentHealth -= 1;
        healthText.text = "Health:" + currentHealth.ToString() + "/" + maxHealth.ToString();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "collectible")
        {
            addCoin();
            Destroy(other.gameObject);
            Debug.Log("Collectible touched and destroyed. Coins: " + coins);
        }
        
        
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += OnMovePerformed;
        input.Player.Move.canceled += OnMoveCancelled;

        input.Player.Pause.performed += OnPausePerformed;

        input.Player.Shoot.performed += OnShootPerformed;
        input.Player.Shoot.performed += OnShootCanceled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= OnMovePerformed;
        input.Player.Move.canceled -= OnMoveCancelled;

        input.Player.Shoot.performed -= OnShootPerformed;
        input.Player.Shoot.performed -= OnShootCanceled;
    }

    private void OnMovePerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
        //Debug.Log(moveVector);


    }

    private void OnMoveCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }

    private void Move()
    {
        Vector2 moveDirection = moveVector.normalized; // Normalize the direction to prevent faster movement diagonally
        rb.velocity = moveDirection * moveSpeed; // Set the velocity of the rigidbody to move the character
    }


    private void OnPausePerformed(InputAction.CallbackContext value)
    {
        {
            isPaused = !isPaused;

            // Pause or unpause the game by manipulating Time.timeScale
            if (isPaused)
            {
                Time.timeScale = 0f; // Pause the game
            }
            else
            {
                Time.timeScale = 1f; // Unpause the game
            }
        }
    }

    void OnShootPerformed(InputAction.CallbackContext value)
    {
        gun.GetComponent<gunScript>().shoot();
        
    }

    void OnShootCanceled(InputAction.CallbackContext value)
    {

    }

}
