using PKHeX.Core;
using SVTradePartnerViewer.Properties;
using SVTradePartnerViewer.Structures;
using SysBot.Base;
using System;
using System.Net.Sockets;
using System.Security.Cryptography;
using static SVTradePartnerViewer.Structures.Offsets;

namespace SVTradePartnerViewer
{
    public partial class MainWindow : Form
    {
        private readonly static SwitchConnectionConfig Config = new() { Protocol = SwitchProtocol.WiFi, IP = Settings.Default.SwitchIP, Port = 6000 };
        private readonly static SwitchSocketAsync SwitchConnection = new(Config);

        private static ulong TradePartnerNIDOffset;

        private static string OT = string.Empty;
        private static int DisplayTID;
        private static int DisplaySID;

        readonly string CachedText = string.Empty;

        private bool Stop = false;
        private static readonly string[] languages =
        {
        "未知1",
        "JPN(日本語)",
        "ENG(English)",
        "FRE(Français)",
        "ITA(Italiano)",
        "GER(Deutsch)",
        "未知2",
        "ESP(Español)",
        "KOR(한국어)",
        "CHS(简体中文)",
        "CHT(繁體中文)"
        };

        public MainWindow()
        {
            string build = string.Empty;
#if DEBUG
            var date = File.GetLastWriteTime(System.Reflection.Assembly.GetEntryAssembly()!.Location);
            build = $" (dev-{date:yyyyMMdd})";
#endif
            var v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version!;
            CachedText = "朱紫交易对象查询器 v" + v.Major + "." + v.Minor + "." + v.Build + build;
            Text = CachedText;

            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            InputSwitchIP.Text = Settings.Default.SwitchIP;
            CheckAutoCopy.Checked = Settings.Default.AutoCopy;
            ButtonCopy.Enabled = !CheckAutoCopy.Checked;
            OutOT.Text = string.Empty;
            OutTID.Text = string.Empty;
            OutVersion.Text = string.Empty;
            OutNID.Text = string.Empty;
        }

