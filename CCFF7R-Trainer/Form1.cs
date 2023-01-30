using System.Diagnostics;

namespace CCFF7R_Trainer
{
    public partial class Form1 : Form
    {
        private static GameMemory gameMemory = new GameMemory();
        public Form1()
        {
            InitializeComponent();
        }

        public Stopwatch stopWatch = new Stopwatch();
        public Boolean inBattle = false;

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (gameMemory.process == null)
            {
                this.gameProcessFoundLabel.ForeColor = Color.Red;
                this.gameProcessFoundLabel.Text = "Game is not running.";
                gameMemory = new GameMemory();
                return;
            }

            gameMemory.process.Refresh();
            if (gameMemory.process.HasExited)
            {
                this.gameProcessFoundLabel.ForeColor = Color.Red;
                this.gameProcessFoundLabel.Text = "Game is not running.";
                gameMemory = new GameMemory();
                return;
            }

            this.gameProcessFoundLabel.ForeColor = Color.Green;
            this.gameProcessFoundLabel.Text = "CCFF7R-Win64-Shipping.exe (" + gameMemory.process.Id.ToString() + ")";

            GameMemory.Enemy[] enemies = gameMemory.GetEnemies();
            byte battleState = gameMemory.GetBattleState();

            if (this.checkBoxInstantBattleSkip.Checked && battleState > 0 && battleState < 7)
            {
                gameMemory.SetBattleState((byte)7);
                return;
            }

            if (this.checkBoxSkipBattles.Checked && battleState == 3)
            {
                gameMemory.SetBattleState((byte)5);
                return;
            }

            if (!inBattle && enemies.Select(e => e.HP).Sum() > 0 && battleState == 3 && gameMemory.GetZacksHP() != 0)
            {
                inBattle = true;
                stopWatch.Start();
            }

            this.labelBattleState.Text = "Battle State: " + battleState.ToString();

            this.dataGridHP.Rows.Clear();
            foreach (GameMemory.Enemy enemy in enemies.Where(e => e.HP > 0).ToArray())
            {
                this.dataGridHP.Rows.Add(enemy.ID.ToString(), enemy.HP.ToString());
            }
            this.dataGridHP.ClearSelection();

            if (inBattle && enemies.Select(e => e.HP).Sum() <= 0)
            {
                if (this.checkBoxInstantDeath.Checked)
                {
                    gameMemory.KillPlayer();
                }

                stopWatch.Stop();
                string elapsed = string.Format("{0}.{1}s", (int)stopWatch.Elapsed.TotalSeconds, stopWatch.Elapsed.Milliseconds);
                this.dataGridElapsed.Rows.Add(elapsed);
                this.dataGridElapsed.FirstDisplayedScrollingRowIndex = dataGridElapsed.RowCount - 1;
                this.dataGridElapsed.ClearSelection();
                this.labelStopwatch.Text = elapsed;

                stopWatch.Reset();
                inBattle = false;
            }

            if(inBattle && gameMemory.GetZacksHP() <= 0)
            {
                stopWatch.Stop();
                string elapsed = string.Format("{0}.{1}s", (int)stopWatch.Elapsed.TotalSeconds, stopWatch.Elapsed.Milliseconds);
                this.dataGridElapsed.Rows.Add(elapsed + "(Death)");
                this.dataGridElapsed.FirstDisplayedScrollingRowIndex = dataGridElapsed.RowCount - 1;
                this.dataGridElapsed.ClearSelection();
                this.labelStopwatch.Text = elapsed;

                stopWatch.Reset();
                inBattle = false;
            }

            if (this.checkBoxInstantDeath.Checked && (battleState > 3 && battleState < 7))
            {
                gameMemory.KillPlayer();
            }

            if (stopWatch.IsRunning)
            {
                string elapsed = string.Format("{0}.{1}s", (int)stopWatch.Elapsed.TotalSeconds, stopWatch.Elapsed.Milliseconds);
                this.labelStopwatch.Text = elapsed;
            }
        }
    }
}