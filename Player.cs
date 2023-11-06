using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] int currentHealth, maxHealth, currentExperience, maxExperience, currentLevel;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        ExperienceManager.Instance.OnExperienceChange += HandleExperienceChanged;
    }

    private void OnDisable()
    {
        ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChanged;
    }

    private void HandleExperienceChanged(int newexperience)
    {
        currentExperience += newexperience;
        if (currentExperience >= maxExperience)
        {
            LevelUp();
        }
    }

    private void LevelUp() {
        maxHealth += 10;
        currentHealth = maxHealth;
        currentLevel++;

        currentExperience = 0;
        currentExperience += 100;
    }
    // Start is called before the first frame update

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKey(KeyCode.W))
       {
           rb.AddForce(Vector2.up * 10);
       }
       if(Input.GetKey(KeyCode.A))
       {
           rb.AddForce(Vector2.left * 10);
       }
        if(Input.GetKey(KeyCode.S))
         {
            rb.AddForce(Vector2.down * 10);
         }
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * 10);
        }
         if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
