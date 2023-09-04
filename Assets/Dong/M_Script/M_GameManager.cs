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
        Debug.Log(" 몬스터 숫자 : " + monsterCount);
        
    }

    private void Update()
    {
        x += Time.deltaTime;

        if(x > 2)
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
            //Debug.Log(" 몬스터 숫자 : " + monsterCount);
        }
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
