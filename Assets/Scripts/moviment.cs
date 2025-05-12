using UnityEngine;
using TMPro;

public class Moviment : MonoBehaviour
{
    public float speed = 10f;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;  // Afegim una variable per al text de derrota

    private Rigidbody rb;
    private int count = 0;
    private int totalEnemies;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        totalEnemies = GameObject.FindGameObjectsWithTag("enemic").Length;

        winText.gameObject.SetActive(false); 
        loseText.gameObject.SetActive(false); // Assegurem que el text de derrota estigui amagat al principi
        SetCountText();
    }

    void Update()
    {
        float movimentH = Input.GetAxis("Horizontal");
        float movimentV = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movimentH, 0.0f, movimentV);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemic"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        // Afegim la condició per a "enemic2"
        if (other.gameObject.CompareTag("enemic2"))
        {
            // Desaparèixer la pilota
            gameObject.SetActive(false);
            // Mostrar el text de derrota
            loseText.gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemic"))
        {
            collision.gameObject.SetActive(false);
            count++;
            SetCountText();
        }

        // Afegim la condició per a "enemic2"
        if (collision.gameObject.CompareTag("enemic2"))
        {
            // Desaparèixer la pilota
            gameObject.SetActive(false);
            // Mostrar el text de derrota
            loseText.gameObject.SetActive(true);
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 4)
        {
            winText.fontSize = 150;
            winText.alignment = TextAlignmentOptions.Center;
            winText.gameObject.SetActive(true);
        }
    }
}
