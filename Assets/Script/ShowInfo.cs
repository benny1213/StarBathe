using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShowInfo : MonoBehaviour {
    GameObject description;
    GameObject texttime;
    GameObject buttonagain;
    public Button btn_close;
    public Button btn_start;
    public Button btn_again;
    float timer;


    bool Sun;
    bool Mercury;
    bool Venus;
    bool Earth;
    bool Mars;
    bool Jupiter;
    bool Saturn;
    bool Uranus;
    bool Neptune;



    // Use this for initialization
    void Start () {

     

    }
    void Awake()
    {
        Sun = Mercury = Venus = Earth = Mars = Jupiter = Saturn = Uranus = Neptune = false;

        texttime = GameObject.Find("TimeRemain");
        description = GameObject.Find("UIdescription");
        buttonagain = GameObject.Find("btn_again");

        texttime.SetActive(false);

        btn_close.onClick.AddListener(OnBtnCloseClicked);
        btn_start.onClick.AddListener(OnBtStartClicked);
        btn_again.onClick.AddListener(OnBtAgainClicked);

        GameObject.Find("Description").GetComponent<Text>().text = "玩家通过遥感移动摄像机视角，在规定时间内通过点击天体收集齐太阳系所有天体";
        buttonagain.SetActive(false);
        description.SetActive(true);
    }
    private void OnBtAgainClicked()
    {
        SceneManager.LoadScene(0);
    }

    private void OnBtnCloseClicked()
    {
        description.SetActive(false);
    }
    private void OnBtStartClicked()
    {
        GameObject.Find("btn_start").SetActive(false);
        description.SetActive(false);
        timer = 0;
        texttime.SetActive(true);
    }
    // Update is called once per frame

   
    void Update () {
        timer += Time.deltaTime;
        texttime.GetComponent<Text>().text = "剩余时间:" + (120 - (int)timer).ToString();
        if (Sun && Mercury && Venus && Earth && Mars && Jupiter && Saturn && Uranus && Neptune)
        {
            description.SetActive(true);
            GameObject.Find("Title").GetComponent<Text>().text = "";
            GameObject.Find("Description").GetComponent<Text>().text = "恭喜你，找到了太阳系中的所有行星";
            buttonagain.SetActive(true);
            texttime.SetActive(false);
        }
        if (timer > 120)
        {
            description.SetActive(true);
            GameObject.Find("Description").GetComponent<Text>().text = "很遗憾，超过规定时间！";
            texttime.SetActive(false);
            buttonagain.SetActive(true);
        }
        if (Input.touchCount == 1)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                
                Debug.Log("hit");
                if(hit.collider.gameObject.name == "Sun" && Sun == false)
                {
                    description.SetActive(true);
                    GameObject.Find("Title").GetComponent<Text>().text = "太阳/SUN";
                    GameObject.Find("Description").GetComponent<Text>().text = "太陽或日是位於太陽系中心的恆星，它幾乎是熱電漿與磁場交織著的一個理想球體。其直徑大約是1,392,000（1.392×106）公里，相當於地球直徑的109倍；質量大約是2×1030千克（地球的333,000倍），約佔太陽系總質量的99.86%[12]，同時也是27,173,913.04347826（約2697.3萬）倍的月球質量。 从化學組成来看，太陽質量的大約四分之三是氫，剩下的幾乎都是氦，包括氧、碳、氖、鐵和其他的重元素質量少於2%。";
                    Sun = true;
                }
                if(hit.collider.gameObject.name == "Mercury" && Mercury == false)
                {
                    description.SetActive(true);
                    GameObject.Find("Title").GetComponent<Text>().text = "水星/Mercury";
                    GameObject.Find("Description").GetComponent<Text>().text = "水星是太陽系的八大行星中最小和最靠近太陽的行星，但有著八大行星中最大的離心率 [a]，軌道週期是87.969 地球日。從地球上看，它大约116天左右與地球會合一次，公转速度遠遠超過太阳系的其它星球。水星的快速運動使它在羅馬神話中被稱為墨丘利，是快速飛行的信使神。由于大氣層极为稀薄，无法有效保存热量，水星表面昼夜温差极大，为太阳系行星之最。白天时赤道地區温度可达430°C，夜间可降至-170°C。極區气温則終年維持在-170°C以下。水星的軸傾斜是太陽系所有行星中最小的（大約1⁄30度），但它有最大的軌道偏心率[a]。水星在遠日點的距離大約是在近日點的1.5倍。水星表面充滿了大大小小的坑穴（環形山），外觀看起來與月球相似，顯示它的地質在數十億年來都處於非活動狀態。";
                    Mercury = true;
                }
                if (hit.collider.gameObject.name == "Venus" && Venus == false)
                {
                    description.SetActive(true);
                    GameObject.Find("Title").GetComponent<Text>().text = "金星/Venus";
                    GameObject.Find("Description").GetComponent<Text>().text = "在太陽系的八大行星中，是從太陽向外的第二顆行星，軌道公轉週期為224.7地球日，它沒有天然的衛星。在中國古代稱為太白、明星或大囂，另外早晨出現在東方稱啟明，晚上出現在西方稱長庚。到西漢時期，《史記‧天官書》作者天文學家司馬遷從實際觀測發現太白為白色，與「五行」學說聯繫在一起，正式把它命名為金星[5]。它的西文名稱源自羅馬神話的愛與美的女神，维纳斯（Venus），古希腊人称为阿佛洛狄忒，也是希腊神话中爱与美的女神。金星的天文符号用维纳斯的梳妆镜来表示。 它在夜空中的亮度僅次於月球，是第二亮的天然天體，視星等可以達到 -4.7等，足以照射出影子[6]。由於金星是在地球內側的內行星，它永遠不會遠離太陽運行：它的離日度最大值為47.8°。";
                    Venus = true;
                }
                if (hit.collider.gameObject.name == "Earth" && Earth == false)
                {
                    description.SetActive(true);
                    GameObject.Find("Title").GetComponent<Text>().text = "地球/Earth";
                    GameObject.Find("Description").GetComponent<Text>().text = "地球是太阳系中由內及外的第三顆行星，距离太阳约1.5亿公里。地球是宇宙中人類已知唯一存在生命的天体，也是人類居住的星球，共有76.6億人口。地球质量约为5.97×1024公斤，半径约6,371公里，地球的密度是太阳系中最高的。地球同时进行自转和公转运动，分别产生了昼夜及四季的变化更替，一太陽日自转一周，一太陽年公转一周。自转轨道面称为赤道面，公转轨道面称为黄道面，两者之间的夹角称为黄赤交角。地球仅擁有一顆自然卫星，即月球。";
                    Earth = true;
                }
                if (hit.collider.gameObject.name == "Mars" && Mars == false)
                {
                    description.SetActive(true);
                    GameObject.Find("Title").GetComponent<Text>().text = "火星/Mars";
                    GameObject.Find("Description").GetComponent<Text>().text = "火星（拉丁語：Mars, 天文符號♂），是離太陽第四近的行星，為太陽系中四顆類地行星之一。西方稱火星為瑪爾斯，是羅馬神話中的戰神；古漢語中則因为它荧荧如火，位置、亮度時常變動讓人無法捉摸而稱之為熒惑。火星是太陽系的八大行星中第二小的行星，其質量、體積仅比水星略大。火星的直徑約為地球的一半，自轉軸傾角、自轉週期則與地球相當，但繞太陽公轉周期是地球的兩倍[3]。在地球上，火星肉眼可見，亮度可達-2.91，只比金星、月球和太陽暗，但在大部分時間裡比木星暗。";
                    Mars = true;
                }
                if (hit.collider.gameObject.name == "Jupiter" && Jupiter == false)
                {
                    description.SetActive(true);
                    GameObject.Find("Title").GetComponent<Text>().text = "木星/Jupiter";
                    GameObject.Find("Description").GetComponent<Text>().text = "木星是太陽系從太陽向外的第五顆行星，並且是最大的行星。古代的天文學家就已經知道這顆行星[11] ，羅馬人以他們的神稱這顆行星為朱庇特[12]。古代中國則稱木星為歲星，取其繞行天球一周為12年，與地支相同之故[13]。到西漢時期，《史記‧天官書》作者天文學家司馬遷從實際觀測發現歲星呈青色，與「五行」學說聯繫在一起，正式把它命名為木星。[14]";
                    Jupiter = true;
                }
                if (hit.collider.gameObject.name == "Saturn" && Saturn == false)
                {
                    description.SetActive(true);
                    GameObject.Find("Title").GetComponent<Text>().text = "土星/Saturn";
                    GameObject.Find("Description").GetComponent<Text>().text = "土星是中国古代人根据五行学说结合肉眼观测到的土星的颜色（黄色）来命名的（按照五行学说即木青、金白、火赤、水黑、土黄）[10]。而其他语言中土星的名称基本上来自希臘/羅馬神話传说，例如在欧美各主要语言（英语、法语、西班牙语、俄语、葡萄牙语、德语、意大利语等）中土星的名称来自于羅馬神話中的农业之神萨图尔努斯（拉丁文：Saturnus），其他的还有希臘神話中的克洛諾斯（泰坦族，宙斯的父親，一说其在罗马神话中即萨图尔努斯）、巴比倫神话中的尼努尔塔和印度神话中的沙尼。土星的天文学符號是代表农神萨图尔努斯的鐮刀（Unicode: ♄）。";
                    Saturn = true;
                }
                if (hit.collider.gameObject.name == "Uranus" && Uranus == false)
                {
                    description.SetActive(true);
                    GameObject.Find("Title").GetComponent<Text>().text = "天王星/Uranus";
                    GameObject.Find("Description").GetComponent<Text>().text = "天王星是從太陽系由内向外的第七顆行星，其體積在太陽系排名第三（比海王星大），質量排名第四（比海王星輕）。其英文名稱Uranus來自古希臘神話的天空之神烏拉諾斯（Οὐρανός），是克洛諾斯的父親，宙斯的祖父。与在古代就为人们所知的五顆行星（水星、金星、火星、木星、土星）相比，天王星的亮度也是肉眼可見的，但由於較為黯淡以及緩慢的繞行速度而未被古代的觀測者认定为一颗行星。[12]直到1781年3月13日，威廉·赫歇耳爵士宣布發現天王星，从而在太陽系的現代史上首度擴展了已知的界限。這也是第一顆使用望遠鏡發現的行星。";
                    Uranus = true;
                }
                if (hit.collider.gameObject.name == "Neptune" && Neptune == false)
                {
                    description.SetActive(true);
                    GameObject.Find("Title").GetComponent<Text>().text = "海王星/Neptune";
                    GameObject.Find("Description").GetComponent<Text>().text = "海王星是太陽系八大行星中距离太阳最遠的，體積是太陽系第四大，但質量排名是第三。海王星的質量大約是地球的17倍，而類似雙胞胎的天王星因密度較低，質量大約是地球的14倍。海王星以羅馬神話中的尼普顿（Neptunus）命名，因為尼普顿是海神王，所以中文譯為海王星。天文學的符號Astronomical symbol for Neptune.（♆，Unicode編碼U+2646），是希臘神話的海神波塞頓使用的三叉戟。";
                    Neptune = true;
                }
                
            }

        }
        if(Input.touchCount == 2)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
            }
        }
	}
}
