using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Icon taken from: https://www.iconfinder.com/iconsets/free-mix
// Puzzle: https://www.creativecrafthouse.com/safecracker-50-puzzle-2-tone-maple-cherry-premium-model.html

namespace SafeCrackerPuzzle
{
    public partial class Form1 : Form
    {
        Label[,] _gameFieldArray = new Label[16,5];
        Label[] _gameRowTotalLabelArray = new Label[5];
        Label[] _gameColumnTotalLabelArray = new Label[16];
        Label _gameFieldLabelTotal = new Label();
        Color[] _colorArray = new Color[] { Color.FromArgb(238, 217, 186), Color.FromArgb(209, 178, 131), Color.FromArgb(202, 154, 108), Color.FromArgb(184, 121, 68), Color.FromArgb(156, 95, 51) };

        // Puzzle data arrays
        int[] _r1 = { 4, 7, 0, 16, 8, 4, 15, 7, 10, 1, 10, 4, 5, 3, 15, 16 };
        int[] _r2B = { 9, 27, 13, 11, 13, 10, 18, 10, 10, 10, 10, 15, 7, 19, 18, 2 };
        int[] _r2F = { 8, -1, 9, -1, 6, -1, 10, -1, 8, -1, 10, -1, 9, -1, 8, -1 };
        int[] _r3B = { 22, 0, 5, 8, 5, 1, 24, 8, 10, 20, 7, 20, 12, 1, 10, 12 };
        int[] _r3F = { 10, -1, 0, -1, 11, -1, 8, -1, 8, -1, 8, -1, 10, -1, 11, -1 };
        int[] _r4B = { 0, 5, 20, 8, 19, 10, 15, 20, 12, 20, 13, 13, 0, 22, 19, 10 };
        int[] _r4F = { 11, -1, 3, -1, 8, -1, 10, -1, 14, -1, 11, -1, 8, -1, 12, -1 };
        int[] _r5B = { 1, 14, 10, 17, 10, 5, 6, 18, 8, 17, 4, 20, 4, 14, 4, 5 };
        int[] _r5F = { 16, -1, 19, -1, 8, -1, 17, -1, 6, -1, 6, -1, 8, -1, 8, -1 };

        // Game data
        uint[] _rowIndexArray = { 0, 0, 0, 0, 0 };

