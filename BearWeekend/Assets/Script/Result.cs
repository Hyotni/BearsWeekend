using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {

    /**
     * 퇴근 후 수입 정산
     */

    // Use this for initialization
    void Start () {
	}

    public GameObject resultMusic;
    public GameObject backMusic;
    public GameObject afterResultBackMusic;

    public Text resultText;
    public Text bonusText;
    public string result;
    public GameObject panel;
    public int resultCoin = 0;
    public int plusCoin = 0;

    private string foodStyle;
    private float foodEffect;

    // Update is called once per frame
    void Update () {

        float time = Time.timeSinceLevelLoad; // 씬이 시작된 후 흐른 시간을 계산

        int h = Mathf.FloorToInt(time / 3600.0f);

        time %= 3600.0f;

        int m = Mathf.FloorToInt(time / 60.0f);

        time %= 60.0f;

        int s = Mathf.FloorToInt(time / 1.0f);

        time %= 1.0f;

        resultCoin = (h * 2000) + (m * 32) + (Mathf.FloorToInt(s * 0.5f)); // 시간에 따른 추가 코인

        if (PlayerPrefs.GetString("Eat") == "YES")
        //음식을 먹었다면
        {
            foodEffect = PlayerPrefs.GetFloat("FoodEffect");

            plusCoin = Mathf.FloorToInt(resultCoin * foodEffect); // 음식 효과로 인한 추가 코인
        }

            resultCoin += plusCoin; // 모든 코인 계산

            result = resultCoin.ToString();

    }

    public void Over()
    {
        backMusic.GetComponent<AudioSource>().Stop();
        resultMusic.GetComponent<AudioSource>().Play();
        afterResultBackMusic.GetComponent<AudioSource>().Play();

        Time.timeScale = 0.0f;

        panel.SetActive(true);
        resultText.text = result; // 결과 표시

        if (PlayerPrefs.GetString("Eat") == "YES")
            // 음식을 먹은 경우
        {
            //음식 보너스 표시
            bonusText.gameObject.SetActive(true);
            bonusText.text = ("+ 음식 보너스 " + plusCoin);
            PlayerPrefs.SetString("Eat","NO");
        }


        PlayerPrefs.SetInt("Coin", resultCoin); // 모든 보상을 얻은 돈으로 저장

        // 먹은 음식 정보 초기화
        PlayerPrefs.SetString("Food", "Empty");
        PlayerPrefs.SetString("FoodStyle", "Empty");
        PlayerPrefs.SetFloat("FoodEffect", 0);

    }

}
