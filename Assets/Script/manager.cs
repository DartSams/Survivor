using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class manager : MonoBehaviour
{
    playerSctipt ps;
    public GameObject player;
    public string weapon;
    public List<GameObject> passiveWeapons;
    public int coins = 0;
    public int wave = 1;
    public GameObject enemy;
    public List<GameObject> enemyList;
    public TMP_Text waveText;
    // Start is called before the first frame update
    void Awake()
    {
        ps = player.GetComponent<playerSctipt>();
        ps.coins = coins;
        ps.passiveWeapons = passiveWeapons;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        //checkPlayerCoin();
        //ps.coins = coins;
        //ps.passiveWeapons = passiveWeapons;
        //Debug.Log(ps.passiveWeapons);
        if (enemyList.Count <= 0)
        {
            updateWave();
            Spawn();
        }
    }

    void updateWave()
    {
        wave++;
        waveText.text = "Wave " + wave.ToString();
    }

    void Spawn()
    {
        for (int i = 0; i < 5 * wave; i++)
        {
            Vector2 randomPos = new Vector2(Random.Range(-15f, 15f), Random.Range(-15f, 15f));
            GameObject e = Instantiate(enemy, randomPos, Quaternion.identity);
            enemyList.Add(e);
        }
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        enemyList.Remove(enemy);
    }

}
