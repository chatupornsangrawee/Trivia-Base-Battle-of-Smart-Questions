using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class QuestionAnswer
{
    public string question;
    public string answer;
    public string explanation;

    public QuestionAnswer(string question, string answer, string explanation)
    {
        this.question = question;
        this.answer = answer;
        this.explanation = explanation;
    }
}

public class GameController : MonoBehaviour
{
    public GameObject[] targets;
    public int maxHits = 5;
    public InputField answerInputField;
    public Text questionText;
    public Text resultText;
    public Text explanationText;
    public string[] scenesToLoadOnCorrect;
    public string retryScene;
    public int maxCorrectAnswers = 200;
    public int maxWrongAnswers = 10;
    public GameObject enemyEffectPrefab;

    private int currentHits = 0;
    public int currentQuestion = 0;
    public int n = 0;
    private int correctAnswers = 0;
    private int wrongAnswers = 0;
    private bool canAttack = false;

    private List<QuestionAnswer> questionList;

    private Dictionary<GameObject, int> targetHits = new Dictionary<GameObject, int>();

    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
        resultText.gameObject.SetActive(false);
        explanationText.gameObject.SetActive(false);

        questionList = new List<QuestionAnswer>
        {
            new QuestionAnswer(
        "#include <stdio.h>\n\nint main() {\n    int i, s = 0;\n    int n = 10;\n    i = 1;\n\n    while (i <= n) {\n        ______; // Add this line to add i to s\n        i++;\n    }\n\n    printf(\"Sum = %d\", s);\n    return 0;\n}",
        "s += i",
        "Sum = 55"          
            ),
            new QuestionAnswer("Question 2?", "2", "Explanation for Question 2."),
            new QuestionAnswer("Question 3?", "3", "Explanation for Question 3."),
            new QuestionAnswer("Question 4?", "4", "Explanation for Question 4."),
            new QuestionAnswer("Question 5?", "5", "Explanation for Question 5."), 
            new QuestionAnswer("Question 6?", "6", "Explanation for Question 6."),
            new QuestionAnswer("Question 7?", "7", "Explanation for Question 7."),
            new QuestionAnswer("Question 8?", "8", "Explanation for Question 8."),
            new QuestionAnswer("Question 9?", "9", "Explanation for Question 9."),
            new QuestionAnswer("Question 10?", "10", "Explanation for Question 10."),
            new QuestionAnswer("Question 11?", "11", "Explanation for Question 11."),
            new QuestionAnswer("Question 12?", "12", "Explanation for Question 12."),
            new QuestionAnswer("Question 13?", "13", "Explanation for Question 13."),
            new QuestionAnswer("Question 14?", "14", "Explanation for Question 14."),
            new QuestionAnswer("Question 15?", "15", "Explanation for Question 15."),
            new QuestionAnswer("Question 16?", "16", "Explanation for Question 16."),
            new QuestionAnswer("Question 17?", "17", "Explanation for Question 17."),
            new QuestionAnswer("Question 18?", "18", "Explanation for Question 18."),
            new QuestionAnswer("Question 19?", "19", "Explanation for Question 19."),
            new QuestionAnswer("Question 20?", "20", "Explanation for Question 20."),
            new QuestionAnswer("Question 21?", "21", "Explanation for Question 21."),
            new QuestionAnswer("Question 22?", "22", "Explanation for Question 22."),
            new QuestionAnswer("Question 23?", "23", "Explanation for Question 23."),
            new QuestionAnswer("Question 24?", "24", "Explanation for Question 24."),
            new QuestionAnswer("Question 25?", "25", "Explanation for Question 25."),
            new QuestionAnswer("Question 26?", "26", "Explanation for Question 26."),
            new QuestionAnswer("Question 27?", "27", "Explanation for Question 27."),
            new QuestionAnswer("Question 28?", "28", "Explanation for Question 28."),
            new QuestionAnswer("Question 29?", "29", "Explanation for Question 29."),
            new QuestionAnswer("Question 30?", "30", "Explanation for Question 30."),
            new QuestionAnswer("Question 31?", "31", "Explanation for Question 31."),
            new QuestionAnswer("Question 32?", "32", "Explanation for Question 32."),
            new QuestionAnswer("Question 33?", "33", "Explanation for Question 33."),
            new QuestionAnswer("Question 34?", "34", "Explanation for Question 34."),
            new QuestionAnswer("Question 35?", "35", "Explanation for Question 35."), 
            new QuestionAnswer("Question 36?", "36", "Explanation for Question 36."),
            new QuestionAnswer("Question 37?", "37", "Explanation for Question 37."),
            new QuestionAnswer("Question 38?", "38", "Explanation for Question 38."),
            new QuestionAnswer("Question 39?", "39", "Explanation for Question 39."),
            new QuestionAnswer("Question 40?", "40", "Explanation for Question 40."),
            new QuestionAnswer("Question 41?", "41", "Explanation for Question 41."),
            new QuestionAnswer("Question 42?", "42", "Explanation for Question 42."),
            new QuestionAnswer("Question 43?", "43", "Explanation for Question 43."),
            new QuestionAnswer("Question 44?", "44", "Explanation for Question 44."),
            new QuestionAnswer("Question 45?", "45", "Explanation for Question 45."),
            new QuestionAnswer("Question 46?", "46", "Explanation for Question 46."),
            new QuestionAnswer("Question 47?", "47", "Explanation for Question 47."),
            new QuestionAnswer("Question 48?", "48", "Explanation for Question 48."),
            new QuestionAnswer("Question 49?", "49", "Explanation for Question 49."),
            new QuestionAnswer("Question 50?", "50", "Explanation for Question 50."),
            new QuestionAnswer("Question 51?", "51", "Explanation for Question 51."),
            new QuestionAnswer("Question 52?", "52", "Explanation for Question 52."),
            new QuestionAnswer("Question 53?", "53", "Explanation for Question 53."),
            new QuestionAnswer("Question 54?", "54", "Explanation for Question 54."),
            new QuestionAnswer("Question 55?", "55", "Explanation for Question 55."),
            new QuestionAnswer("Question 56?", "56", "Explanation for Question 56."),
            new QuestionAnswer("Question 57?", "57", "Explanation for Question 57."),
            new QuestionAnswer("Question 58?", "58", "Explanation for Question 58."),
            new QuestionAnswer("Question 59?", "59", "Explanation for Question 59."),
            new QuestionAnswer("Question 60?", "60", "Explanation for Question 60."),
            new QuestionAnswer("Question 61?", "61", "Explanation for Question 61."),
            new QuestionAnswer("Question 62?", "62", "Explanation for Question 62."),
            new QuestionAnswer("Question 63?", "63", "Explanation for Question 63."),
            new QuestionAnswer("Question 64?", "64", "Explanation for Question 64."),
            new QuestionAnswer("Question 65?", "65", "Explanation for Question 65."),
            new QuestionAnswer("Question 66?", "66", "Explanation for Question 66."),
            new QuestionAnswer("Question 67?", "67", "Explanation for Question 67."),
            new QuestionAnswer("Question 68?", "68", "Explanation for Question 68."),
            new QuestionAnswer("Question 69?", "69", "Explanation for Question 69."),
            new QuestionAnswer("Question 70?", "70", "Explanation for Question 70."),
            new QuestionAnswer("Question 71?", "71", "Explanation for Question 71."),
            new QuestionAnswer("Question 72?", "72", "Explanation for Question 72."),
            new QuestionAnswer("Question 73?", "73", "Explanation for Question 73."),
            new QuestionAnswer("Question 74?", "74", "Explanation for Question 74."),
            new QuestionAnswer("Question 75?", "75", "Explanation for Question 75."),
            new QuestionAnswer("Question 76?", "76", "Explanation for Question 76."),
            new QuestionAnswer("Question 77?", "77", "Explanation for Question 77."),
            new QuestionAnswer("Question 78?", "78", "Explanation for Question 78."),
            new QuestionAnswer("Question 79?", "79", "Explanation for Question 79."),
            new QuestionAnswer("Question 80?", "80", "Explanation for Question 80."),
            new QuestionAnswer("Question 81?", "81", "Explanation for Question 81."),
            new QuestionAnswer("Question 82?", "82", "Explanation for Question 82."),
            new QuestionAnswer("Question 83?", "83", "Explanation for Question 83."),
            new QuestionAnswer("Question 84?", "84", "Explanation for Question 84."),
            new QuestionAnswer("Question 85?", "85", "Explanation for Question 85."),
            new QuestionAnswer("Question 86?", "86", "Explanation for Question 86."),
            new QuestionAnswer("Question 87?", "87", "Explanation for Question 87."),
            new QuestionAnswer("Question 88?", "88", "Explanation for Question 88."),
            new QuestionAnswer("Question 89?", "89", "Explanation for Question 89."),
            new QuestionAnswer("Question 90?", "90", "Explanation for Question 90."),
            new QuestionAnswer("Question 91?", "91", "Explanation for Question 91."),
            new QuestionAnswer("Question 92?", "92", "Explanation for Question 92."),
            new QuestionAnswer("Question 93?", "93", "Explanation for Question 93."),
            new QuestionAnswer("Question 94?", "94", "Explanation for Question 94."),
            new QuestionAnswer("Question 95?", "95", "Explanation for Question 95."),
            new QuestionAnswer("Question 96?", "96", "Explanation for Question 96."),
            new QuestionAnswer("Question 97?", "97", "Explanation for Question 97."),
            new QuestionAnswer("Question 98?", "98", "Explanation for Question 98."),
            new QuestionAnswer("Question 99?", "99", "Explanation for Question 99."),
            new QuestionAnswer("Question 100?", "100", "Explanation for Question 100."), 
            new QuestionAnswer("Question 101?", "101", "Explanation for Question 101."),
            new QuestionAnswer("Question 102?", "102", "Explanation for Question 102."),
            new QuestionAnswer("Question 103?", "103", "Explanation for Question 103."),
            new QuestionAnswer("Question 104?", "104", "Explanation for Question 104."),
            new QuestionAnswer("Question 105?", "105", "Explanation for Question 105."),
            new QuestionAnswer("Question 106?", "106", "Explanation for Question 106."),
            new QuestionAnswer("Question 107?", "107", "Explanation for Question 107."),
            new QuestionAnswer("Question 108?", "108", "Explanation for Question 108."),
            new QuestionAnswer("Question 109?", "109", "Explanation for Question 109."),
            new QuestionAnswer("Question 110?", "110", "Explanation for Question 110."),
            new QuestionAnswer("Question 111?", "111", "Explanation for Question 111."),
            new QuestionAnswer("Question 112?", "112", "Explanation for Question 112."),
            new QuestionAnswer("Question 113?", "113", "Explanation for Question 113."),
            new QuestionAnswer("Question 114?", "114", "Explanation for Question 114."),
            new QuestionAnswer("Question 115?", "115", "Explanation for Question 115."),
            new QuestionAnswer("Question 116?", "116", "Explanation for Question 116."),
            new QuestionAnswer("Question 117?", "117", "Explanation for Question 117."),
            new QuestionAnswer("Question 118?", "118", "Explanation for Question 118."),
            new QuestionAnswer("Question 119?", "119", "Explanation for Question 119."),
            new QuestionAnswer("Question 120?", "120", "Explanation for Question 120."),
            new QuestionAnswer("Question 121?", "121", "Explanation for Question 121."),
            new QuestionAnswer("Question 122?", "122", "Explanation for Question 122."),
            new QuestionAnswer("Question 123?", "123", "Explanation for Question 123."),
            new QuestionAnswer("Question 124?", "124", "Explanation for Question 124."),
            new QuestionAnswer("Question 125?", "125", "Explanation for Question 125."),
            new QuestionAnswer("Question 126?", "126", "Explanation for Question 126."),
            new QuestionAnswer("Question 127?", "127", "Explanation for Question 127."),
            new QuestionAnswer("Question 128?", "128", "Explanation for Question 128."),
            new QuestionAnswer("Question 129?", "129", "Explanation for Question 129."),
            new QuestionAnswer("Question 130?", "130", "Explanation for Question 130."),
            new QuestionAnswer("Question 131?", "131", "Explanation for Question 131."),
            new QuestionAnswer("Question 132?", "132", "Explanation for Question 132."),
            new QuestionAnswer("Question 133?", "133", "Explanation for Question 133."),
            new QuestionAnswer("Question 134?", "134", "Explanation for Question 134."),
            new QuestionAnswer("Question 135?", "135", "Explanation for Question 135."),
            new QuestionAnswer("Question 136?", "136", "Explanation for Question 136."),
            new QuestionAnswer("Question 137?", "137", "Explanation for Question 137."),
            new QuestionAnswer("Question 138?", "138", "Explanation for Question 138."),
            new QuestionAnswer("Question 139?", "139", "Explanation for Question 139."),
            new QuestionAnswer("Question 140?", "140", "Explanation for Question 140."),
            new QuestionAnswer("Question 141?", "141", "Explanation for Question 141."),
            new QuestionAnswer("Question 142?", "142", "Explanation for Question 142."),
            new QuestionAnswer("Question 143?", "143", "Explanation for Question 143."),
            new QuestionAnswer("Question 144?", "144", "Explanation for Question 144."),
            new QuestionAnswer("Question 145?", "145", "Explanation for Question 145."),
            new QuestionAnswer("Question 146?", "146", "Explanation for Question 146."),
            new QuestionAnswer("Question 147?", "147", "Explanation for Question 147."),
            new QuestionAnswer("Question 148?", "148", "Explanation for Question 148."),
            new QuestionAnswer("Question 149?", "149", "Explanation for Question 149."),
            new QuestionAnswer("Question 150?", "150", "Explanation for Question 150."),
            new QuestionAnswer("Question 151?", "151", "Explanation for Question 151."),
            new QuestionAnswer("Question 152?", "152", "Explanation for Question 152."),
            new QuestionAnswer("Question 153?", "153", "Explanation for Question 153."),
            new QuestionAnswer("Question 154?", "154", "Explanation for Question 154."),
            new QuestionAnswer("Question 155?", "155", "Explanation for Question 155."),
            new QuestionAnswer("Question 156?", "156", "Explanation for Question 156."),
            new QuestionAnswer("Question 157?", "157", "Explanation for Question 157."),
            new QuestionAnswer("Question 158?", "158", "Explanation for Question 158."),
            new QuestionAnswer("Question 159?", "159", "Explanation for Question 159."),
            new QuestionAnswer("Question 160?", "160", "Explanation for Question 160."),
            new QuestionAnswer("Question 161?", "161", "Explanation for Question 161."),
            new QuestionAnswer("Question 162?", "162", "Explanation for Question 162."),
            new QuestionAnswer("Question 163?", "163", "Explanation for Question 163."),
            new QuestionAnswer("Question 164?", "164", "Explanation for Question 164."),
            new QuestionAnswer("Question 165?", "165", "Explanation for Question 165."),
            new QuestionAnswer("Question 166?", "166", "Explanation for Question 166."),
            new QuestionAnswer("Question 167?", "167", "Explanation for Question 167."),
            new QuestionAnswer("Question 168?", "168", "Explanation for Question 168."),
            new QuestionAnswer("Question 169?", "169", "Explanation for Question 169."),
            new QuestionAnswer("Question 170?", "170", "Explanation for Question 170."),
            new QuestionAnswer("Question 171?", "171", "Explanation for Question 171."),
            new QuestionAnswer("Question 172?", "172", "Explanation for Question 172."),
            new QuestionAnswer("Question 173?", "173", "Explanation for Question 173."),
            new QuestionAnswer("Question 174?", "174", "Explanation for Question 174."),
            new QuestionAnswer("Question 175?", "175", "Explanation for Question 175."),
            new QuestionAnswer("Question 176?", "176", "Explanation for Question 176."),
            new QuestionAnswer("Question 177?", "177", "Explanation for Question 177."),
            new QuestionAnswer("Question 178?", "178", "Explanation for Question 178."),
            new QuestionAnswer("Question 179?", "179", "Explanation for Question 179."),
            new QuestionAnswer("Question 180?", "180", "Explanation for Question 180."),
            new QuestionAnswer("Question 181?", "181", "Explanation for Question 181."),
            new QuestionAnswer("Question 182?", "182", "Explanation for Question 182."),
            new QuestionAnswer("Question 183?", "183", "Explanation for Question 183."),
            new QuestionAnswer("Question 184?", "184", "Explanation for Question 184."),
            new QuestionAnswer("Question 185?", "185", "Explanation for Question 185."),
            new QuestionAnswer("Question 186?", "186", "Explanation for Question 186."),
            new QuestionAnswer("Question 187?", "187", "Explanation for Question 187."),
            new QuestionAnswer("Question 188?", "188", "Explanation for Question 188."),
            new QuestionAnswer("Question 189?", "189", "Explanation for Question 189."),
            new QuestionAnswer("Question 190?", "190", "Explanation for Question 190."),
            new QuestionAnswer("Question 191?", "191", "Explanation for Question 191."),
            new QuestionAnswer("Question 192?", "192", "Explanation for Question 192."),
            new QuestionAnswer("Question 193?", "193", "Explanation for Question 193."),
            new QuestionAnswer("Question 194?", "194", "Explanation for Question 194."),
            new QuestionAnswer("Question 195?", "195", "Explanation for Question 195."),
            new QuestionAnswer("Question 196?", "196", "Explanation for Question 196."),
            new QuestionAnswer("Question 197?", "197", "Explanation for Question 197."),
            new QuestionAnswer("Question 198?", "198", "Explanation for Question 198."),
            new QuestionAnswer("Question 199?", "199", "Explanation for Question 199."),
            new QuestionAnswer("Question 200?", "200", "Explanation for Question 200.")
       
        };

        

