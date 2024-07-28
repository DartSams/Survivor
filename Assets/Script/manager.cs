using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class manager : MonoBehaviour
{
    playerSctipt ps;
    public GameObject player;
    public string weapon;
    public List<GameObject> passiveWeapons;
    public List<GameObject> upgrades;
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
        spawnEnemy();
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
            spawnEnemy();
        }
    }

    void updateWave()
    {
        wave++;
        waveText.text = "Wave " + wave.ToString();
    }

    void spawnEnemy()
    {
        if (wave % 10 == 0 || wave % 2 == 0)
        {
            enemy.GetComponent<enemyScript>().upgradeHealth();
            //every 10 levels make a boss spawn
        }
        for (int i = 0; i < 1 * wave; i++)
        {
            Vector2 randomPos = new Vector2(Random.Range(-15f, 15f), Random.Range(-15f, 15f));
            GameObject e = Instantiate(enemy, randomPos, Quaternion.identity);
            enemyList.Add(e);
        }
    }

    void spawnUpgradeItem()
    {
        if (ps.coins % 10 == 0)
        {
            //spawn random upgrade item from list
        }
    }

    public void RemoveEnemyFromList(GameObject enemy)
    {
        enemyList.Remove(enemy);
    }

}
