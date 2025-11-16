using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);

        }
    }
}
