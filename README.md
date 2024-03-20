# Unity_SpartaDungeon - 개인과제

# 내용
1. 타이틀 화면 - 스테이터스 - 인벤토리로 버튼을 통하여 이동.
2. 인벤토리에서 장비 착용 시 스테이터스창에서 적용된 스탯 확인 가능


https://github.com/shstcs/Unity_SpartaDungeon/assets/73222781/21e3624b-d18b-49c2-9030-b0903ef1fda1


# 세부 구현 기능
## UI Binding.
1. 각 UI의 Canvas마다 따로 Prefab을 만든 후 필요할 때마다 불러서 사용하였다.
2. Popup과 Scene을 분리하여 다르게 처리하였다.
3. GetComponent를 복잡하게 사용하지 않고 enum타입을 이용해 직관적으로 찾을 수 있도록 하였다.
```
enum Buttons
{
    BackButton
}
enum Images
{
    Character,
    CharacterPanel,
    StatPanel
}
enum Texts
{
    IDText,
    LevelText,
    atkValue,
    defValue,
    HPValue,
    criValue
}
```
```
Bind<Button>(typeof(Buttons));
Bind<Image>(typeof(Images));
Bind<TMP_Text>(typeof(Texts));

GetText((int)Texts.IDText).text = Managers.Player.UserName;
GetText((int)Texts.LevelText).text = Managers.Player.Level.ToString();
GetText((int)Texts.atkValue).text = Managers.Player.Atk.ToString();
GetText((int)Texts.defValue).text = Managers.Player.Def.ToString();
GetText((int)Texts.HPValue).text = Managers.Player.HP.ToString();
GetText((int)Texts.criValue).text = Managers.Player.Critical.ToString();
GetButton((int)Buttons.BackButton).gameObject.BindEvent(ShowTitle);
```
## Managers
1. Managers라는 클래스를 만들어 여러 매니저들을 가지고 있게 하였다.

```
public class Managers : MonoBehaviour
{
    private static Managers instance;
    private static bool initialized;
    public static Managers Instance
    {
        get
        {
            if (!initialized)
            {
                initialized = true;
                GameObject go = GameObject.Find("@Managers");
                if (go == null)
                {
                    go = new() { name = @"Managers" };
                    go.AddComponent<Managers>();
                    DontDestroyOnLoad(go);
                    instance = go.GetComponent<Managers>();
                }

            }
            return instance;
        }
    }

    private readonly UIManager _ui = new();
    private readonly ResourceManager _resource = new();
    private readonly ItemManager _itemManager = new();
    private readonly Player _player = new("Enos");

    public static UIManager UI => Instance._ui;
    public static ResourceManager Resource => Instance._resource;
    public static ItemManager ItemManager => Instance._itemManager;
    public static Player Player => Instance._player;
}

```
# 얻은 것
- UI의 Prefab화.
- Find를 사용하지 않고 UI를 접근할 수 있는 방법.
- Singleton을 사용한 Manager 구조 구현
