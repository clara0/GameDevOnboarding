using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private bool player1 = true;
    [SerializeField] private float speed = 5;
    private KeyCode up;
    private KeyCode down;
    private int dir = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        up = player1 ? KeyCode.W : KeyCode.I;
        down = player1 ? KeyCode.S : KeyCode.K;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up))
        {
            dir = 1;
        }
        else if (Input.GetKey(down))
        {
            dir = -1;
        }
        else
        {
            dir = 0;
        }
        transform.position += Vector3.up * speed * dir * Time.deltaTime;
    }
}
