using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class M_GameManager : MonoBehaviour
{
    string monsterTag = "Monster";

    public GameObject beast;
    public GameObject driller;
    public GameObject diver;
    public GameObject ticker;
    public GameObject flyer;
    public GameObject worm;
    public GameObject shifter;
    public GameObject bolter;

    string mBeast = "Beast";
    string mDriller = "Driller";
    string mDiver = "Diver";
    string mTicker = "Ticker";
    string mWorm = "Worm";
    string mShifter = "Shifter";
    string mBolter = "Bolter";
    string mFlyer = "Flyer";

    public float x = 0;
    int y;

    public float waveTime;
    public float waveTimer;
    public int wave = 1;
    public float waveSpawnTime;
    public float spawnDuration; 
        

    public bool spawnMonster = false;

    public Slider slider;

    private void Start()
    {
        int monsterCount = CountWithTag(monsterTag);
        Debug.Log(" 몬스터 숫자 : " + monsterCount);

        waveTime = 10 + wave * 5;
        waveTimer = waveTime;
        spawnDuration = 6;

    }

    private void Update()
    {
        slider.value = waveTimer / waveTime;
        y = wave;
        if( wave > 6)
        {
            y = 6;
        }

        #region 몬스터 스폰시스템

        if (spawnMonster)
        {
            
            switch (wave)
            {
                case 6:
                case 4:
                case 3:
                case 2:
                case 1:
                    break;
            }


            Make(mBolter);
            Make(mDriller);
            Make(mDiver);
            Make(mTicker);
            Make(mWorm);
            Make(mShifter);
            Make(mBeast);
            Make(mFlyer);

            x += Time.deltaTime;

            if (x > spawnDuration)
            {
                Make(mBolter);
                Make(mDriller);
                Make(mDiver);
                Make(mTicker);
                Make(mWorm);
                Make(mShifter);
                Make(mBeast);
                Make(mFlyer);

                x = 0;

                int monsterCount = CountWithTag(monsterTag);
                Debug.Log(" 몬스터 숫자 : " + monsterCount);
            }

        }

        #endregion

        #region 타이머

        if (waveTimer > 0)
        {
            waveTimer -= Time.deltaTime;
        }

        if (waveTimer <= 0)
        {
            spawnMonster = true;
            spawnDuration = 6;
        }

        if(spawnMonster)
        {
            waveSpawnTime += Time.deltaTime;
        }
        // 슬라이더 = wavetimer / wavetime

        #endregion

        #region 웨이브 시스템

        if( waveTimer <0 && waveSpawnTime > waveTime/2 && CountWithTag(monsterTag) == 0) // 웨이브 지속시간 끝, 몬스터 전부 처리, 타이머 0일떄
        {
            // 웨이브 끝남
            
            spawnMonster = false;
            wave++;

            waveTime = 10 + wave * 5;
            if (waveTime > 60)
            {
                waveTime = 60;
            }

            waveTimer = waveTime;
            waveSpawnTime = 0;
        }
        else if ( waveSpawnTime < waveTime / 2)
        {
            spawnDuration = 12;
        }

        #endregion
    }





    private int CountWithTag(string tag)
    {
        GameObject[] tagNum = GameObject.FindGameObjectsWithTag(tag);
        return tagNum.Length;
    }

    void Make(string name)
    {
        Vector2 pos;
        int toggle = (int)((Random.Range(0, 2) - 0.5f) * 2);
        float diverX;


        switch (name)
        {
            case "Beast":
                pos = new Vector2(25 * toggle, Random.Range(-7f, -9f));
                Instantiate(beast, pos, Quaternion.identity);
                break;

            case "Bolter":
                pos = new Vector2(25 * toggle, Random.Range(-2f, 3f));
                Instantiate(bolter, pos, Quaternion.identity);
                break;

            case "Diver":
                diverX = Random.Range(0f, 40f);
                if (diverX < 15f) pos = new Vector2(27 * toggle, diverX);
                else pos = new Vector2((diverX - 15) * toggle, 15);
                Instantiate(diver, pos, Quaternion.identity);
                break;

            case "Driller":
                pos = new Vector2(25 * toggle, Random.Range(-7f, -8f));
                Instantiate(driller, pos, Quaternion.identity);
                break;

            case "Flyer":
                diverX = Random.Range(0f, 40f);
                if (diverX < 15f) pos = new Vector2(27 * toggle, diverX);
                else pos = new Vector2((diverX - 15) * toggle, 15);
                Instantiate(flyer, pos, Quaternion.identity);
                break;

            case "Shifter":
                pos = new Vector2(25 * toggle, Random.Range(-7f, -8f));
                Instantiate(shifter, pos, Quaternion.identity);
                break;

            case "Ticker":
                for (int i = 0; i < Random.Range(11, 26); i++)
                {
                    pos = new Vector2( Random.Range(25f,28f) * toggle, Random.Range(-8f, -10f));
                    Instantiate(ticker, pos, Quaternion.identity);
                }
                break;

            case "Worm":
                pos = new Vector2(Random.Range(10f, 18f) * toggle, Random.Range(-7f, -8f));
                Instantiate(worm, pos, Quaternion.identity);
                break;

        }
    }
}
