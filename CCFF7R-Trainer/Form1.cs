using System.Diagnostics;

namespace CCFF7R_Trainer
{
    public partial class Form1 : Form
    {
        private static GameMemory gameMemory = new GameMemory();
        KeyboardHook hook = new KeyboardHook();
        public Form1()
        {
            InitializeComponent();

            hook.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            hook.RegisterHotKey(global::ModifierKeys.Control, Keys.Space);
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

            // we're in battle so start the stopwatch
            if (!inBattle && enemies.Select(e => e.HP).Sum() > 0 && battleState == 3 && gameMemory.GetZacksHP() != 0)
            {
                inBattle = true;
                stopWatch.Start();
            }

            // update label for battlestate
            this.battleStateLabel.Text = "Battle State: " + battleState.ToString();

            // update the datagrid to show all enemies ID + HP
            this.dataGridHP.Rows.Clear();
            foreach (GameMemory.Enemy enemy in enemies.Where(e => e.HP > 0).ToArray())
            {
                this.dataGridHP.Rows.Add(enemy.ID.ToString(), enemy.HP.ToString());
            }
            this.dataGridHP.ClearSelection();

            // Encounter ended
            if (inBattle && enemies.Select(e => e.HP).Sum() <= 0)
            {
                onEndBattle();
            }

            // Zack died (RIP)
            if(inBattle && gameMemory.GetZacksHP() <= 0)
            {
                onEndBattle("Death");
            }

            // failsafe to make sure the player is for sure killed
            if (this.checkBoxInstantDeath.Checked && (battleState > 3 && battleState < 7))
            {
                gameMemory.KillPlayer();
            }

            // if stopwatch is running update the label
            if (stopWatch.IsRunning)
            {
                string elapsed = string.Format("{0}.{1}s", (int)stopWatch.Elapsed.TotalSeconds, stopWatch.Elapsed.Milliseconds);
                this.labelStopwatch.Text = elapsed;
            }

            if(stopWatch.IsRunning && battleState == 4)
            {
                onEndBattle("Fled");
            }
        }

        private void checkBoxSkipBattles_CheckedChanged(object sender, EventArgs e)
        {
            if(this.checkBoxSkipBattles.Checked)
            {
                this.checkBoxInstantBattleSkip.Checked = false;
                this.checkBoxInstantDeath.Checked = false;
            }
        }

        private void checkBoxInstantBattleSkip_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxInstantBattleSkip.Checked)
            {
                this.checkBoxSkipBattles.Checked = false;
                this.checkBoxInstantDeath.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameMemory.KillPlayer();
            onEndBattle("Reset");
        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            gameMemory.KillPlayer();
            onEndBattle("Reset");

        }

        private void onEndBattle(string reason = "")
        {
            // Stop the stopwath
            stopWatch.Stop();

            // Kill the player if instant death is enabled
            if (this.checkBoxInstantDeath.Checked)
            {
                gameMemory.KillPlayer();
            }

            // Format the string for the datagrid/label
            string elapsed;
            if (reason == "")
            {
                elapsed = string.Format("{0}.{1}s", (int)stopWatch.Elapsed.TotalSeconds, stopWatch.Elapsed.Milliseconds);
            }
            else
            {
                elapsed = string.Format("{0}.{1}s ({2})", (int)stopWatch.Elapsed.TotalSeconds, stopWatch.Elapsed.Milliseconds, reason);
            }

            // add the datagrid entry and update label
            this.dataGridElapsed.Rows.Add(elapsed);
            this.dataGridElapsed.FirstDisplayedScrollingRowIndex = dataGridElapsed.RowCount - 1;
            this.dataGridElapsed.ClearSelection();
            this.labelStopwatch.Text = elapsed;


            //restart the stop watch and set inBattle to false
            stopWatch.Reset();
            inBattle = false;
        }
    }
}