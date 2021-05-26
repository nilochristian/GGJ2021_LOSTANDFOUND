using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : Moviment
{
    public static bool isNextLevel { set; get; }
    public Transform target;
    private Rigidbody rb;
    private Vector3 pos;
    private int endMenuValue = 6;
    //Inicio
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //Atualização
    private void Update()
    {
        moviment();
    }
    //Movimento do Personagem
    protected override void moviment()
    {
        speed = 3f;
        pos = Vector3.MoveTowards(
            transform.position, 
            target.position, 
            speed * Time.fixedDeltaTime
            );
        rb.MovePosition(pos);
        transform.LookAt(target);

        base.moviment();
    }
    //Colisões
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Player":
                //Verificacao dos pontos coletados
                int verifyGettedPoints = 
                    Messages.totalPoints - Messages.foundPoints;
                //Total de Itens para coletar
                int indexScene = Scenes.buildIndex();
                int collectableItens = indexScene + 3;
                //Retorna verdadeiro caso o jogador não colete nada
                bool isPointScored() => 
                    (verifyGettedPoints - collectableItens) == 0;
                //Game Over, caso o jogador não colete itens
                int sceneLoadIndex = isPointScored() ? 
                    endMenuValue : indexScene;
                SceneManager.LoadScene(sceneLoadIndex + 1);
                //1 item coletado, jogador para a proxima fase
                //Senão, fim de jogo
                isNextLevel = !isPointScored() ? true : false;
                break;
        }
    }
	
}
