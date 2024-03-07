using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private CoinPool coinpool;
    [Space]
    [SerializeField] private Rigidbody2D coinprefab;
    [SerializeField] [Min(0)] private float fountainduration;
    [SerializeField] private Vector2 randomforcerange_minmax;
    private List<Rigidbody2D> coinz;

    public async Task Fountain(int count)
    {
        Vector2 currballpos = LevelManager.instance.gameball.transform.position;
        coinz = new();
        float timma = 0;
        float persec = count / fountainduration;
        float cumulative = 0;

        while (timma <= fountainduration)
        {
            cumulative += persec * Time.deltaTime;

            for (int i = 0; i < cumulative; i++)
            {
                cumulative--;
                Rigidbody2D coini = coinpool.GetObject();
                coini.transform.SetPositionAndRotation(new Vector2(currballpos.x, currballpos.y + 0.15f), Quaternion.identity);
                coinz.Add(coini);
                coini.AddForce(new Vector2(Random.Range(-randomforcerange_minmax.x, randomforcerange_minmax.x), Random.Range(randomforcerange_minmax.y * 0.5f, randomforcerange_minmax.y)), ForceMode2D.Impulse);
            }

            timma += Time.deltaTime;
            await Task.Yield();
        }
    }

    public void ClearCoins()
    {
        if (coinz == null) return;

        foreach (var coin in coinz)
            if (coin.gameObject.activeInHierarchy) coinpool.StoreObject(coin);
    }

    public void Prefab(int levelmax)
    {
        coinpool.MakeObject(levelmax - coinpool.queue.Count);
    }
}