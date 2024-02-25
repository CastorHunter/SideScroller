using UnityEngine;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body ;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    private bool grounded;
    private bool key;
    private bool waiting = false;
    private bool damage = false;
    private bool heart1 = true;
    private bool heart2 = true;
    private bool heart3 = true;
    private bool canbedamaged = true;
    private int jumps;
    private int coeurdetruit = 0;
    private int hearts = 3;
    [SerializeField] private BoxCollider2D bc2d1;
    public BoxCollider2D bc2d2;
    public BoxCollider2D bc2d3;
    public BoxCollider2D bc2d4;
    public BoxCollider2D bc2d5;
    public BoxCollider2D bc2d6; //Pride_Gate
    public BoxCollider2D bc2d7; //Pride_FallingZone
    public BoxCollider2D bc2d8; //Wrath_Pic1
    public BoxCollider2D bc2d9; //Wrath_Pic2
    public BoxCollider2D bc2d10; //Gluttony_Enemy
    public BoxCollider2D bc2d11; //Coeur1
    public BoxCollider2D bc2d12; //Coeur2
    public BoxCollider2D bc2d13; //Wrath_Gate

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        key = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position  = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput*speed,body.velocity.y);

        if (horizontalInput > -0.01f)
            transform.localScale = Vector3.one;

        else if (horizontalInput < 0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        //réduit la vitesse du joueur si il touche le trou noir
        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d3) )
        {
            speed = 2;
        }
        else
        {
            if (gameObject.transform.position.y < -80){
                speed = 20;
                jump = 15;
            }
            else{
                speed = 7;
                jump = 10;
            }
        }
        
        //téléporte le joueur si il tombe
        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d7) )
        {
            gameObject.transform.position = new Vector3(0, -56, 0);
            waiting = true;
            if((gameObject.transform.position.y > -1) && waiting == true){
                Thread.Sleep(1000);
                waiting = false;
            }
        }

        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d4) )
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
            waiting = true;
            if((gameObject.transform.position.y > -1) && waiting == true){
                Thread.Sleep(1000);
                waiting = false;
            }
        }

        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d5) )
        {
            gameObject.transform.position = new Vector3(0, -56, 0);
            waiting = true;
            if((gameObject.transform.position.y > -1) && waiting == true){
                Thread.Sleep(1000);
                waiting = false;
            }
        }

        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d6) )
        {
            gameObject.transform.position = new Vector3(14, -104, 0);
            waiting = true;
            if((gameObject.transform.position.y > -1) && waiting == true){
                Thread.Sleep(1000);
                waiting = false;
            }
        }
        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d8) )
        {
            gameObject.transform.position = new Vector3(14, -104, 0);
            waiting = true;
            if((gameObject.transform.position.y > -1) && waiting == true){
                Thread.Sleep(1000);
                waiting = false;
            }
        }
        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d9) )
        {
            gameObject.transform.position = new Vector3(14, -104, 0);
            waiting = true;
            if((gameObject.transform.position.y > -1) && waiting == true){
                Thread.Sleep(1000);
                waiting = false;
            }
        }
        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d13) )
        {
            gameObject.transform.position = new Vector3(3, 0, 0);
            waiting = true;
            if((gameObject.transform.position.y > -1) && waiting == true){
                Thread.Sleep(1000);
                waiting = false;
            }
        }

        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d10) )
        {
            if (canbedamaged == true){
                canbedamaged = false;
                hearts--;
            }
        if (hearts < 3){
            if (coeurdetruit == 0){
                canbedamaged = false;
                if (heart1 = true){
                    Destroy(bc2d11.gameObject);
                    heart1 = false;
                }
                Jump();
                Invoke("Damaged", 1.0f);
            }
        }
        if (hearts < 2){
            Destroy(bc2d13.gameObject);
            if (coeurdetruit == 1){
                canbedamaged = false;
                if (heart2 = true){
                    Destroy(bc2d12.gameObject);
                    heart2 = false;
                }
                Jump();
                Invoke("Damaged", 1.0f);
            }
        }
        if (hearts < 1){
            if (coeurdetruit == 2){
                canbedamaged = false;
                if (heart3 = true){
                    heart3 = false;
                }
                Jump();
                Invoke("Damaged", 1.0f);
                Thread.Sleep(2000);
                Application.LoadLevel(0);
            }
        }
        }
        

        //si la clée est touchée, le joueur, le jeu le retient et la cache
        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d1) )
        {
            if(key == false){
                Destroy(bc2d1.gameObject);
                key = true;
            }
        }

        //Vérifie si le joueur touche la porte en ayant la clé, et si oui, l'ouvre
        if ( body.gameObject.GetComponent<BoxCollider2D>().IsTouching(bc2d2)&& key==true)
        {
            Destroy(bc2d2.gameObject);
        }
    }
    private void Jump() { 

            body.velocity = new Vector2(body.velocity.x, jump * 2);
            if (jumps == 0)
                grounded = false;
            else
                jumps--;
    }
    private void Damaged() {
        if(hearts < 3){
        coeurdetruit = 2;
        }
        if(hearts < 2){
        coeurdetruit = 1;
        }
        canbedamaged = true;
        hearts = 0;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground"){
            grounded = true;
            jumps = 5;
        }
        if ((collision.gameObject.tag == "Door") && key == true)
            Destroy(bc2d2.gameObject);
    }
}
