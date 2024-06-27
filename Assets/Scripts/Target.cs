using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject targetPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision2D)
    {
        string tag = collision2D.gameObject.tag;
        if (tag == "Fireball")
        {
            float x = Random.Range(-9, 9);
            float y = Random.value * 10 - 5;
            Instantiate(targetPrefab, new Vector3(x, y, 0), Quaternion.identity);
            Destroy(gameObject);
            GameManager.Instance.score++;


            Wizard player = Wizard.player;
            PlayerStats stats = Wizard.stats;
            stats.GainXp(1);
        }


    }

}
