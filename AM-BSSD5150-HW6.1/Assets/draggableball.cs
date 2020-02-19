using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggableball : MonoBehaviour
{
    private Rigidbody2D rb;
    Animator animator;
    int state;
    // Start is called before the first frame update

    private bool mousee;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        state = animator.GetInteger("RedToGreen");
    }

    public void OnMouseDown()
    {
        mousee = true;
    }

    public void OnMouseUp()
    {
        mousee = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (mousee)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.transform.SetParent(this.gameObject.transform);
        if (this.gameObject.transform.childCount == 8)
        {
           
            mousee =false;
            state = 1;
            animator.SetInteger("RedToGreen", state);
        }



    }

}
