using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_ScoreManager : MonoBehaviour
{
    [SerializeField] Text redjemScore;
    [SerializeField] Text bluejemScore;
    [SerializeField] Text greenjemScore;

    [SerializeField] Text petRedjemScore;
    [SerializeField] Text petBluejemScore;
    [SerializeField] Text petGreenjemScore;

    void Update()
    {
        redjemScore.text = S_GameManager.instance.player.redjemScore.ToString();
        bluejemScore.text = S_GameManager.instance.player.bluejemScore.ToString();
        greenjemScore.text = S_GameManager.instance.player.greenjemScore.ToString();

        petRedjemScore.text = S_GameManager.instance.pet.redjemScore.ToString();
        petBluejemScore.text = S_GameManager.instance.pet.bluejemScore.ToString();
        petGreenjemScore.text = S_GameManager.instance.pet.greenjemScore.ToString();

    }
}
