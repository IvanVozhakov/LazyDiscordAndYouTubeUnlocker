using System.Diagnostics;

namespace LazyDisYTUnloker
{
    public partial class MainForm : Form
    {
        private bool currentlyWorking = false;
        NotifyIcon? notifIcon { get; set; } = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckFilesAndSetup().ConfigureAwait(false);
        }

        private async Task CheckFilesAndSetup()
        {
            Task.Run(async () =>
            {
                FilesAndDirectories.Form = this;
                if (!FilesAndDirectories.IsZapretBundleDirectoriesLoaded())
                {
                    if (MessageBox.Show("��� ������ ����� ��������� \"Zapret\" � ����������� ��� ����� �����, ������?", "����-�� �� �������, �� ����?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        FilesAndDirectories.SetupDirectory();
                        ChangeStatus("�������� ����� � �������� ���������...");
                        if (await FilesAndDirectories.DownloadUnpackAndSetupZapret() && FilesAndDirectories.IsZapretBundleDirectoriesLoaded() && await Strategies.GetStrategies(true))
                        {
                            ChangeZapretBundleStatus("����� � ������");
                            BeginInvoke(() =>
                            {
                                MainButton.Enabled = true;
                                UpdateStrategiesButton.Enabled = true;
                            });
                        }

                    }
                    else
                    {
                        MessageBox.Show("��� ����� ������ �������� �� �����, �� ��� ���� ����� :)\n\n" +
                            "" +
                            "���� ����������� - ������ ������������� ���������!", "�� ����... ��� ������!");
                    }
                }
                else
                {
                    if (await Strategies.GetStrategies(false))
                    {
                        BeginInvoke(() =>
                        {
                            MainButton.Enabled = true;
                            UpdateStrategiesButton.Enabled = true;
                        });
                        ChangeStatus("����� � ������");
                    }
                }
            });
        }


        internal void ChangeZapretBundleStatus(string status) => BeginInvoke(() => BundleStatusLabel.Text = $"��������� Zapret: {status}");

        internal void ChangeDiscordDomainsCountLabel(int count) => BeginInvoke(() => DiscordDomainsCountLabel.Text = $"����� ������� Discord: {count}");

        internal void ChangeYouTubeDomainsCountLabel(int count) => BeginInvoke(() => YouTubeDomainsCountLabel.Text = $"����� ������� YouTube: {count}");

        internal void ChangeStatus(string status) => BeginInvoke(() => WorkStatusLabel.Text = status);

        internal void ChangeLastStrategiesUpdateDate(DateTime dateTime) => BeginInvoke(() => StrategiesUpdateDateLabel.Text = $"���� ���������� ���������� ���������: {dateTime.ToString("HH:mm:ss dd.MM.yyyy")}");

        private void MainButton_Click(object sender, EventArgs e)
        {
            if (!currentlyWorking)
            {
                if (ProcessManager.RunStrategies())
                {
                    currentlyWorking = true;
                    ChangeStatus("�������� :O");
                    MainButton.Text = "����������";
                }

            }
            else
            {
                ProcessManager.StopStrategies();
                currentlyWorking = false;
                ChangeStatus("����� � ������");
                MainButton.Text = "���������";
            }
        }

        private void LauncherDevLabel_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/WutADude");
        }

        private void MainDevLabel_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/bol-van");
        }

        private void RepZapretLabel_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "https://github.com/bol-van/zapret");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (currentlyWorking)
                ProcessManager.StopStrategies();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized && HideInTrayCB.Checked)
                HideInTray();
        }

        private void NotifIcon_DoubleClick(object? sender, EventArgs e) => RevealFromTray();

        private async void UpdateStrategiesButton_Click(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                ChangeStatus("�������� ���������...");
                BeginInvoke(() =>
                {
                    MainButton.Enabled = false;
                    UpdateStrategiesButton.Enabled = false;
                });
                if (await Strategies.GetStrategies(true))
                {
                    BeginInvoke(() =>
                    {
                        MainButton.Enabled = true;
                        UpdateStrategiesButton.Enabled = true;
                    });
                    ChangeStatus("����� � ������");
                }
            });
        }

        private void HideInTray()
        {
            notifIcon ??= new NotifyIcon();
            notifIcon.BalloonTipText = "�������� �����!";
            notifIcon.Text = "DS and YT unlock launcher";
            notifIcon.Icon = Icon;
            notifIcon.Visible = true;
            notifIcon.ShowBalloonTip(500);
            notifIcon.DoubleClick += NotifIcon_DoubleClick;
            ShowInTaskbar = false;
            Hide();
        }

        private void RevealFromTray()
        {
            notifIcon.Visible = false;
            ShowInTaskbar = true;
            Show();
        }
    }
}
