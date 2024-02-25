using UnityEngine;
using System.Threading;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D body ;
    public BoxCollider2D bc2d1;
    public BoxCollider2D bc2d2;
    public bool toRight = true;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position  = new Vector3(15, -1, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (toRight == true){
            body.AddForce(Vector2.right * 1f);
        }
        else{
            body.AddForce(Vector2.left * 1f);
        }
        

        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d1))
        {
            toRight = true;
            transform.localScale = Vector3.one;
        }

        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d2))
        {
            toRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
