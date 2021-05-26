**using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Moviment
{
    private Vector3 movePlayer = Vector3.zero;
    private Rigidbody rbPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        moviment();
    }
    //Movimento do Personagem
    protected override void moviment()
    {
        speed = 10f;
        movePlayer = PlayerInputButtons.move().normalized;
        rbPlayer.AddForce(
            movePlayer * speed * Time.deltaTime, 
            ForceMode.Impulse
            );
        base.moviment();
    }
    //Collide with Itens
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Item":
                Destroy(other.gameObject);
                Messages.points++;
                Messages.foundPoints++;
                break;
        }
    }    
}