        private void InputSwitchIP_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != "192.168.0.0")
            {
                Settings.Default.SwitchIP = textBox.Text;
                //Config.IP = textBox.Text;
            }
            Settings.Default.Save();
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            ButtonStop.Enabled = true;
            PrintButton.Enabled = true;
            Stop = false;
            Connect();
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            Stop = true;
            ButtonStop.Enabled = false;
            PrintButton.Enabled = false;
        }

        private void ButtonCopy_Click(object sender, EventArgs e)
        {
            CopyOutputToClipboard(CheckPSWiFi.Checked);
        }

        private void CheckAutoCopy_CheckedChanged(object sender, EventArgs e)
        {
            ButtonCopy.Enabled = !CheckAutoCopy.Checked;
            Settings.Default.AutoCopy = CheckAutoCopy.Checked;
            Settings.Default.Save();
            if (SwitchConnection.Connected) CopyOutputToClipboard(CheckPSWiFi.Checked);
        }

        private void CheckPSWiFi_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.PSWiFi = CheckPSWiFi.Checked;
            Settings.Default.Save();
        }

        private void CopyOutputToClipboard(bool IsPS = false)
        {
            string n = Environment.NewLine;
            string OutString = IsPS ? $"{OutOT.Text}\t{OutGender.Text}\t{OutTID.Text.Split("-")[1]}\t{OutNID.Text}" : $"名称: {OutOT.Text}{n}性别: {OutGender.Text}{n}表里ID: {OutTID.Text}{n}游戏语言: {OutLanguage.Text}{n}游戏版本: {OutVersion.Text}";
            Clipboard.SetText(OutString);
        }

        private async void Connect()
        {
            ButtonConnect.Enabled = false;
            if (!SwitchConnection.Connected)
            {
                try
                {
                    textLog.Text = CachedText + "正在连接...";
                    var NewText = CachedText;
                    try
                    {
                        SwitchConnection.Connect();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("连接服务器失败：" + ex.Message);
                        return;
                    }
                    string id = await GetGameID(CancellationToken.None);
                    textLog.Text = "正在识别主机训练家数据...";
                    var sav = await IdentifyTrainer(CancellationToken.None);
                    OT = sav.OT;
                    DisplayTID = (int)sav.DisplayTID;
                    DisplaySID = (int)sav.DisplaySID;
                    if (id is ScarletID)
                    {
                        Text = CachedText + $" | {OT} ({DisplayTID:D6})已连接-游戏版本：朱";
                        NewText = CachedText + " - 朱";
                    }
                    else if (id is VioletID)
                    {
                        Text = CachedText + $" | {OT} ({DisplayTID:D6})已连接-游戏版本：紫";
                        NewText = CachedText + " - 紫";
                    }
                    else
                    {
                        MessageBox.Show("没有检测到Switch上正在运行宝可梦朱紫!");
                        SwitchConnection.Disconnect();
                    }

                    if (SwitchConnection.Connected)
                    {
                        NewText += $" | 连接到 {OT} ({DisplayTID:D6})";
                        textLog.Text = "正在读取交易对象信息...";

                        while (!Stop && SwitchConnection.Connected)
                        {
                            TradePartnerNIDOffset = await SwitchConnection.PointerAll(LinkTradePartnerNIDPointer, CancellationToken.None);
                            ulong NID = await GetTradePartnerNID(TradePartnerNIDOffset, CancellationToken.None);
                            if (NID == 0)
                            {
                                await Task.Delay(1_000);
                                continue;
                            }

                            var trader = await GetTradePartnerMyStatus(Trader1MyStatusPointer, CancellationToken.None);
                            if (trader.OT == OT && trader.DisplayTID == DisplayTID && trader.DisplaySID == DisplaySID)
                                trader = await GetTradePartnerMyStatus(Trader2MyStatusPointer, CancellationToken.None);
                            
                            string languageZh = trader.Language >= 0 && trader.Language < languages.Length ? languages[trader.Language] : "未知";

                            OutOT.Text = trader.OT;
                            OutTID.Text = $"({trader.DisplaySID:D4})-{trader.DisplayTID:D6}";
                            OutVersion.Text = $"{(trader.Game <= 50 ? "朱" : "紫")}";
                            OutNID.Text = $"{NID:X16}";
                            OutGender.Text = $"{(trader.Gender == 0 ? "男" : "女")}";
                            OutLanguage.Text = languageZh;
                            PkmClipboard.Text = $".Version={trader.Game}\n.OriginalTrainerName={trader.OT}\n.OriginalTrainerGender={trader.Gender}\n.DisplayTID={trader.DisplayTID:D6}\n.DisplaySID={trader.DisplaySID:D4}\n.Language={trader.Language}\n.IsNicknamed=false\n";
                            if (CheckAutoCopy.Checked) CopyOutputToClipboard(CheckPSWiFi.Checked);
                            await ClearTradePartnerNID(TradePartnerNIDOffset, CancellationToken.None);
                        }

                        textLog.Text = $"{OT} ({DisplayTID:D6}) 已断开连接!";
                        if (SwitchConnection.Connected) SwitchConnection.Disconnect();
                    }

                }
                catch (SocketException err)
                {
                    textLog.Text = "连接失败!";
                    if (SwitchConnection.Connected) await SwitchConnection.SendAsync(SwitchCommand.DetachController(true), CancellationToken.None).ConfigureAwait(false);
                    SwitchConnection.Disconnect();
                    // a bit hacky but it works
                    if (err.Message.Contains("未能响应") || err.Message.Contains("主动拒绝"))
                    {
                        MessageBox.Show(err.Message);
                    }
                }
            }
            ButtonConnect.Enabled = true;
        }

        private static async Task<string> GetGameID(CancellationToken token) => await SwitchConnection.GetTitleID(token).ConfigureAwait(false);

        private static async Task<SAV9SV> IdentifyTrainer(CancellationToken token)
        {
            // Check title so we can warn if mode is incorrect.
            string title = await SwitchConnection.GetTitleID(token).ConfigureAwait(false);
            if (title is not (ScarletID or VioletID))
                throw new Exception($"{title}不是朱紫版本. 你确定打开了宝可梦朱紫吗?");

            return await GetFakeTrainerSAV(token).ConfigureAwait(false);
        }

        private static async Task<SAV9SV> GetFakeTrainerSAV(CancellationToken token)
        {
            var sav = new SAV9SV();
            var info = sav.MyStatus;
            var read = await SwitchConnection.PointerPeek(info.Data.Length, MyStatusPointer, token).ConfigureAwait(false);
            read.CopyTo(info.Data);
            return sav;
        }

        private static async Task<TradeMyStatus> GetTradePartnerMyStatus(IReadOnlyList<long> pointer, CancellationToken token)
        {
            var info = new TradeMyStatus();
            var read = await SwitchConnection.PointerPeek(info.Data.Length, pointer, token).ConfigureAwait(false);
            read.CopyTo(info.Data, 0);
            return info;
        }

        private static async Task<ulong> GetTradePartnerNID(ulong offset, CancellationToken token)
        {
            var data = await SwitchConnection.ReadBytesAbsoluteAsync(offset, 8, token).ConfigureAwait(false);
            return BitConverter.ToUInt64(data, 0);
        }

        private static async Task ClearTradePartnerNID(ulong offset, CancellationToken token)
        {
            var data = new byte[8];
            await SwitchConnection.WriteBytesAbsoluteAsync(data, offset, token).ConfigureAwait(false);
        }

        private void PkmClipboard_TextChanged(object sender, EventArgs e)
        {

        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            CopyOutput();
        }

        private void CopyOutput()
        {
            string n = Environment.NewLine;
            string OT_Name = OutOT.Text;
            int version = OutVersion.Text == "朱" ? 50 : 51;
            int Gender = OutGender.Text == "男" ? 0 : 1;
            string TID = "";
            string SID = "";
            if (!string.IsNullOrEmpty(OutTID.Text))
            {
                TID = OutTID.Text.Split("-")[1];
                SID = OutTID.Text.Split("-")[0][1..^1];
            }
            int Language = GetLanguageCode(OutLanguage.Text);
            Clipboard.SetText(PkmClipboard.Text);
            PkmClipboard.Text = $".Version={version}{n}.OriginalTrainerName={OT_Name}{n}.OriginalTrainerGender={Gender}{n}.DisplayTID={TID}{n}.DisplaySID={SID}{n}.Language={Language}{n}.IsNicknamed=false";
        }
        public static int GetLanguageCode(string language)
        {

            for (int i = 0; i < languages.Length; i++)
            {
                if (languages[i] == language)
                {
                    return i;
                }
            }
            return -1; // 如果没有找到匹配的语言，返回 -1 表示未知
        }
    }
}
