using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightMusic : MonoBehaviour
{
    // cache
    GameMusic _gameMusic; 

    private void Start() {
        _gameMusic = FindObjectOfType<GameMusic>();

        _gameMusic.PlayBossBattleMusic();
    }

    private void OnDestroy() {
        _gameMusic.PlayRegularGameMusic();
    }

}
