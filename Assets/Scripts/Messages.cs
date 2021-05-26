using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Messages : MonoBehaviour
{
    public static int foundPoints = 0;
    public static int points = 0;
    public static int totalPoints = 0;
    public TextMeshProUGUI score;
    private const int endMenuValue = 7;

    private int index;

    //Nome das fases.
    private List<string> scenesName = new List<string>()
    {
        "","Baby","Child","Teen","Young","Adult","Old"
    };

    //Mensagens que aparecem, dependendo do seu desempenho.
    private List<string> phrases = new List<string>()
    {
        "Miserable life, worthless memories",
        "Few memories, great histories",
        "Many memories, some sweet some bitter",
        "At the height of your mind, you have found all the missing fragments."
    };

    private void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        showMessageScore();
    }

    private void showMessageScore()
    {
        //Soma o Index + 3, para o total de itens das fases
        totalPoints = Scenes.buildIndex() + 3;
        index = Scenes.buildIndex();
        

        //Zera os pontos para a proxima fase;
        if (Enemy.isNextLevel)
        {
            totalPoints = index;
            foundPoints = 0;
            Enemy.isNextLevel = false;
        }

        //Verificação de Texto a ser escrito;
        switch (index)
        {
            //Tela final
            case endMenuValue:
                string aux = phrases[verifyPointMessage(points)];
                score.text = aux + "\n\nTotal: " + points + "/39";
                break;
            //No jogo, depois e antes de coletar os itens
            default:
                int resultPoints = totalPoints - foundPoints;
                string aux1 = 
                    (resultPoints == 0) ? 
                    "Confront your bad memories":"";
                //Score Updated
                score.text =
                    scenesName[Scenes.buildIndex()] +
                    " Memories\nTotal/Fragments: " +
                    points.ToString() + "/+" + resultPoints.ToString() + 
                    "\n" + aux1;
                break;
        }
    }

    //Verification of Player's Score in game
    private int verifyPointMessage(int p)
    {
        int r = 
            p < 13 ? 0 : (
            p < 26 ? 1 : (
            p < 39 ? 2 : 3));
        return r;
    }
}
