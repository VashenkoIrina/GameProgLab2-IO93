using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody _rb;

    public Text scoreText;

    private int _score = 0;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed * h);
        transform.Translate(Vector3.right * Time.fixedDeltaTime * speed * -v);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollectrSphere")
        {
            _score++;
            Destroy(other.gameObject);
            if(_score != 5 ) {
                scoreText.text = "Score: " + _score;
            }
            else {
                scoreText.text = "You win!";
            }
            // _count++;
            // Debug.Log(_count);
            // Destroy(other.gameObject);
            // scoreText.text = "Score: " + _count;

        }
        if(this.CompareTag("Player") && other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
