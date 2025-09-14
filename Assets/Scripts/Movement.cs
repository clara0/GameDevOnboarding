using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private int mult = 1;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI winner;
    private Vector3 travelDir;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverScreen.SetActive(false);
        travelDir = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(travelDir * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0;
            if (collision.contacts[0].point.x >= 0)
            {
                winner.text = "Player 1 wins!";
            }
            else
            {
                winner.text = "Player 2 wins!";
            }
        }
        else
        {
            mult *= -1;
            Vector3 dir = collision.gameObject.transform.InverseTransformPoint(transform.position);
            if (dir.y == 0)
            {
                travelDir = Vector3.right * mult;
            }
            else
            {
                handleAngle(dir.y);
            }
        }

    }

    private void handleAngle(float y)
    {
        float rotAmt = Mathf.Clamp(y * 10, -30, 30) * Mathf.Deg2Rad;
        if (mult == -1)
        {
            rotAmt = Mathf.PI - rotAmt;
            rotAmt *= -1;
        }
        float xAmt = Mathf.Cos(rotAmt);
        float yAmt = Mathf.Sin(rotAmt);
        travelDir = new Vector3(xAmt, yAmt, 0);
    }
}
