using System.Collections;

namespace osisp_laba_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateCell(e.RowIndex, e.ColumnIndex);
        }

        private void UpdateCell(int rowIndex, int columnIndex)
        {
            DataGridViewCell cell = dataGridView1.Rows[rowIndex].Cells[columnIndex];
            if (cell == null || cell.Value == null) return;
            string str = cell.Value.ToString();
            str = str.Replace(" \u3164", "");
            List<string> words = str.Split(' ').ToList<string>();

            int symbolsMax = (int)(2.5f * cell.Size.Width / dataGridView1.Font.Height);
            for (int i = 0; i < words.Count; i++)
            {
                string word = words[i];
                if (word.Length > symbolsMax)
                {
                    words[i] = word.Substring(0, symbolsMax);
                    string nextWord = word.Substring(symbolsMax, word.Length - symbolsMax);
                    words.Insert(i + 1, '\u3164' + nextWord);
                }
            }

            cell.Value = String.Join(' ', words);
        }

        private void dataGridView1_SizeChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                for (int j = 0; j < dataGridView1.Rows[i].Cells.Count; j++)
                {
                    UpdateCell(i, j);
                }
        }
    }
}