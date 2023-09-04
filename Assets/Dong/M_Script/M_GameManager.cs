using UnityEngine;

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

    public Transform domeCenter;

    string mBeast = "Beast";
    string mDriller = "Driller";
    string mDiver = "Diver";
    string mTicker = "Ticker";
    string mWorm = "Worm";
    string mShifter = "Shifter";
    string mBolter = "Bolter";
    string mFlyer = "Flyer";

    public float x = 0;

    private void Start()
    {
        int monsterCount = CountWithTag(monsterTag);
        Debug.Log(" ���� ���� : " + monsterCount);
<<<<<<< HEAD

        waveTime = 10 + wave * 5;
        waveTimer = waveTime;
        spawnDuration = 4;


        Make(mDiver); Make(mDiver); Make(mDiver); Make(mDiver); Make(mDiver); Make(mDiver);

=======
        
>>>>>>> 3c877c4b82534b0524d13982333ecd1c28fe9e5b
    }

    private void Update()
    {
        x += Time.deltaTime;

        if(x > 2)
        {
<<<<<<< HEAD
            y = 6;
        }

        #region ���� �����ý���

        if (spawnMonster)
        {
            

            x += Time.deltaTime;

            if (x > spawnDuration)
            {
/*                Make(mBolter);
                Make(mDriller);
                Make(mDiver);
                Make(mTicker);
                Make(mWorm);
                Make(mShifter);
                Make(mBeast);
                Make(mFlyer);*/

                x = 0;

                int monsterCount = CountWithTag(monsterTag);
                Debug.Log(" ���� ���� : " + monsterCount);
            }
=======
            Make(mBolter);
            Make(mDriller);
            Make(mDiver);
            Make(mTicker);
            Make(mWorm);
            Make(mShifter);
            Make(mBeast);
            Make(mFlyer);

            x = 0;

>>>>>>> 3c877c4b82534b0524d13982333ecd1c28fe9e5b

            int monsterCount = CountWithTag(monsterTag);
            //Debug.Log(" ���� ���� : " + monsterCount);
        }
<<<<<<< HEAD

        #endregion

        #region Ÿ�̸�

        if (waveTimer > 0)
        {
            waveTimer -= Time.deltaTime;
        }

        if (waveTimer <= 0)
        {
            spawnMonster = true;
            spawnDuration = 4;
        }

        if(spawnMonster)
        {
            waveSpawnTime += Time.deltaTime;
        }
        // �����̴� = wavetimer / wavetime

        #endregion

        #region ���̺� �ý���

        if( waveTimer <0 && waveSpawnTime > waveTime/2 && CountWithTag(monsterTag) == 0) // ���̺� ���ӽð� ��, ���� ���� ó��, Ÿ�̸� 0�ϋ�
        {
            // ���̺� ����
            
            spawnMonster = false;
            wave++;
            waveTime = 10 + wave * 5;
            if (waveTime > 60)
            {
                waveTime = 60;
            }

            waveTimer = waveTime;
            waveSpawnTime = 0;
            x = 0;
        }
        else if ( waveSpawnTime < waveTime / 2)
        {
//            spawnDuration = 12;
        }

        #endregion
=======
>>>>>>> 3c877c4b82534b0524d13982333ecd1c28fe9e5b
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
                pos = new Vector2(25 * toggle, Random.Range(-7f + domeCenter.position.x, -9f + (domeCenter.position.y+9.6f))); ;
                Instantiate(beast, pos, Quaternion.identity);
                break;

            case "Bolter":
                pos = new Vector2(25 * toggle, Random.Range(-2f + domeCenter.position.x, 3f + (domeCenter.position.y + 9.6f)));
                Instantiate(bolter, pos, Quaternion.identity);
                break;

            case "Diver":
                diverX = Random.Range(0f + domeCenter.position.x, 40f + (domeCenter.position.y + 9.6f));
                if (diverX < 15f) pos = new Vector2(27 * toggle, diverX);
                else pos = new Vector2((diverX - 15) * toggle, 15);
                Instantiate(diver, pos, Quaternion.identity);
                break;

            case "Driller":
                pos = new Vector2(25 * toggle, Random.Range(-7f + domeCenter.position.x, -8f + (domeCenter.position.y + 9.6f)));
                Instantiate(driller, pos, Quaternion.identity);
                break;

            case "Flyer":
                diverX = Random.Range(0f + domeCenter.position.x, 40f + (domeCenter.position.y + 9.6f));
                if (diverX < 15f) pos = new Vector2(27 * toggle, diverX);
                else pos = new Vector2((diverX - 15) * toggle, 15);
                Instantiate(flyer, pos, Quaternion.identity);
                break;

            case "Shifter":
                pos = new Vector2(25 * toggle, Random.Range(-7f + domeCenter.position.x, -8f + (domeCenter.position.y + 9.6f)));
                Instantiate(shifter, pos, Quaternion.identity);
                break;

            case "Ticker":
                for (int i = 0; i < Random.Range(11 , 26); i++)
                {
                    pos = new Vector2( Random.Range(25f + domeCenter.position.x, 28f + (domeCenter.position.y + 9.6f)) * toggle, Random.Range(-8f + domeCenter.position.x, -10f + (domeCenter.position.y + 9.6f)));
                    Instantiate(ticker, pos, Quaternion.identity);
                }
                break;

            case "Worm":
                pos = new Vector2(Random.Range(10f + domeCenter.position.x, 18f + (domeCenter.position.y+ 9.6f)) * toggle, Random.Range(-7f + domeCenter.position.x, -8f + (domeCenter.position.y + 9.6f)));
                Instantiate(worm, pos, Quaternion.identity);
                break;

        }
    }
}
