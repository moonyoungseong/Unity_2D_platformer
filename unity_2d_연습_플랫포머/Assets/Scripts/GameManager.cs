using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public PlayerMove player;
    public GameObject[] Stages;

    public void NextStage()
    {
        // Change Stage
        if(stageIndex < Stages.Length-1){
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
            PlayerReposition();
        }
        else{ // Game Clear
            Time.timeScale = 0;
            Debug.Log("게임 클리어");
        }
        
        totalPoint += stagePoint;
        stagePoint = 0;
    }

    public void HealthDown()
    {
        if(health > 1)
            health--;
        else{
            // Plqyer Die Effect
            player.OnDie();
            // Result UI
            Debug.Log("죽었습니다.");
            // Retry Button UI
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"){
            
            if(health > 1)
            {
                // Player Reposition
                PlayerReposition();
            }
            // Health Down
            HealthDown();
        }
    }

    void PlayerReposition()
    {
        player.transform.position = new Vector3(-13,0,-1);
        player.VelocityZero();
    }
}
