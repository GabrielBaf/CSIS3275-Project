

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour {

    private static BattleHandler instance;

    public static BattleHandler GetInstance() {
        return instance;
    }


    [SerializeField] private Transform pfCharacterBattle;
    public Texture2D playerSpritesheet;
   // private int randomPlayerAtck = Random.Range(0,2);
    public Texture2D healerSpritesheet;
    public Texture2D tankSpritesheet;
    public Texture2D enemySpritesheet;
    public Texture2D enemySpritesheet2;
    public Texture2D enemySpritesheet3;
    
    public static bool healerUnlocked = true, tankUnlocked;
    public static bool healerMoving,tankMoving,enemys2 = true,enemys3;
    private CharacterBattle playerCharacterBattle;
    private CharacterBattle healerCharacterBattle;
    private CharacterBattle tankCharacterBattle;
    private CharacterBattle enemyCharacterBattle;
    private CharacterBattle enemyCharacterBattle2;
    private CharacterBattle enemyCharacterBattle3;
    private CharacterBattle activeCharacterBattle;
    private State state;
    private List<CharacterBattle> characterBattleList = new List<CharacterBattle>();


    private enum State {
        WaitingForPlayer,
        Busy,
    }

    private void Awake() {
        characterBattleList = new List<CharacterBattle>();
        instance = this;
    }

    private void Start() {
        playerCharacterBattle = SpawnCharacter(true,false,false,false);
        enemyCharacterBattle = SpawnCharacter(false,false,false,false);
        if(healerUnlocked){
        healerCharacterBattle = SpawnCharacter(true,true,false,false);
        }
        if(enemys2){
            Debug.Log("inimigo 2");
            enemyCharacterBattle2 = SpawnCharacter(false,false,true,false);
        }
        // if(enemys3){
        //     enemyCharacterBattle3 = SpawnCharacter(false,false,false,true);
        // }
        SetActiveCharacterBattle(playerCharacterBattle);
        state = State.WaitingForPlayer;
    }

    private void Update() {
        if (state == State.WaitingForPlayer) {
            
            if(healerMoving == true){
                if (Input.GetKeyDown(KeyCode.Space)) {
                SetActiveCharacterBattle(enemyCharacterBattle);
                state = State.Busy;

                healerCharacterBattle.Attack(enemyCharacterBattle, () => {
                    ChooseNextActiveCharacter();
                });
               healerMoving = false;
            }
                if (Input.GetKeyDown(KeyCode.R)) {
                state = State.Busy;
                SetActiveCharacterBattle(enemyCharacterBattle);
                healerCharacterBattle.SpecialAttack(enemyCharacterBattle, () => {
                    ChooseNextActiveCharacter();
                });
                healerMoving = false;
            }

            }else{
            if (Input.GetKeyDown(KeyCode.Space)) {
                state = State.Busy;
                playerCharacterBattle.Attack(enemyCharacterBattle, () => {
                    ChooseNextActiveCharacter();
                });
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                state = State.Busy;
                playerCharacterBattle.SpecialAttack(enemyCharacterBattle, () => {
                    ChooseNextActiveCharacter();
                });
            }
        }
    }
    }

    private CharacterBattle SpawnCharacter(bool isPlayerTeam,bool isHealer,bool isEnemy2,bool isEnemy3) {
        Vector3 position;
        if (isPlayerTeam) {
            position = new Vector3(-50, 0);
            if(isHealer){
                position = new Vector3(-45, 10);
            }
        } else {
            if(isEnemy2){
            Debug.Log("enemy 2 position");
            position = new Vector3(+40, 10);
            }else{
                position = new Vector3(+50, 0);
            }
            
        }
        Transform characterTransform = Instantiate(pfCharacterBattle, position, Quaternion.identity);
        CharacterBattle characterBattle = characterTransform.GetComponent<CharacterBattle>();
        characterBattle.Setup(isPlayerTeam,isHealer,isEnemy2,isEnemy3);
        characterBattleList.Add(characterBattle);
        return characterBattle;
    }

    private void SetActiveCharacterBattle(CharacterBattle characterBattle) {
        if (activeCharacterBattle != null) {
            activeCharacterBattle.HideSelectionCircle();
        }

        activeCharacterBattle = characterBattle;
        activeCharacterBattle.ShowSelectionCircle();
    }

    private void ChooseNextActiveCharacter() {
        if (TestBattleOver()) {
            return;
        }

        if (activeCharacterBattle == playerCharacterBattle) {
            SetActiveCharacterBattle(enemyCharacterBattle);
            state = State.Busy;
             healerMoving = false;
            enemyCharacterBattle.Attack(playerCharacterBattle, () => {
                ChooseNextActiveCharacter();
            });
        
        // if(activeCharacterBattle == healerCharacterBattle){
        //    SetActiveCharacterBattle(enemyCharacterBattle);
        //     state = State.Busy;
        //      Debug.Log("healer turn");
        //      enemyCharacterBattle.Attack(healerCharacterBattle, () => {
        //      ChooseNextActiveCharacter();
        //      });
        // }
        // if(healerCharacterBattle == activeCharacterBattle){
        //     SetActiveCharacterBattle(enemyCharacterBattle);
           
        //     healerMoving = true;

        //     state = State.Busy;
        //     enemyCharacterBattle.Attack(healerCharacterBattle, () => {
        //         ChooseNextActiveCharacter();
        //     });
        //     ChooseNextActiveCharacter();
        // }
        // if(activeCharacterBattle == enemyCharacterBattle)
        // {
        //     if(checkNextAtack == 0){
         }if(activeCharacterBattle == enemyCharacterBattle){  
               SetActiveCharacterBattle(healerCharacterBattle);
                state = State.WaitingForPlayer;
                healerMoving = true;
         }else{
                SetActiveCharacterBattle(playerCharacterBattle);
                state = State.WaitingForPlayer;
                healerMoving = false;
         }
            // }else{
            //     SetActiveCharacterBattle(playerCharacterBattle);
            //     state = State.WaitingForPlayer;
            //     checkNextAtack = 0;
            //     healerMoving = false;
                
            // }
               
        }

     


    private bool TestBattleOver() {
        if (playerCharacterBattle.IsDead() && healerCharacterBattle.IsDead()) {
            // Player dead, enemy wins
            //CodeMonkey.CMDebug.TextPopupMouse("Enemy Wins!");
            BattleOverWindow.Show_Static("Enemy Wins!");
            return true;
        }
        if (enemyCharacterBattle.IsDead()) {
            // Enemy dead, player wins
            //CodeMonkey.CMDebug.TextPopupMouse("Player Wins!");
            BattleOverWindow.Show_Static("Player Wins!");
            return true;
        }

        return false;
    }
}
