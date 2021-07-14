
using UnityEngine;

public class UpwardMovement : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    public static float speed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        player = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
   
}
