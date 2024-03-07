using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PanelSetter), typeof(CoinSpawner), typeof(LevelTextManager))]
[RequireComponent(typeof(FeverSet), typeof(LevelBarSet), typeof(FeverBlock))]
public class LevelManager : Singleton<LevelManager>
{
    [HideInInspector] public bool levelon;
    private bool alreadyloaded;
    [HideInInspector] public int currentlevelnumber;
    [SerializeField] [Min(0)] private float winpanelrevealdelay;
    [SerializeField] [Min(0)] private float failpanelrevealdelay;
    [HideInInspector] public GameObject gameball;
    public ParticleSystem ballpartisystem;

    private PanelSetter panelsetter;
    private CoinSpawner coinspawner;
    private LevelTextManager leveltextmanager;
    private FeverSet feverset;
    private LevelBarSet levelbarset;
    private FeverBlock feverblock;

    [SerializeField] private Canvas canva;

    protected override void Awake()
    {
        base.Awake();

        panelsetter = GetComponent<PanelSetter>();
        coinspawner = GetComponent<CoinSpawner>();
        leveltextmanager = GetComponent<LevelTextManager>();
        feverset = GetComponent<FeverSet>();
        levelbarset = GetComponent<LevelBarSet>();
        feverblock = GetComponent<FeverBlock>();
        canva = GetComponentInChildren<Canvas>();
    }
    private void Start()
    {
        EnterLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public async void Endgame(bool win, float rewardmultiplier = 0)
    {
        if (!levelon) return;
        levelon = false;
        alreadyloaded = false;

        if (win)
        {
            int reward = CountReward(currentlevelnumber, rewardmultiplier);
            await coinspawner.Fountain(reward);
            if (winpanelrevealdelay > 0) await Task.Delay(Mathf.RoundToInt(winpanelrevealdelay * 1000));
            panelsetter.SetWinPanel();
        } else
        {
            if (failpanelrevealdelay > 0) await Task.Delay(Mathf.RoundToInt(failpanelrevealdelay * 1000));
            panelsetter.SetFailPanel();
        }

        LevelPrefs.Scratch(currentlevelnumber + 1);
    }

    private int CountReward(int level, float multi) => Mathf.RoundToInt(16 + level * 4f * multi);

    public async void LoadLevel(int sceneindex)
    {
        int indeix = sceneindex;
        if (sceneindex >= SceneManager.sceneCountInBuildSettings) indeix = 1;

        await Lodi(indeix);
    }

    public async Task Lodi(int sceneindex)
    {

        SceneManager.LoadScene(sceneindex);
        await Task.Delay(50);

        EnterLevel(sceneindex);
    }

    private void EnterLevel(int levelnumber)
    {
        if (alreadyloaded) return;
        alreadyloaded = true;

        currentlevelnumber = levelnumber;

        gameball = GameObject.FindGameObjectWithTag("Ball");
        canva.worldCamera = MainCamera.maincamera;
        coinspawner.ClearCoins();
        coinspawner.Prefab(CountReward(levelnumber, 20f));
        panelsetter.ResetPanels();
        feverblock.Unlock(levelnumber >= feverblock.feverunlocklevel);
        feverset.ResetTheFever();
        levelbarset.ResetTheProgression();
        leveltextmanager.UpdateText(levelnumber);

        levelon = true;
    }
}