        public Form1()
        {
            InitializeComponent();

            #region Draw Field
            // Build the game field, controls, and totals
            const int ySpacing = 23;
            const int xSpacing = 43;
            for (int y = 0; y <= 5; y++)
            {
                Button l = btnLeft.Clone();
                l.Name = btnLeft.Name + y.ToString();
                l.Location = new Point(btnLeft.Location.X, btnLeft.Location.Y + (ySpacing * y));
                l.Visible = true;
                l.Click += L_Click;
                grpBxGame.Controls.Add(l);

                Button r = btnRight.Clone();
                r.Name = btnRight.Name + y.ToString();
                r.Location = new Point(btnRight.Location.X, btnRight.Location.Y + (ySpacing * y));
                r.Visible = true;
                r.Click += R_Click;
                grpBxGame.Controls.Add(r);

                for (int x = 0; x <= 16; x++)
                {
                    Label tile = lblTile.Clone();
                    tile.Name = lblTile.Name + y.ToString();
                    tile.Location = new Point(lblTile.Location.X + (xSpacing * x), lblTile.Location.Y + (ySpacing * y));
                    tile.Visible = true;
                    tile.BorderStyle = BorderStyle.None; // Optional
                    if (x == 16 || y == 5)
                    {
                        tile.BorderStyle = BorderStyle.None;
                        tile.BackColor = Control.DefaultBackColor;
                    }
                    grpBxGame.Controls.Add(tile);

                    if (y == 5)
                    {
                        if (x == 16)
                        {
                            _gameFieldLabelTotal = tile;
                        }
                        else
                        {
                            _gameColumnTotalLabelArray[x] = tile;
                        }
                    }
                    else if (x == 16)
                    {
                        if (y != 5)
                        {
                            _gameRowTotalLabelArray[y] = tile;
                        }
                    }
                    else
                    {
                        _gameFieldArray[x, y] = tile;
                    }
                }
            }

            // Hide the template items that I used to automatically generate the form tiles
            btnLeft.Visible = false;
            btnRight.Visible = false;
            lblTile.Visible = false;
            #endregion

            // Load in the previous game state
            if (SafeCrackerPuzzle.Properties.Settings.Default.WasSolved)
            {
                if (MessageBox.Show("The puzzle was previously solved, would you like to reset the puzzle?\r\n\r\nYes - Reset the puzzle\r\nNo - Display the previous solution", "Reset puzzle?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    _rowIndexArray[0] = SafeCrackerPuzzle.Properties.Settings.Default.Row1Index;
                    _rowIndexArray[1] = SafeCrackerPuzzle.Properties.Settings.Default.Row2Index;
                    _rowIndexArray[2] = SafeCrackerPuzzle.Properties.Settings.Default.Row3Index;
                    _rowIndexArray[3] = SafeCrackerPuzzle.Properties.Settings.Default.Row4Index;
                    _rowIndexArray[4] = SafeCrackerPuzzle.Properties.Settings.Default.Row5Index;
                }
            }
            // Update the field
            UpdateField();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the game state before closing
            SafeCrackerPuzzle.Properties.Settings.Default.WasSolved = UpdateField();
            SafeCrackerPuzzle.Properties.Settings.Default.Row1Index = _rowIndexArray[0];
            SafeCrackerPuzzle.Properties.Settings.Default.Row2Index = _rowIndexArray[1];
            SafeCrackerPuzzle.Properties.Settings.Default.Row3Index = _rowIndexArray[2];
            SafeCrackerPuzzle.Properties.Settings.Default.Row4Index = _rowIndexArray[3];
            SafeCrackerPuzzle.Properties.Settings.Default.Row5Index = _rowIndexArray[4];
            SafeCrackerPuzzle.Properties.Settings.Default.Save();
        }

        private bool UpdateField()
        {
            // Debugging
            string output = "";
            for (int i = 0; i < 5; i++)
            {
                //output += "Row[" + i.ToString() + "] = " + _rowIndexArray[i].ToString() + "\r\n";
                output += _rowIndexArray[i].ToString("00");
                if (i != 4)
                {
                    output += ",";
                }
            }
            label1.Text = output;

            int[] gameRowTotalArray = new int[5];
            int[] gameColumnTotalArray = new int[16];
            int gameFieldTotal = new int();

            // Process the field arrays and indices and overlay the data
            for (int y = 0; y < 5; y++)
            {
                Color backColor = _colorArray[0];
                Color frontColor = _colorArray[0];
                int[] backNumbers = null;
                int[] frontNumbers = null;
                uint backIndex = 0;
                uint frontIndex = 0;

                switch (y)
                {
                    case 0:
                        backColor = _colorArray[0];
                        frontColor = _colorArray[0];
                        backNumbers = _r1;
                        frontNumbers = _r1;
                        backIndex = _rowIndexArray[0];
                        frontIndex = _rowIndexArray[0];
                        break;
                    case 1:
                        backColor = _colorArray[0];
                        frontColor = _colorArray[1];
                        backNumbers = _r2B;
                        frontNumbers = _r2F;
                        backIndex = _rowIndexArray[0];
                        frontIndex = _rowIndexArray[1];
                        break;
                    case 2:
                        backColor = _colorArray[1];
                        frontColor = _colorArray[2];
                        backNumbers = _r3B;
                        frontNumbers = _r3F;
                        backIndex = _rowIndexArray[1];
                        frontIndex = _rowIndexArray[2];
                        break;
                    case 3:
                        backColor = _colorArray[2];
                        frontColor = _colorArray[3];
                        backNumbers = _r4B;
                        frontNumbers = _r4F;
                        backIndex = _rowIndexArray[2];
                        frontIndex = _rowIndexArray[3];
                        break;
                    case 4:
                        backColor = _colorArray[3];
                        frontColor = _colorArray[4];
                        backNumbers = _r5B;
                        frontNumbers = _r5F;
                        backIndex = _rowIndexArray[3];
                        frontIndex = _rowIndexArray[4];
                        break;
                }

                for (uint x = 0; x < 16; x++)
                {
                    Label l = _gameFieldArray[x, y];
                    int num = frontNumbers[(frontIndex + x) % 16];
                    l.BackColor = frontColor;
                    if (num == -1)
                    {
                        // -1 is a empty entry so display the number from the tile below
                        num = backNumbers[(backIndex + x) % 16];
                        l.BackColor = backColor;
                    }
                    l.Text = num.ToString();

                    // Count totals
                    gameRowTotalArray[y] += num;
                    gameColumnTotalArray[x] += num;
                    gameFieldTotal += num;
                }
            }

            // Display totals
            bool allFifty = true;

            // Column counts
            for (int i = 0; i < _gameColumnTotalLabelArray.Length; i++)
            {
                _gameColumnTotalLabelArray[i].Visible = chkBxDisplayTotals.Checked;
                _gameColumnTotalLabelArray[i].Text = gameColumnTotalArray[i].ToString();
                if (gameColumnTotalArray[i] == 50)
                {
                    _gameColumnTotalLabelArray[i].BackColor = Color.LightGreen;
                }
                else
                {
                    _gameColumnTotalLabelArray[i].BackColor = DefaultBackColor;
                    allFifty = false;
                }
            }

            // Row counts (or Ring counts in the real game)
            for (int i = 0; i < _gameRowTotalLabelArray.Length; i++)
            {
                _gameRowTotalLabelArray[i].Visible = chkBxEnableHint1.Checked;
                _gameRowTotalLabelArray[i].Text = gameRowTotalArray[i].ToString();
                if (allFifty)
                {
                    _gameRowTotalLabelArray[i].BackColor = Color.LightGreen;
                }
                else
                {
                    _gameRowTotalLabelArray[i].BackColor = DefaultBackColor;
                }
            }

            // Total count
            _gameFieldLabelTotal.Text = gameFieldTotal.ToString();
            _gameFieldLabelTotal.Visible = chkBxEnableHint2.Checked;
            if (gameFieldTotal == 800)
            {
                _gameFieldLabelTotal.BackColor = Color.LightGreen;
            }
            else
            {
                _gameFieldLabelTotal.BackColor = DefaultBackColor;
            }
            if (allFifty)
            {
                this.BackColor = Color.LightGreen;
                _gameFieldLabelTotal.BackColor = Color.LightGreen;
                foreach (Label l in _gameColumnTotalLabelArray)
                {
                    l.Visible = true;
                }
                _gameFieldLabelTotal.Visible = true;
            }
            else
            {
                this.BackColor = DefaultBackColor;
            }

            return allFifty;
        }

        #region Controls
        private void L_Click(object sender, EventArgs e)
        {
            string n = ((Button)sender).Name.Substring(btnLeft.Name.Length);
            int index = int.Parse(n);
            if (index == 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    _rowIndexArray[i] = (_rowIndexArray[i] + 1) % 16;
                }
            }
            else
            {
                _rowIndexArray[index] = (_rowIndexArray[index] + 1) % 16;
            }

            if (UpdateField() && (index != 5))
            {
                this.Refresh();
                string output = "";
                for (int i = 0; i < 5; i++)
                {
                    output += _rowIndexArray[i].ToString("00");
                    if (i != 4)
                    {
                        output += ",";
                    }
                }
                MessageBox.Show("Solved!\r\n\r\nSolution: " + output, "Solved!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void R_Click(object sender, EventArgs e)
        {
            string n = ((Button)sender).Name.Substring(btnRight.Name.Length);
            int index = int.Parse(n);
            if (index == 5)
            {
                for (int i = 0; i < 5; i++)
                {
                    _rowIndexArray[i] = (_rowIndexArray[i] - 1) % 16;
                }
            }
            else
            {
                _rowIndexArray[index] = (_rowIndexArray[index] - 1) % 16;
            }

            if (UpdateField() && (index != 5))
            {
                this.Refresh();
                string output = "";
                for (int i = 0; i < 5; i++)
                {
                    output += _rowIndexArray[i].ToString("00");
                    if (i != 4)
                    {
                        output += ",";
                    }
                }
                MessageBox.Show("Soved!\r\n\r\nSolution: " + output, "Solved!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you would like to reset the puzzle?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rowIndexArray = new uint[] { 0, 0, 0, 0, 0 };
                UpdateField();
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you would like to solve the puzzle?\r\n\r\nNote, This is a slow process and it will lock up the form until it completes.", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                chkBxDisplayTotals.Checked = true;
                chkBxEnableHint1.Checked = true;
                chkBxEnableHint2.Checked = true;

                // The first index doesn't matter, but I used this when I solved manually so I set it to the default here
                _rowIndexArray = new uint[] { 8, 0, 0, 0, 0 };
                this.Refresh();
                DateTime dt = DateTime.Now;

                // Counting in twos so that only fields that total to 800 are calculated
                int count = 0;
                for (uint i = 1; i < 16; i += 2)
                {
                    for (uint j = 1; j < 16; j += 2)
                    {
                        for (uint k = 0; k < 16; k += 2)
                        {
                            for (uint l = 0; l < 16; l += 2)
                            {
                                count++;
                                _rowIndexArray = new uint[] { 8, i, j, k, l };

                                if (UpdateField())
                                {
                                    this.Refresh();
                                    string output = "";
                                    for (int z = 0; z < 5; z++)
                                    {
                                        output += _rowIndexArray[z].ToString("00");
                                        if (z != 4)
                                        {
                                            output += ",";
                                        }
                                    }
                                    MessageBox.Show("Soved! It took " + (DateTime.Now - dt).TotalSeconds.ToString("#,##0.00") + " seconds\r\n\r\nAttempt " + count.ToString() + " out of 4096\r\n\r\nSolution: " + output, "Solved!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                                else
                                {
                                    // This makes it very slow since it updates the screen each time (but it looks cooler)
                                    this.Refresh();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnShowSolution_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you would like to show the puzzle solution?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _rowIndexArray = new uint[] { 8, 15, 5, 6, 14 };
                UpdateField();
            }
        }

        private void chkBxDisplayTotals_Click(object sender, EventArgs e)
        {
            if (chkBxDisplayTotals.Checked == false)
            {
                if (MessageBox.Show("Are you sure that you would like to display totals?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    chkBxDisplayTotals.Checked = true;
                }
            }
            else
            {
                chkBxDisplayTotals.Checked = false;
            }
            UpdateField();
        }

        private void chkBxEnableHint_Click(object sender, EventArgs e)
        {
            if (chkBxEnableHint1.Checked == false)
            {
                if (MessageBox.Show("Are you sure that you would like to show hint 1?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    chkBxEnableHint1.Checked = true;
                }
            }
            else
            {
                chkBxEnableHint1.Checked = false;
            }
            UpdateField();
        }

        private void chkBxEnableHint2_Click(object sender, EventArgs e)
        {
            if (chkBxEnableHint2.Checked == false)
            {
                if (MessageBox.Show("Are you sure that you would like to show hint 2?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    chkBxEnableHint2.Checked = true;
                }
            }
            else
            {
                chkBxEnableHint2.Checked = false;
            }
            UpdateField();
        }
        #endregion
    }

    public static class ControlExtensions
    {
        /// <summary>
        /// Control extension to allow me to use the clone operation to copy a control item (like buttons and labels)
        /// https://stackoverflow.com/questions/10266589/clone-controls-c-sharp-winform
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controlToClone"></param>
        /// <returns></returns>
        public static T Clone<T>(this T controlToClone) where T : Control
        {
            PropertyInfo[] controlProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            T instance = Activator.CreateInstance<T>();

            foreach (PropertyInfo propInfo in controlProperties)
            {
                if (propInfo.CanWrite)
                {
                    if (propInfo.Name != "WindowTarget")
                    {
                        propInfo.SetValue(instance, propInfo.GetValue(controlToClone, null), null);
                    }
                }
            }

            return instance;
        }
    }
}