        foreach (GameObject target in targets)
        {
            targetHits[target] = 0;
        }
        
        AskQuestion();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                GameObject clickedObject = hit.collider.gameObject;

                if (IsTarget(clickedObject) && canAttack)
                {
                    HandleTargetHit(clickedObject);
                }
            }
        }
    }

    bool IsTarget(GameObject obj)
    {
        return System.Array.Exists(targets, target => target == obj);
    }

    void HandleTargetHit(GameObject target)
    {
        targetHits[target]++;

        if (canAttack)
        {
            Debug.Log("Attacking!");
            resultText.text = "Attacking!";
            resultText.color = Color.green;
            resultText.gameObject.SetActive(true);

            StartCoroutine(ShowEnemyEffect(target.transform.position));

            canAttack = false;
        }
        else
        {
            Debug.Log("Can't attack without permission!");
            resultText.text = "Can't attack without permission!";
            resultText.color = Color.red;
            resultText.gameObject.SetActive(true);
        }

        if (targetHits[target] >= maxHits)
        {
            targetHits[target] = 0;

            DestroyTarget(target);
            
        }
    }

    void DestroyTarget(GameObject target)
    {
        Destroy(target);
    }

    IEnumerator ShowEnemyEffect(Vector2 position)
    {
        Debug.Log("Showing Enemy Effect at position: " + position);

        GameObject enemyEffect = Instantiate(enemyEffectPrefab, position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(enemyEffect);
    }

    void AskQuestion()
    {
        if (currentQuestion < questionList.Count)
        {
            questionText.text = questionList[currentQuestion].question;
            answerInputField.gameObject.SetActive(true);
            answerInputField.ActivateInputField();
            answerInputField.Select();
            canAttack = false;
            resultText.gameObject.SetActive(false);

            explanationText.text = questionList[currentQuestion].explanation;
            explanationText.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Game Over");
        }

        resultText.gameObject.SetActive(true);

        if (currentQuestion > n)
        {
            string playerAnswer = answerInputField.text;
            string correctAnswer = questionList[currentQuestion - 1].answer;

            if (playerAnswer.ToLower() == correctAnswer.ToLower())
            {
                Debug.Log("Correct Answer!");
                canAttack = true;
                resultText.text = "Correct Answer!";
                resultText.color = Color.green;
            }
            else
            {
                Debug.Log("Wrong Answer!");

                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

                foreach (GameObject player in players)
                {
                    Renderer playerRenderer = player.GetComponent<Renderer>();
                    if (playerRenderer != null)
                    {
                        StartCoroutine(FlashRed(playerRenderer.material, 1f));
                    }

                    StartCoroutine(ShakeObject(player.transform, 1f));
                }

                MoveTargetsOnWrongAnswer();

                canAttack = false;
                resultText.text = "Wrong Answer!";
                resultText.color = Color.red;
            }
        }
    }

    public void SubmitAnswer()
    {
        string playerAnswer = answerInputField.text;
        string correctAnswer = questionList[currentQuestion].answer;

        if (playerAnswer.ToLower() == correctAnswer.ToLower())
        {
            Debug.Log("Correct Answer!");
            resultText.text = "Correct Answer!";
            resultText.color = Color.green;
            correctAnswers++;
        }
        else
        {
            Debug.Log("Wrong Answer!");

            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            foreach (GameObject player in players)
            {
                Renderer playerRenderer = player.GetComponent<Renderer>();
                if (playerRenderer != null)
                {
                    StartCoroutine(FlashRed(playerRenderer.material, 1f));
                }

                StartCoroutine(ShakeObject(player.transform, 1f));
            }

            MoveTargetsOnWrongAnswer();

            resultText.text = "Wrong Answer!";
            resultText.color = Color.red;
            wrongAnswers++;
        }

        resultText.gameObject.SetActive(true);

        if (correctAnswers >= maxCorrectAnswers)
        {
            if (currentQuestion < scenesToLoadOnCorrect.Length)
            {
                LoadScene(scenesToLoadOnCorrect[currentQuestion]);
            }
            else
            {
                Debug.Log("All scenes completed!");
            }
        }
        else if (wrongAnswers >= maxWrongAnswers)
        {
            StartCoroutine(GameOverCoroutine());
        }
        else
        {
            currentQuestion++;
            AskQuestion();
        }
    }

    IEnumerator GameOverCoroutine()
    {
        Debug.Log("GAME OVER");
        resultText.text = "GAME OVER";
        resultText.color = Color.red;
        resultText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    IEnumerator FlashRed(Material material, float duration)
    {
        float elapsed = 0f;
        Color originalColor = material.color;
        Color flashColor = Color.red;

        while (elapsed < duration)
        {
            material.color = Color.Lerp(originalColor, flashColor, elapsed / duration);

            elapsed += Time.deltaTime;

            yield return null;
        }

        material.color = originalColor;
    }

    IEnumerator ShakeObject(Transform objectTransform, float duration)
    {
        float elapsed = 0f;
        Vector3 originalPosition = objectTransform.position;

        while (elapsed < duration)
        {
            float x = originalPosition.x + Mathf.Sin(Random.Range(0, 360f)) * 0.1f;
            float y = originalPosition.y + Mathf.Sin(Random.Range(0, 360f)) * 0.1f;

            objectTransform.position = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        objectTransform.position = originalPosition;
    }

    void MoveTargetsOnWrongAnswer()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject target in targets)
        {
            StartCoroutine(MoveTargetLocal(target.transform, new Vector3(-6f, 0f, 0f), 0.5f));
        }
    }

    IEnumerator MoveTargetLocal(Transform targetTransform, Vector3 localTargetPosition, float duration)
    {
        float elapsed = 0f;
        Vector3 originalPosition = targetTransform.localPosition;

        float originalLocalY = targetTransform.localPosition.y;

        while (elapsed < duration)
        {
            localTargetPosition.y = originalLocalY;

            targetTransform.localPosition = Vector3.Lerp(originalPosition, localTargetPosition, elapsed / duration);
            elapsed += Time.deltaTime;

            yield return null;
        }

        targetTransform.localPosition = originalPosition;
    }
}
